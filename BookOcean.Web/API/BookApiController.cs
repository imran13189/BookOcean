using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BookOcean.Repository.Abstract;
using BookOcean.Domain;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BookOcean.Web.API
{


    public class BookAPIController : ApiController
    {
        IBook _book;
        public BookAPIController(IBook book)
        {
            this._book = book;
        }

        public List<Book> GetBook(JObject data)
        {
            return _book.GetBooks();
        }
    }
}
