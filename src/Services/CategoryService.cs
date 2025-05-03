using fintrip.src.Models;

namespace fintrip.src.Services {
    public class CategoryService {
        private static readonly List<Category> Categories = new();

        public Category Create(Category category) {
            category.Id = (Categories.Count > 0) ? Categories.Max(item => item.Id) + 1 : 1;

            Categories.Add(category);

            return category;
        }

        public List<Category> GetAll() => Categories;

        public Category Update(int id, Category updatedCategory) {
            var category =  Categories.FirstOrDefault(item => item.Id == id);
            if (category == null) return null;

            category.Name = updatedCategory.Name;

            return category;
        }

        public bool Delete(int id) {
            var category = Categories.FirstOrDefault(item => item.Id == id);
            if (category == null) return false;

            Categories.Remove(category);

            return true;
        }
    }
}