using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyWebAPIApp.Data;
using MyWebAPIApp.Interface;
using MyWebAPIApp.Models;

namespace MyWebAPIApp.Repository
{
    public class ProductRepository : IProductRepository
    {
        private MyDBContext _context;
        public static int pagesize { get; set; } = 5;

        public ProductRepository(MyDBContext context)
        {
            _context = context;
        }
        public List<ProductInfo> GetAllProducts(string search, double? from, double? to, string? sort, int page = 1)
        {
            var list = _context.products.Include(p => p.Category).AsQueryable();


            //filter search
            if (!string.IsNullOrEmpty(search))
            {
                list = list.Where(p => p.ProductName.Contains(search));
            }
            if (from.HasValue)
            {
                list = list.Where(p => p.Price >= from);
            }
            if (to.HasValue)
            {
                list = list.Where(p => p.Price <= to);
            }


            ////filter sort
            list = list.OrderBy(p => p.ProductName);
            if (!string.IsNullOrEmpty(sort))
            {
                switch (sort)
                {
                    case "Name_desc":
                        list = list.OrderByDescending(p => p.ProductName);
                        break;
                    case "Price_desc":
                        list = list.OrderByDescending(p => p.Price);
                        break;
                    case "Price_asc":
                        list = list.OrderBy(p => p.Price);
                        break;
                }
            }

            //Paging
            //list = list.Skip((page - 1)*pagesize).Take(pagesize);
            //var result = list.Select(p => new ProductInfo
            //{
            //    ProductId = p.ProductId,
            //    ProductName = p.ProductName,
            //    Price = p.Price,
            //    CategoryName = p.Category.CategoryName
            //});

            //return result.ToList();

            var result = PaginatedList<Product>.Create(list, page, pagesize);
            return result.Select(p => new ProductInfo
            {
                ProductId = p.ProductId,
                ProductName = p.ProductName,
                Price = p.Price,
                CategoryName = p.Category.CategoryName
            }).ToList();
        }

    }
}
