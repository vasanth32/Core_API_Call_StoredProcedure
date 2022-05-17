using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API1.Model
{
    public interface IStudentRepository
    {
        //Student GetStudentById(int StudentId);
        List<Student> GetStudent();
    }
}
