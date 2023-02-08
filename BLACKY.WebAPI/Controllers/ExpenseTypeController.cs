using BLACKY.WebAPI.Business;
using BLACKY.WebAPI.Models;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Net;
using static Dapper.SqlMapper;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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
        //private readonly ILogger<ExpenseTypeController> logger;

        public ExpenseTypeController(IExpenseTypeBL expenseTypeBL, AppDbContext dbContextSQL, ILogger<ExpenseTypeController> logger)
        {
            this.dbContext = dbContextSQL;
            this.logger = logger;
            this.expenseTypeBL = expenseTypeBL;            
        }

        [HttpPost("InsertExpenseType")]
        public async Task<HttpStatusCode> InsertExpenseType(ExpenseTypeEntity expenseType)
        {
            logger.LogDebug("Hey, this is a DEBUG message.");
            logger.LogInformation("Hey, this is an INFO message.");
            logger.LogWarning("Hey, this is a WARNING message.");
            logger.LogError("Hey, this is an ERROR message.");


            var entity = new ExpenseTypeEntity()
            {
                Name = expenseType.Name,
                Description = expenseType.Description,
                CreatedBy = expenseType.CreatedBy,
                CreatedDate = expenseType.CreatedDate,
                ModifiedBy = expenseType.ModifiedBy,
                ModifiedDate = expenseType.ModifiedDate,
                IsDeleted = expenseType.IsDeleted
            };

            int generatedID =  expenseTypeBL.Add(entity);

            return HttpStatusCode.Created;
        }


        [HttpGet("GetExpenseTypeById")]
        public async Task<ActionResult<ExpenseTypeEntity>> GetExpenseTypeById(int id)
        {
            List<ExpenseTypeEntity> lstExpenseType = new List<ExpenseTypeEntity>();
            lstExpenseType =  expenseTypeBL.Get(id);//.FirstOrDefaultAsync(m => m.Id == id);
            if (lstExpenseType == null)
                return NotFound();
            return Ok(lstExpenseType);            
        }
               

        [HttpPut("UpdateExpenseType")]
        public async Task<HttpStatusCode> UpdateExpenseType(ExpenseTypeEntity expenseType)
        {
            logger.LogInformation("UpdateExpenseType");
            var entity = await dbContext.ExpenseTypes.FirstOrDefaultAsync(x => x.ID == expenseType.ID);

            entity.Name = expenseType.Name;
            entity.Description = expenseType.Description;            

            await dbContext.SaveChangesAsync();
            return HttpStatusCode.OK;
        }        
    }
}
