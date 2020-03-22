using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public interface IDbService
    {
        //enumerable => always good to use abstraction 
        // butun collectionlari kapsadigi icin daha kullanisli
        //istedgimiz collection turunu kullanabilirz boylece
        public IEnumerable<Student> GetStudents(); 
    }
}
