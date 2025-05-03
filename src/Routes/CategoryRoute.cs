using fintrip.src.Services;
using fintrip.src.Models;

namespace fintrip.src.Routes {
    public static class CategoryRoute {
        public static void MapCategoryRoutes(this WebApplication app) {
            var service = new CategoryService();

            app.MapPost("/categories", (Category category) => service.Create(category));
            app.MapGet("/categories", () => service.GetAll());
            app.MapPut("/categories/{id}", (int id, Category updatedCategory) => {
                var category = service.Update(id, updatedCategory);
                return (category is not null) ? Results.Ok(category) : Results.NotFound("Category not found");
            });
            app.MapDelete("/categories/{id}", (int id) => {
                var deleted = service.Delete(id);
                return deleted ? Results.Ok("Category deleted") : Results.NotFound("Category not found");
            });
        }
    }
}