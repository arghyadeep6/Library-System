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
    public class StudentController : ControllerBase
    {
        private readonly LibraryContext _con;
        public StudentController(LibraryContext con)
        {
            _con = con;
        }
        // GET: api/<StudentController>
        [HttpGet]
        public IEnumerable<Student> Get()
        {
            return _con.students.ToList();
        }

        // GET api/<StudentController>/5
        [HttpGet("{id}")]
        public Student Get(int id)
        {
            return _con.students.Find(id);
        }

        // POST api/<StudentController>
        [HttpPost]
        public void Post([FromBody] Student obj)
        {
            _con.students.Add(obj);
            _con.SaveChanges();
        }

        // PUT api/<StudentController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Student ob)
        {
            var obj = _con.students.Find(id);
            if(obj!=null)
            {
                obj.cls = ob.cls;
                obj.name = ob.name;
                obj.phno = ob.phno;
                _con.Update(obj);
                _con.SaveChanges();
            }
        }

        // DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var obj = _con.students.Find(id);
            _con.students.Remove(obj);
            _con.SaveChanges();
        }
    }
}
