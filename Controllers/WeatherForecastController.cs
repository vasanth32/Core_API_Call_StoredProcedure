using API1.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace API1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IStudentRepository _repository = null;
        private readonly StudentDbContext _db;
        public WeatherForecastController(IStudentRepository studentRepository, StudentDbContext studentDbContext)
        {   
            _db = studentDbContext;
            _repository = studentRepository;
        }
        [HttpGet]
        public List<Student> GetAll()
        {
            List<Student> list;
            string sql = "EXEC studentEntryView @Action,@fname,@Mname,@Lname";
            string action = "View";
            string tmp = "";

            List<SqlParameter> parms = new List<SqlParameter>
             {
                 // Create parameter(s)    
                 new SqlParameter { ParameterName = "@Action", Value = action },
                 new SqlParameter { ParameterName = "@fname", Value = tmp },
                 new SqlParameter { ParameterName = "@Mname", Value = tmp },
                 new SqlParameter { ParameterName = "@Lname", Value = tmp }
             };
            list = _db.Students.FromSqlRaw<Student>(sql, parms.ToArray()).ToList();

            //list = _db.Students.FromSqlRaw<Student>(sql).ToList();
            return list;
        }

            //        Create procedure[dbo].[studentEntryView]
            //        (
            //@Action varchar (10),    
            //@fname Varchar(50),    
            //@Mname varchar(50),    
            //@Lname Varchar(50)
            //)    
            //as    
            //begin
            //If @Action='Insert'   --used to insert records
            //Begin
            //Insert into Student(id, Fname, MName, Lastname) values('1','tes','tes','t')
            //End    
            //else if @Action='View'   --used to view records
            //Begin
            //select* from Student
            //End
            //End


        //[HttpPost]
        //public IActionResult GetStudentDetails(int Id)
        //{
        //    //TestStudentRepository repository = new TestStudentRepository();
        //    //Student studentDetails = repository.GetStudentById(Id);
        //    //return Ok(studentDetails);
        //    Student studentDetails = _repository.GetStudentById(Id);
        //    return Ok(studentDetails);
        //}
    }
}
