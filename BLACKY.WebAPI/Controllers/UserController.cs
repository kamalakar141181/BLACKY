using BLACKY.WebAPI.Business;
using BLACKY.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BLACKY.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext dbContext;
        private readonly ILogger<UserController> logger;
        private readonly IUserBL userBL;

        JsonSerializerSettings setting = new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore,
            DefaultValueHandling = DefaultValueHandling.Ignore
        };

        public UserController(IUserBL userBL, AppDbContext dbContextSQL, ILogger<UserController> logger)
        {
            this.dbContext = dbContextSQL;
            this.logger = logger;
            this.userBL = userBL;

            logger.LogDebug("LogDebug -> UserController");
            logger.LogInformation("LogInformation -> UserController");
            logger.LogWarning("LogWarning -> UserController");
            logger.LogError("LogError -> UserController");

            

        }

        [HttpPost("CreateUser")]
        public async Task<HttpStatusCode> CreateUser(UserEntity userEntity)
        {
            
            

            //logger.LogInformation(JsonConvert.SerializeObject(userEntity, Formatting.Indented, setting));
            logger.LogTrace(JsonConvert.SerializeObject(userEntity, Formatting.Indented, setting));

            int generatedID = userBL.CreateUser(userEntity);

            if (generatedID > 0)
                return HttpStatusCode.Created;
            else
                return HttpStatusCode.FailedDependency;
        }

        [HttpGet("GetUserByID")]
        public async Task<ActionResult<UserEntity>> GetUserByID(int userID)
        {
            logger.LogTrace(JsonConvert.SerializeObject(userID, Formatting.Indented, setting));

            List<UserEntity> lstUser = new List<UserEntity>();
            lstUser = userBL.GetUserByID(userID);

            if (lstUser == null)
                return NotFound();
            return Ok (lstUser);
        }

        [HttpGet("GetUserByUsername")]
        public async Task<ActionResult<UserEntity>> GetUserByUsername(string username)
        {
            logger.LogTrace(JsonConvert.SerializeObject(username, Formatting.Indented, setting));
            List<UserEntity> lstUser = new List<UserEntity>();
            lstUser = userBL.GetUserByUsername(username);

            if (lstUser == null)
                return NotFound();
            return Ok(lstUser);
        }

        [HttpGet("GetUserByEmailID")]
        public async Task<ActionResult<UserEntity>> GetUserByEmailID(string emailID)
        {
            logger.LogTrace(JsonConvert.SerializeObject(emailID, Formatting.Indented, setting));

            List<UserEntity> lstUser = new List<UserEntity>();
            lstUser = userBL.GetUserByEmailID(emailID);

            if (lstUser == null)
                return NotFound();
            return Ok(lstUser);
        }

        [HttpGet("GetUserByMobileNumber")]
        public async Task<ActionResult<UserEntity>> GetUserByMobileNumber(string mobileNumber)
        {
            logger.LogTrace(JsonConvert.SerializeObject(mobileNumber, Formatting.Indented, setting));
            List<UserEntity> lstUser = new List<UserEntity>();
            lstUser = userBL.GetUserByMobileNumber(mobileNumber);

            if (lstUser == null)
                return NotFound();
            return Ok(lstUser);
        }

        [HttpPut("UpdateUser")]
        public async Task<HttpStatusCode> UpdateUser(UserEntity userEntity)
        {
            logger.LogTrace(JsonConvert.SerializeObject(userEntity, Formatting.Indented, setting));
            bool isUpdated = userBL.UpdateUser(userEntity);

            if (isUpdated)
                return HttpStatusCode.Created;
            else
                return HttpStatusCode.NotModified;
        }

        [HttpPut("DeleteUser")]
        public async Task<HttpStatusCode> DeleteUser(UserEntity userEntity)
        {
            logger.LogTrace(JsonConvert.SerializeObject(userEntity, Formatting.Indented, setting));
            bool isUpdated = userBL.DeleteUser(userEntity);

            if (isUpdated)
                return HttpStatusCode.Created;
            else
                return HttpStatusCode.NotModified;
        }
    }
}
