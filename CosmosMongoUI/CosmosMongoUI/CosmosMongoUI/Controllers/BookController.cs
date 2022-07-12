
using CosmosMongoUI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CosmosMongoUI.Controllers
{
  
    public class BookController : Controller
    {
        private readonly ILogger _logger;
        private readonly IConfiguration _configuration;
        private readonly string apiBaseUrl;
        private readonly IHttpClientFactory _clientFactory;

      

        public BookController(ILogger<HomeController> logger, IConfiguration configuration, IHttpClientFactory factory)
        {
            _logger = logger;
            _configuration = configuration;

            apiBaseUrl = _configuration.GetValue<string>("WebAPIBaseUrl");
            _clientFactory = factory;


        }
        public async Task<IActionResult> Index()
        
        
        {
            var httpClient = _clientFactory.CreateClient("restapiclient");
            string apiUrl = apiBaseUrl + "/Books";
            HttpResponseMessage httpResponse = await httpClient.GetAsync(apiUrl);
            List<Book> books = new List<Book>();
            var responseData = await httpResponse.Content.ReadAsStringAsync();
            books = JsonConvert.DeserializeObject<List<Book>>(responseData);

            return View(books);
        }
        // GET: BookController
        //public async Task<IActionResult> Index()
        //{

        //    // StringContent content = new StringContent(JsonContent.SerializeObject(user), System.Text.Encoding.UTF8, "application/json");
        //    string apiUrl = apiBaseUrl + "/Book";




        //    _client.BaseAddress = new Uri(apiUrl);
        //    _client.DefaultRequestHeaders.Accept.Clear();
        //    _client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

        //    HttpResponseMessage response = await _client.GetAsync(apiUrl);
        //    if (response.IsSuccessStatusCode)
        //    {
        //        var data = await response.Content.ReadAsStringAsync();
        //        var table = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Data.DataTable>(data);

        //    }
        

                
        //        return View();
        //    }
        

        // GET: BookController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BookController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BookController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BookController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BookController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BookController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BookController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
