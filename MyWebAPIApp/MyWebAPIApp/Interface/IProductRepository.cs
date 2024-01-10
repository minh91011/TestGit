using MyWebAPIApp.Models;

namespace MyWebAPIApp.Interface
{
    public interface IProductRepository
    {
        List<ProductInfo> GetAllProducts(string search, double? from, double? to, string? sort, int page = 1);
    }
}
