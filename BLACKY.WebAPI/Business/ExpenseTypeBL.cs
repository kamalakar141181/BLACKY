using BLACKY.WebAPI.Helpers;
using BLACKY.WebAPI.Models;
using Dapper;
using System.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace BLACKY.WebAPI.Business
{
    public class ExpenseTypeBL : IExpenseTypeBL
    {
        private readonly ISqlHelper _sqlHelper;

        public ExpenseTypeBL (ISqlHelper sqlHelper)
        {
            _sqlHelper = sqlHelper;
        }

        public int Create(ExpenseTypeEntity expenseType)
        {
            int returnValue = 0;
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("ID", expenseType.ID, System.Data.DbType.Int32, System.Data.ParameterDirection.InputOutput);
            dynamicParameters.Add("Name", expenseType.Name);
            dynamicParameters.Add("Description", expenseType.Description);

            dynamicParameters.Add("CreatedBy", expenseType.CreatedBy);
            dynamicParameters.Add("ModifiedBy", expenseType.ModifiedBy);
            dynamicParameters.Add("CreatedDate", expenseType.CreatedDate);
            dynamicParameters.Add("ModifiedDate", expenseType.ModifiedDate);
            dynamicParameters.Add("IsDeleted", expenseType.IsDeleted);

            _sqlHelper.SaveData("spAddExpenseTypes", dynamicParameters);
            returnValue = dynamicParameters.Get<int>("ID");
            return returnValue;
        }
        
        public List<ExpenseTypeEntity> GetByID(int? expenseTypeID)
        {
            List<ExpenseTypeEntity> lstResult = new List<ExpenseTypeEntity>();
            DynamicParameters dynamicParameters = new DynamicParameters();
            if (expenseTypeID > 0)
            {
                dynamicParameters.Add("ExpID", expenseTypeID, DbType.Int32, ParameterDirection.Input);
            }
            lstResult = _sqlHelper.GetData<ExpenseTypeEntity>("spGetExpenseTypeByID", dynamicParameters,CommandType.StoredProcedure);
            return lstResult;
        }

        public List<ExpenseTypeEntity> GetByName(string? expenseTypeName)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            if(!string.IsNullOrEmpty(expenseTypeName))
            {
                dynamicParameters.Add("Name", expenseTypeName, DbType.String, ParameterDirection.Input);
            }
            
            return _sqlHelper.GetData<ExpenseTypeEntity>("spGetExpenseTypeByName", dynamicParameters, CommandType.StoredProcedure);
        }
        public bool Update(ExpenseTypeEntity expenseType)
        {
            bool isUpdated = false;
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("IsSucceeded", 0, System.Data.DbType.Boolean, System.Data.ParameterDirection.Output);
            dynamicParameters.Add("ID", expenseType.ID, DbType.Int32, System.Data.ParameterDirection.Input);
            dynamicParameters.Add("Name", expenseType.Name, DbType.String, System.Data.ParameterDirection.Input);
            dynamicParameters.Add("Description", expenseType.Description, DbType.String, System.Data.ParameterDirection.Input);            
            dynamicParameters.Add("ModifiedBy", expenseType.ModifiedBy, DbType.String, System.Data.ParameterDirection.Input);            
            dynamicParameters.Add("ModifiedDate", expenseType.ModifiedDate, DbType.DateTime, System.Data.ParameterDirection.Input);
            _sqlHelper.SaveData("spUpdateExpenseType", dynamicParameters);
            isUpdated = dynamicParameters.Get<bool>("IsSucceeded");
            return isUpdated;
        }

        public bool Delete(ExpenseTypeEntity expenseType)
        {
            bool isDeleted = false;
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("IsSucceeded", 0, System.Data.DbType.Boolean, System.Data.ParameterDirection.Output);
            dynamicParameters.Add("ID", expenseType.ID, DbType.Int32, System.Data.ParameterDirection.Input);
            dynamicParameters.Add("IsDeleted", expenseType.IsDeleted, DbType.Boolean, System.Data.ParameterDirection.Input);
            dynamicParameters.Add("ModifiedBy", expenseType.ModifiedBy, DbType.String, System.Data.ParameterDirection.Input);
            dynamicParameters.Add("ModifiedDate", expenseType.ModifiedDate, DbType.DateTime, System.Data.ParameterDirection.Input);

            _sqlHelper.SaveData("spDeleteExpenseType", dynamicParameters);
            isDeleted = dynamicParameters.Get<bool>("IsSucceeded");
            return isDeleted;
        }

        // Hard Delete From Database
        public bool Delete(int expenseTypeID)
        {
            bool isDeleted = false;
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("IsSucceeded", 0, System.Data.DbType.Boolean, System.Data.ParameterDirection.Output);
            dynamicParameters.Add("ID", expenseTypeID, DbType.Int32, System.Data.ParameterDirection.Input);            

            _sqlHelper.SaveData("spHardDeleteExpenseType", dynamicParameters);
            isDeleted = dynamicParameters.Get<bool>("IsSucceeded");
            return isDeleted;
        }
    }
}
