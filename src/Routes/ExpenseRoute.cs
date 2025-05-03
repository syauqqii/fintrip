using fintrip.src.Services;
using fintrip.src.Models;

namespace fintrip.src.Routes {
    public static class ExpenseRoute {
        public static void MapExpenseRoute(this WebApplication app) {
            var service = new ExpenseService();

            app.MapPost("/expenses", (Expense expense) => service.Create(expense));
            app.MapGet("/expenses", () => service.GetAll());
            app.MapPut("/expenses/{id}", (int id, Expense updatedExpense) => {
                var expense = service.Update(id, updatedExpense);
                return (expense is not null) ? Results.Ok(expense) : Results.NotFound("Expense not found");
            });
            app.MapDelete("/expenses/{id}", (int id) => {
                var deleted = service.Delete(id);
                return deleted ? Results.Ok("Expense deleted") : Results.NotFound("Expense not found");
            });
        }
    }
}