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
    public class AllocationController : ControllerBase
    {
        private readonly LibraryContext _con;
        public AllocationController(LibraryContext con)
        {
            _con = con;
        }
        // GET: api/<AllocationController>
        [HttpGet]
        public IEnumerable<Allocation> Get()
        {
            return _con.allocations.ToList();
        }

        // GET api/<AllocationController>/5
        [HttpGet("{id}")]
        public Allocation Get(int id)
        {
            return _con.allocations.Find(id);
        }

        // POST api/<AllocationController>
        [HttpPost]
        public void Post([FromBody] Allocation obj)
        {
            _con.allocations.Add(obj);
            _con.SaveChanges();
        }

        // PUT api/<AllocationController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Allocation ob)
        {
            var obj = _con.allocations.Find(id);
            if(obj!=null)
            {
                obj.bookid = ob.bookid;
                obj.studentid = ob.studentid;
                _con.Update(obj);
                _con.SaveChanges();
            }
        }

        // DELETE api/<AllocationController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var obj = _con.allocations.Find(id);
            _con.allocations.Remove(obj);
            _con.SaveChanges();
        }
    }
}
