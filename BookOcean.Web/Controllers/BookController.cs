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
            //_book.GetBooks();
            return View();
        }



        public ActionResult AddBook()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult AddBook(Book model)
        {
            _book.AddBook(model);
            //return RedirectToAction("AddBook");

            return View();
        }




        public ActionResult BindData()
        {
             
               
            return View(_book.GetBookBindData());
        } 


        public ActionResult Edit(int id)
        {

            Book book = _book.GetBook(id);
                return View(book);
            
        }
        [HttpPost]
        public ActionResult Edit(Book book)
        {
            //if(ModelState.IsValid)
            //{

            //this.entities.Entry(book).State= System.Data.EntityState.Modified;
            //db.SaveChanges();
            //return RedirectToAction("AddBook");
            //}
            //_book.EditBook(book);
            return View(_book.EditBook(book));

        }

        public ActionResult Delete(int id)
        {
            //Book book = this.ent.Books.Find(id);
            //db.Books.Remove(book);
           // db.SaveChanges();
            return View();
        }

        
    }
}