using MyWebAPIApp.Data;
using MyWebAPIApp.Interface;
using MyWebAPIApp.Models;
using MyWebAPIApp.Models.ViewModel;

namespace MyWebAPIApp.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private MyDBContext _context;

        public CategoryRepository(MyDBContext context) {
            _context = context;        
        }
        public CategoryVM Create(CategoryModel category)
        {
            var _new = new Category
            {
                CategoryName = category.CategoryName
            };
            _context.Add(_new);
            _context.SaveChanges();
            return new CategoryVM
            {
                CategoryID = _new.CategoryID,
                CategoryName = _new.CategoryName,
            };
        }

        public void Delete(int id)
        {
            var find = _context.categories.SingleOrDefault(c => c.CategoryID == id);
            if(find != null)
            {
                _context.Remove(find);
                _context.SaveChanges();
            }
        }

        public List<CategoryVM> GetAll()
        {
            var list = _context.categories.Select(c => new CategoryVM
            {
                CategoryID = c.CategoryID,
                CategoryName = c.CategoryName,
            });
            return list.ToList();
        }

        public CategoryVM GetById(int id)
        {
            var find = _context.categories.SingleOrDefault(c => c.CategoryID == id);   
            if (find != null)
            {
                return new CategoryVM { CategoryID = find.CategoryID, CategoryName = find.CategoryName };
            }
            return null;
        }

        public void Update(CategoryVM categoryVM)
        {
            var find = _context.categories.SingleOrDefault(c => c.CategoryID == categoryVM.CategoryID);
            categoryVM.CategoryName = find.CategoryName;
            _context.SaveChanges();
        }
    }
}
