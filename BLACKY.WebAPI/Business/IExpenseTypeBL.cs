using BLACKY.WebAPI.Models;

namespace BLACKY.WebAPI.Business
{
    public interface IExpenseTypeBL
    {
        int Create(ExpenseTypeEntity expenseType);
        List<ExpenseTypeEntity> GetByID(int? expenseTypeID);
        List<ExpenseTypeEntity> GetByName(string? expenseTypeName);
        bool Update(ExpenseTypeEntity expenseType);
        bool Delete(ExpenseTypeEntity expenseType);        
        // Hard Delete From Database
        bool Delete(int expenseTypeID);
    }
}
