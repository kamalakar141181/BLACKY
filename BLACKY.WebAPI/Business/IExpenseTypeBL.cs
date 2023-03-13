using BLACKY.WebAPI.Models;

namespace BLACKY.WebAPI.Business
{
    public interface IExpenseTypeBL
    {
        int CreateExpenseType(ExpenseTypeEntity expenseType);
        List<ExpenseTypeEntity> GetExpenseTypeByID(int? expenseTypeID);
        List<ExpenseTypeEntity> GetExpenseTypeByName(string? expenseTypeName);
        bool UpdateExpenseType(ExpenseTypeEntity expenseType);
        bool DeleteExpenseType(ExpenseTypeEntity expenseType);        
        // Hard Delete From Database
        bool HardDeleteExpenseType(int expenseTypeID);
    }
}
