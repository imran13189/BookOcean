using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookOcean.Repository.Abstract;
using BookOcean.Domain;

namespace BookOcean.Web.Controllers
{
    public class BookController : Controller
    {
        IBook _book;

        public BookController (IBook book)
        {
            this._book = book;
        }
        // GET: Book
        public ActionResult Index()
        {
            return View();
        }



        public ActionResult AddBook()
        {
            return View();
        }




        [HttpPost]
        public ActionResult AddBook(Book model )
        {
           return View();
        }


    }
}