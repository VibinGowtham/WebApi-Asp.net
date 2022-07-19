using System.ComponentModel.DataAnnotations;

namespace WebApplication4.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string? Name { get; set; }

        [StringLength(30)]
        public string? Branch { get; set; }

        public int Batch { get; set; }

        public int Age { get; set; }

        public Student(int id, string? name, string? branch, int batch, int age)
        {
            Id = id;
            Name = name;
            Branch = branch;
            Batch = batch;
            Age = age;
        }
    }
}
