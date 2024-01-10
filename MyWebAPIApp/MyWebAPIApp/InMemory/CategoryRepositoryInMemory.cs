using MyWebAPIApp.Data;
using MyWebAPIApp.Interface;
using MyWebAPIApp.Models;
using MyWebAPIApp.Models.ViewModel;

namespace MyWebAPIApp.InMemory
{
    public class CategoryRepositoryInMemory : ICategoryRepository
    {
        static List<CategoryVM> list = new List<CategoryVM>
        {
            new CategoryVM
            {
                CategoryID = 1, CategoryName = "Tivi"
            },
            new CategoryVM
            {
                CategoryID = 2, CategoryName = "Tu lanh"
            },
            new CategoryVM
            {
                CategoryID = 3, CategoryName = "Dieu hoa"
            }

        };
        public CategoryVM Create(CategoryModel category)
        {
            var newCategory = new CategoryVM
            {
                CategoryID = list.Max(c => c.CategoryID) + 1,
                CategoryName = category.CategoryName,
            };
            list.Add(newCategory);
            return newCategory;
        }

        public void Delete(int id)
        {
            var find = list.SingleOrDefault(ca => ca.CategoryID == id);
            if (find != null)
            {
                list.Remove(find);
            }
        }

        public List<CategoryVM> GetAll()
        {
            return list;
        }

        public CategoryVM GetById(int id)
        {
            return list.SingleOrDefault(ca => ca.CategoryID == id);
        }

        public void Update(CategoryVM categoryVM)
        {
            var find = list.SingleOrDefault(ca => ca.CategoryID == categoryVM.CategoryID);
            if(find != null) { 
                find.CategoryName = categoryVM.CategoryName;
            }
        }
    }
}
