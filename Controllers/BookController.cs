using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryApp.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LibraryApp.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly LibraryContext _con;
        public BookController(LibraryContext con)
        {
            _con = con;
        }
        // GET: api/<BookController>
        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return _con.books.ToList();
        }

        // GET api/<BookController>/5
        [HttpGet("{id}")]
        public Book Get(int id)
        {
            return _con.books.Find(id);
        }

        // POST api/<BookController>
        [HttpPost]
        public void Post([FromBody] Book obj)
        {
            _con.books.Add(obj);
            _con.SaveChanges();
        }

        // PUT api/<BookController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Book ob)
        {
            var obj = _con.books.Find(id);
            if(obj!=null)
            {
                obj.ISBN = ob.ISBN;
                obj.name = ob.name;
                obj.publication = ob.publication;
                obj.quantity = ob.quantity;
                _con.Update(obj);
                _con.SaveChanges();
            }
        }

        // DELETE api/<BookController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var obj = _con.books.Find(id);
            _con.books.Remove(obj);
            _con.SaveChanges();
        }
    }
}
