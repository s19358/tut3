using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class MockDbService : IDbService
    {
        private static IEnumerable<Student> _students;

        static MockDbService() //static olmasinin sebebi prog calisinca direk olusmasi icin
        {
            _students = new List<Student>
            {
                new Student{IdStudent=1 ,fname="ayse" ,lname="ozgur" ,indexnumber="s19358"},
                 new Student{IdStudent=2 ,fname="rey" ,lname="ozgur" ,indexnumber="s11111"},
                  new Student{IdStudent=3 ,fname="bil" ,lname="ozgur" ,indexnumber="s22222"}
            };
        }
        public IEnumerable<Student> GetStudents()
        {
            return _students;
        }
    }
}
