using BLACKY.WebAPI.Helpers;
using BLACKY.WebAPI.Models;
using Dapper;
using System.Data;
using static Dapper.SqlMapper;

namespace BLACKY.WebAPI.Business
{
    public class ExpenseTypeBL : IExpenseTypeBL
    {
        private readonly ISqlHelper _sqlHelper;

        public ExpenseTypeBL (ISqlHelper sqlHelper)
        {
            _sqlHelper = sqlHelper;
        }

        public int Add(ExpenseTypeEntity expenseType)
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
        public int Delete(ExpenseTypeEntity expenseType)
        {
            throw new NotImplementedException();
        }
        public List<ExpenseTypeEntity> Get(int? id)
        {
            return _sqlHelper.GetData<ExpenseTypeEntity>("spGetExpenseTypes", _sqlHelper.CreateParameter("ID",id),CommandType.StoredProcedure);            
        }
        public int Update(ExpenseTypeEntity expenseType)
        {
            throw new NotImplementedException();
        }        
    }
}
