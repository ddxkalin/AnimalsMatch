namespace Pets.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Diagnostics;
    using Web.Models;

    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

    //    public IActionResult Index()
    //    {
    //    var client = new RestClient("https://api.predicthq.com/v1/events/");
    //    client.AddDefaultHeader("Authorization", "Bearer ZN79Mw9lMMWGgNMDSA3NwO5MpoczZI");
    //    client.AddDefaultHeader("Accept", "application/json");
    //    var restRequest = new RestRequest();
    //    restRequest.AddQueryParameter("category", "festivals");
    //    restRequest.AddQueryParameter("label", "movie");
    //    restRequest.AddQueryParameter("q", "film");
    //    restRequest.AddQueryParameter("offset", "4");
    //    var response = client.Get(restRequest);
    //    var movieFestivalsList = new List<MovieFestival>();

    //        try
    //    {
    //        if (response.IsSuccessful)
    //        {
    //            var results = JsonConvert.DeserializeObject<MovieFestivalsResult>(response.Content);
    //            movieFestivalsList = results.Results;
    //        }
    //    }
    //    catch
    //    {
    //    }

    //    return this.View(movieFestivalsList);
    //}

    //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    //public IActionResult Error() => this.View();
    //}
}