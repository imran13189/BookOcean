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
using BookOcean.Domain.Common;

namespace BookOcean.Web.API
{

    public class BookFilter : DataObject
    {
        public string BookName { get; set; }
    }
    public class BookDetail
    {
        public List<Book> data;
        public int count;
    }

    public class BookAPIController : ApiController
    {
        IBook _book;
        public BookAPIController(IBook book)
        {
            this._book = book;
        }
        [HttpPost]
        public dynamic GetBooks(BookFilter model)
        {

            BookDetail re = new BookDetail();
            re.data = _book.GetBooks(model.limit,model.offset,model.order,model.BookName);
            
            return new { rows = re.data, total = re.data.First().CountOrders };
            //return new List<Book>();
        }
    }
}
