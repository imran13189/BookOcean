using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookOcean.Domain;
using BookOcean.Repository.Abstract;

namespace BookOcean.Web.Controllers
{
    
    public class BookSetController : Controller
    {

        private IBookSet _bookset;
       public BookSetController(IBookSet bookset)
        {
            this._bookset = bookset;
        }
        // GET: BookSet
        public ActionResult Index()
        {
            _bookset.GetBook();
            return View(_bookset.GetBookByStandard(1));
        }
    }
}