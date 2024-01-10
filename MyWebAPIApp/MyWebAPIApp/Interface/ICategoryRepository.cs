using MyWebAPIApp.Models;
using MyWebAPIApp.Models.ViewModel;

namespace MyWebAPIApp.Interface
{
    public interface ICategoryRepository
    {
        //GetAll
        List<CategoryVM> GetAll();
        CategoryVM GetById(int id);
        CategoryVM Create(CategoryModel category);
        void Update(CategoryVM categoryVM);
        void Delete(int id);
    }
}
