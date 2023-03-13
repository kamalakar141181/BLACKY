using BLACKY.WebAPI.Business;
using BLACKY.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;
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

        public ExpenseTypeController(IExpenseTypeBL expenseTypeBL, AppDbContext dbContextSQL, ILogger<ExpenseTypeController> logger)
        {
            this.dbContext = dbContextSQL;
            this.logger = logger;
            this.expenseTypeBL = expenseTypeBL;            
        }

        [HttpPost("CreateExpenseType")]
        public async Task<HttpStatusCode> Create(ExpenseTypeEntity expenseType)
        {
            logger.LogDebug("Hey, this is a DEBUG message.");
            logger.LogInformation("Hey, this is an INFO message.");
            logger.LogWarning("Hey, this is a WARNING message.");
            logger.LogError("Hey, this is an ERROR message.");

            int generatedID =  expenseTypeBL.Create(expenseType);
            if (generatedID > 0)
                return HttpStatusCode.Created;
            else
                return HttpStatusCode.FailedDependency;
        }
         

        [HttpGet("GetExpenseTypeByID")]
        public async Task<ActionResult<ExpenseTypeEntity>> GetByID(int ID)
        {
            List<ExpenseTypeEntity> lstExpenseType = new List<ExpenseTypeEntity>();
            lstExpenseType = expenseTypeBL.GetByID(ID);

            if (lstExpenseType == null)
                return NotFound();
            return Ok(lstExpenseType);
        }

        [HttpGet("GetExpenseTypeByName")]
        public async Task<ActionResult<ExpenseTypeEntity>> GetByName(string name)
        {

            List<ExpenseTypeEntity> lstExpenseType = new List<ExpenseTypeEntity>();
            lstExpenseType = expenseTypeBL.GetByName(name);

            if (lstExpenseType == null)
                return NotFound();
            return Ok(lstExpenseType);
        }


        [HttpPut("UpdateExpenseType")]
        public async Task<ActionResult<HttpStatusCode>> Update(ExpenseTypeEntity expenseType)
        {
            bool isUpdated = expenseTypeBL.Update(expenseType);

            if (isUpdated)
                return HttpStatusCode.Created;
            else
                return HttpStatusCode.NotModified;

        }

        [HttpDelete("DeleteExpenseType")]     
        public async Task<ActionResult<HttpStatusCode>> Delete(ExpenseTypeEntity expenseType)
        {
            bool isDeleted = expenseTypeBL.Delete(expenseType);

            if (isDeleted)
                return HttpStatusCode.Created;
            else
                return HttpStatusCode.NotModified;

        }

        // Hard Delete From Database
        [HttpDelete("HardDeleteExpenseType")]
        public async Task<ActionResult<HttpStatusCode>> Delete(int expenseTypeID)
        {
            bool isDeleted = expenseTypeBL.Delete(expenseTypeID);

            if (isDeleted)
                return HttpStatusCode.Created;
            else
                return HttpStatusCode.NotModified;
        }

    }
}
