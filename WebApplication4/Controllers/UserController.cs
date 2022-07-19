using Microsoft.AspNetCore.Mvc;
using WebApplication4.Models;

namespace WebApplication4.Controllers {

    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
       private  StudentDBContext studentDBContext;

       public UserController(StudentDBContext studentDBContext)
        {
            this.studentDBContext = studentDBContext;
        }

        [Route("getAll")]
        public List<Student> getAll()
        {
          return  studentDBContext.Students.ToList();
        }

        [Route("{id}")]
        public Student? getDetails(int id)
        {
            return (Student?)studentDBContext.Students.Where(student => student.Id==id);  
        }


        [HttpPost("add")]
        public Student? saveStudent(Student student)
        {
            studentDBContext.Students.Add(student);
            studentDBContext.SaveChanges();
            return student;

        }

        [HttpPost("update")]
        public string updateStudent(Student student)
        {
            try
            {
                studentDBContext.Students.Update(student);
                studentDBContext.SaveChanges();
                return "Update Successfull";
            }
        catch(Exception e)
            {
                return "User Not Found";
            }

        }

        [HttpPost("delete")]
        public string deleteStudent(Student obj)
        {
       
              var student =  studentDBContext.Students.Find(obj.Id);
                if (student != null)
                {
                    studentDBContext.Students.Remove(student);
                    studentDBContext.SaveChanges();
                return "Deleted Successfully";
                }
                else return "User Not Found";    
        }
    }
}
