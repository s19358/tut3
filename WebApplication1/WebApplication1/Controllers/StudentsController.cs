using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{   //it will return some data about student 
    //controller => return answer for request of clients

    [ApiController] //Annotation=> marks our controller as an API controller
    [Route("api/students")] //=> address
    public class StudentsController : ControllerBase //handling the req
    {

        private IDbService _dbService; //interfacei kullandigimiz icin bunu implement eden classlari kullanabilrz
        public StudentsController(IDbService dbService)
        {
            this._dbService = dbService;
        }

        [HttpGet]
        public IActionResult GetStudents(string orderby)
        {

            return Ok(_dbService.GetStudents());
        }


        /*
        [HttpGet] //if the req is get then this method will return answer
        public string GetStudents() //action method => responding user req
        {
            return "Ayse, Fatma, Hayriye";
        }
        */

        //there are several ways for passing data. 

        //2.passing the data by querystring
        /*
        [HttpGet] 
        public string GetStudents(string orderby) 
        {

           // var s = HttpContext.Request;
            return $"Ayse, Fatma, Hayriye sortBy={orderby}";
        }
        */

        //1.how to pass data using url segment
        //parameter icindeki ile 
        [HttpGet("{id}")]
        public IActionResult GetStudent(int id) //action method
        {
            if (id == 1)
            {
                return Ok("Ayse"); //200 ok

            }else if (id == 2)
            {
                return Ok("Fatma");
            }
            return NotFound("no student found"); //404
        }

        //3.pssing data using body (usually post)
        [HttpPost]   //usually used to create new elements
        public IActionResult createStudent(Student student) //burdaki ogrenci ve bilgileri disardan post req ile geliyor
        {                                                   //buraya geliyor ve data otomatik deserialize oluyor?

            student.indexnumber = $"s{new Random().Next(1,20000)}";
            //save into db
            return Ok(student);
        }

        //httpput=> replace the resource
        //httpdelete=>remove the resource

        Student student = new Student();

        [HttpPut("{id}")]
        public IActionResult PutStudent(int id)
        {

            student.IdStudent = id;
            return Ok("Update completed");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {     
            if (student.IdStudent == id)
            {
                student = null;
            }
            return Ok("Delete completed");
        }


    }
}