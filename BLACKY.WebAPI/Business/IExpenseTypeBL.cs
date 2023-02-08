using BLACKY.WebAPI.Models;

namespace BLACKY.WebAPI.Business
{
    public interface IExpenseTypeBL
    {
        int Add(ExpenseTypeEntity expenseType);
        List<ExpenseTypeEntity> Get(int? id);        
        int Update(ExpenseTypeEntity expenseType);
        int Delete(ExpenseTypeEntity expenseType);        
    }
}
