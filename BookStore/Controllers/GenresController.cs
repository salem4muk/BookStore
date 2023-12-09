using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    public class GenresController : Controller
    {
        // GET: GenresController
        public ActionResult Index()
        {
            return View();
        }

        // GET: GenresController/Create
        public ActionResult Create()
        {
            return View();
        }

        // GET: GenresController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewData["id"] = id;
            return View();
        }

    }
}
