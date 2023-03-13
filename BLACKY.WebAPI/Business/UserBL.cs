using BLACKY.WebAPI.Helpers;
using BLACKY.WebAPI.Models;
using Dapper;
using System.Data;

namespace BLACKY.WebAPI.Business
{
    public class UserBL : IUserBL
    {
        private readonly ISqlHelper _sqlHelper;
        public UserBL(ISqlHelper sqlHelper)
        {
            _sqlHelper = sqlHelper;
        }

        public int CreateUser(UserEntity userEntity)
        {
            int returnValue = 0;
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("ID", userEntity.ID, System.Data.DbType.Int32, System.Data.ParameterDirection.InputOutput);
            dynamicParameters.Add("Username", userEntity.Username);
            dynamicParameters.Add("EmailID", userEntity.EmailID);
            dynamicParameters.Add("MobileNumber", userEntity.MobileNumber);
            dynamicParameters.Add("Password", userEntity.Password);

            dynamicParameters.Add("CreatedBy", userEntity.CreatedBy);
            dynamicParameters.Add("ModifiedBy", userEntity.ModifiedBy);
            dynamicParameters.Add("CreatedDate", userEntity.CreatedDate);
            dynamicParameters.Add("ModifiedDate", userEntity.ModifiedDate);
            dynamicParameters.Add("IsDeleted", userEntity.IsDeleted);

            _sqlHelper.SaveData("spAddUser", dynamicParameters);
            returnValue = dynamicParameters.Get<int>("ID");
            return  returnValue;
        }

        public List<UserEntity> GetUserByID(int? userID)
        {
            List<UserEntity> lstUser = new List<UserEntity>();
            DynamicParameters dynamicParameters = new DynamicParameters();
            if (userID > 0)
            {
                dynamicParameters.Add("ID", userID, DbType.Int32, ParameterDirection.Input);
            }
            lstUser = _sqlHelper.GetData<UserEntity>("spGetUserByID", dynamicParameters, CommandType.StoredProcedure);
            return lstUser;
        }

        public List<UserEntity> GetUserByUsername(string username)
        {
            List<UserEntity> lstUser = new List<UserEntity>();
            DynamicParameters dynamicParameters = new DynamicParameters();

            if (!string.IsNullOrEmpty(username))
            {
                dynamicParameters.Add("Username", username, DbType.String, ParameterDirection.Input);
            }
            lstUser = _sqlHelper.GetData<UserEntity>("spGetUserByUsername", dynamicParameters, CommandType.StoredProcedure);
            return lstUser;
        }

        public List<UserEntity> GetUserByEmailID(string emailID)
        {
            List<UserEntity> lstUser = new List<UserEntity>();
            DynamicParameters dynamicParameters = new DynamicParameters();

            if (!string.IsNullOrEmpty(emailID))
            {
                dynamicParameters.Add("EmailID", emailID, DbType.String, ParameterDirection.Input);
            }
            lstUser = _sqlHelper.GetData<UserEntity>("spGetUserByEmailID", dynamicParameters, CommandType.StoredProcedure);
            return lstUser;
        }

        public List<UserEntity> GetUserByMobileNumber(string mobileNumber)
        {
            List<UserEntity> lstUser = new List<UserEntity>();
            DynamicParameters dynamicParameters = new DynamicParameters();

            if (!string.IsNullOrEmpty(mobileNumber))
            {
                dynamicParameters.Add("MobileNumber", mobileNumber, DbType.String, ParameterDirection.Input);
            }
            lstUser = _sqlHelper.GetData<UserEntity>("spGetUserByMobileNumber", dynamicParameters, CommandType.StoredProcedure);
            return lstUser;
        }

        public bool UpdateUser(UserEntity userEntity)
        {
            bool isUpdated = false;
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("IsSucceeded", 0, System.Data.DbType.Boolean, System.Data.ParameterDirection.Output);
            dynamicParameters.Add("ID", userEntity.ID);
            dynamicParameters.Add("Username", userEntity.Username);
            dynamicParameters.Add("EmailID", userEntity.EmailID);
            dynamicParameters.Add("MobileNumber", userEntity.MobileNumber);
            dynamicParameters.Add("Password", userEntity.Password);
            dynamicParameters.Add("IsActive", userEntity.IsActive);
            dynamicParameters.Add("ModifiedBy", userEntity.ModifiedBy);
            dynamicParameters.Add("ModifiedDate", userEntity.ModifiedDate);

            _sqlHelper.SaveData("spUpdateUser", dynamicParameters);
            isUpdated = dynamicParameters.Get<bool>("IsSucceeded");
            return isUpdated;
        }
        public bool DeleteUser(UserEntity userEntity)
        {
            bool isDeleted = false;
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("IsSucceeded", 0, System.Data.DbType.Boolean, System.Data.ParameterDirection.Output);
            dynamicParameters.Add("ID", userEntity.ID); 
            dynamicParameters.Add("ModifiedBy", userEntity.ModifiedBy);
            dynamicParameters.Add("ModifiedDate", userEntity.ModifiedDate);
            dynamicParameters.Add("IsDeleted", userEntity.IsDeleted);
            _sqlHelper.SaveData("spDeleteUser", dynamicParameters);
            isDeleted = dynamicParameters.Get<bool>("IsSucceeded");
            return isDeleted;
        }

        

        
    }
}
