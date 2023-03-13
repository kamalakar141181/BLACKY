using BLACKY.WebAPI.Business;
using BLACKY.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BLACKY.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseTypeController : ControllerBase
    {
        private readonly AppDbContext dbContext;
        private readonly ILogger<ExpenseTypeController> logger;
        private readonly IExpenseTypeBL expenseTypeBL;

        JsonSerializerSettings setting = new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore,
            DefaultValueHandling = DefaultValueHandling.Ignore
        };
        public ExpenseTypeController(IExpenseTypeBL expenseTypeBL, AppDbContext dbContextSQL, ILogger<ExpenseTypeController> logger)
        {
            this.dbContext = dbContextSQL;
            this.logger = logger;
            this.expenseTypeBL = expenseTypeBL;            
        }

        [HttpPost("CreateExpenseType")]
        public async Task<HttpStatusCode> CreateExpenseType(ExpenseTypeEntity expenseType)
        {
            logger.LogDebug("Hey, this is a DEBUG message.");
            logger.LogInformation("Hey, this is an INFO message.");
            logger.LogWarning("Hey, this is a WARNING message.");
            logger.LogError("Hey, this is an ERROR message.");

            logger.LogTrace(JsonConvert.SerializeObject(expenseType, Formatting.Indented, setting));

            int generatedID =  expenseTypeBL.CreateExpenseType(expenseType);
            if (generatedID > 0)
                return HttpStatusCode.Created;
            else
                return HttpStatusCode.FailedDependency;
        }
         

        [HttpGet("GetExpenseTypeByID")]
        public async Task<ActionResult<ExpenseTypeEntity>> GetExpenseTypeByID(int ID)
        {
            logger.LogTrace(JsonConvert.SerializeObject(ID, Formatting.Indented, setting));

            List<ExpenseTypeEntity> lstExpenseType = new List<ExpenseTypeEntity>();
            lstExpenseType = expenseTypeBL.GetExpenseTypeByID(ID);

            if (lstExpenseType == null)
                return NotFound();
            return Ok(lstExpenseType);
        }

        [HttpGet("GetExpenseTypeByName")]
        public async Task<ActionResult<ExpenseTypeEntity>> GetExpenseTypeByName(string username)
        {
            logger.LogTrace(JsonConvert.SerializeObject(username, Formatting.Indented, setting));

            List<ExpenseTypeEntity> lstExpenseType = new List<ExpenseTypeEntity>();
            lstExpenseType = expenseTypeBL.GetExpenseTypeByName(username);

            if (lstExpenseType == null)
                return NotFound();
            return Ok(lstExpenseType);
        }


        [HttpPut("UpdateExpenseType")]
        public async Task<ActionResult<HttpStatusCode>> UpdateExpenseType(ExpenseTypeEntity expenseType)
        {
            logger.LogTrace(JsonConvert.SerializeObject(expenseType, Formatting.Indented, setting));

            bool isUpdated = expenseTypeBL.UpdateExpenseType(expenseType);

            if (isUpdated)
                return HttpStatusCode.Created;
            else
                return HttpStatusCode.NotModified;

        }

        [HttpDelete("DeleteExpenseType")]     
        public async Task<ActionResult<HttpStatusCode>> DeleteExpenseType(ExpenseTypeEntity expenseType)
        {
            logger.LogTrace(JsonConvert.SerializeObject(expenseType, Formatting.Indented, setting));

            bool isDeleted = expenseTypeBL.DeleteExpenseType(expenseType);

            if (isDeleted)
                return HttpStatusCode.Created;
            else
                return HttpStatusCode.NotModified;

        }

        // Hard Delete From Database
        [HttpDelete("HardDeleteExpenseType")]
        public async Task<ActionResult<HttpStatusCode>> HardDeleteExpenseType(int expenseTypeID)
        {
            logger.LogTrace(JsonConvert.SerializeObject(expenseTypeID, Formatting.Indented, setting));

            bool isDeleted = expenseTypeBL.HardDeleteExpenseType(expenseTypeID);

            if (isDeleted)
                return HttpStatusCode.Created;
            else
                return HttpStatusCode.NotModified;
        }

    }
}
