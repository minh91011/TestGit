using Microsoft.AspNetCore.Mvc;
using MyWebAPI_FE_MVC.Models;
using Newtonsoft.Json;
using System.Text;

namespace MyWebAPI_FE_MVC.Controllers
{
    public class CategoryController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7145/api");
        private readonly HttpClient _client;
        public CategoryController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<CategoryViewModel> list = new List<CategoryViewModel>();   
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Category/GetAll").Result;
            
            if(response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                list = JsonConvert.DeserializeObject<List<CategoryViewModel>>(data);
            }
            return View(list);
        }

        [HttpGet]
        public IActionResult Create() 
        { 
            return View();
        }

        [HttpPost]
        public IActionResult Create(CategoryViewModel viewModel)
        {
            try
            {
                string data = JsonConvert.SerializeObject(viewModel);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = _client.PostAsync(_client.BaseAddress + "/Category/Add", content).Result;

                if (response.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "Category Created";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
            return View();
        }
    }
}
