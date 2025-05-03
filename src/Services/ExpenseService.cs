using fintrip.src.Models;

namespace fintrip.src.Services {
    public class ExpenseService {
        private static readonly List<Expense> Expenses = new();

        public Expense Create(Expense expense) {
            expense.Id = (Expenses.Count > 0) ? Expenses.Max(item => item.Id) + 1 : 1;
            expense.Tanggal = DateTime.Now;

            Expenses.Add(expense);

            return expense;
        }

        public List<Expense> GetAll() => Expenses;

        public Expense Update(int Id, Expense updatedExpense) {
            var expense = Expenses.FirstOrDefault(item => item.Id == Id);
            if (expense == null) return null;

            expense.Nominal = updatedExpense.Nominal;
            expense.Tanggal = DateTime.Now;
            expense.Lunas = updatedExpense.Lunas;
            expense.Catatan = updatedExpense.Catatan;
            expense.CategoryId = updatedExpense.CategoryId;

            return expense;
        }

        public bool Delete(int Id) {
            var expense = Expenses.FirstOrDefault(item => item.Id == Id);
            if (expense == null) return false;

            Expenses.Remove(expense);

            return true;
        }
    }
}