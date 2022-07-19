using Microsoft.AspNetCore.Mvc;
using WebApplication4.Models;

namespace WebApplication4.Controllers {

    [ApiController]
    [Route("getDetails")]
    public class UserController : ControllerBase
    {
       
        [Route("")]
        public List<Student> getAll()
        {
            Student obj = new Student(1, "Vibin", "Cse", 2022, 22);
            Student obj1 = new Student(2, "Gowtham", "Mech", 2021, 23);
            Student obj2 = new Student(3, "Akash", "Cse", 2020, 24);

            List<Student> students = new List<Student>();
            students.Add(obj1);
            students.Add(obj2);
            students.Add(obj);
            return students;
        }

        [Route("{id}")]
        public Student? getDetails(int id)
        {
          

            List<Student> students = getAll();
       
            
            foreach(Student student in students)
            {
                if (student.Id == id) return student;

            }

            return null;
        }


    }
}
