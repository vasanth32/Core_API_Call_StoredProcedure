using API1.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using Microsoft.Extensions.Configuration;

namespace API1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IStudentRepository _repository = null;
        private readonly StudentDbContext _db;
        private IConfiguration _configuration;

        public WeatherForecastController(IConfiguration configuration,IStudentRepository studentRepository, StudentDbContext studentDbContext)
        {   
            _db = studentDbContext;
            _repository = studentRepository;
            _configuration = configuration;
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


        [HttpPost]
        public IActionResult GetStudentDetails()
        {
            string connString = this._configuration.GetConnectionString("StudConnection");
            
            List<Student> ret = new List<Student>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connString))
                {

                    //Create the command object
                    SqlCommand cmd = new SqlCommand()
                    {
                        CommandText = "studentEntryView",
                        Connection = connection,
                        CommandType = CommandType.StoredProcedure
                    };
                    //Set SqlParameter
                    SqlParameter param1 = new SqlParameter
                    {
                        ParameterName = "@Action", //Parameter name defined in stored procedure
                        SqlDbType = SqlDbType.VarChar, //Data Type of Parameter
                        Value = "View", //Value passes to the paramtere
                        Direction = ParameterDirection.Input //Specify the parameter as input
                    };
                    SqlParameter param2 = new SqlParameter
                    {
                        ParameterName = "@fname", //Parameter name defined in stored procedure
                        SqlDbType = SqlDbType.VarChar, //Data Type of Parameter
                        Value = "", //Value passes to the paramtere
                        Direction = ParameterDirection.Input //Specify the parameter as input
                    };
                    SqlParameter param3 = new SqlParameter
                    {
                        ParameterName = "@Mname", //Parameter name defined in stored procedure
                        SqlDbType = SqlDbType.VarChar, //Data Type of Parameter
                        Value = "", //Value passes to the paramtere
                        Direction = ParameterDirection.Input //Specify the parameter as input
                    };
                    SqlParameter param4 = new SqlParameter
                    {
                        ParameterName = "@Lname", //Parameter name defined in stored procedure
                        SqlDbType = SqlDbType.VarChar, //Data Type of Parameter
                        Value = "", //Value passes to the paramtere
                        Direction = ParameterDirection.Input //Specify the parameter as input
                    };
                    //add the parameter to the SqlCommand object
                    cmd.Parameters.Add(param1);
                    cmd.Parameters.Add(param2);
                    cmd.Parameters.Add(param3);
                    cmd.Parameters.Add(param4);
                    connection.Open();
                    dynamic retuObj = cmd.ExecuteReader();
                    while (retuObj.Read())
                    {
                        Student obk = new Student()
                        {
                            Fname = retuObj["Fname"],
                            id = retuObj["id"],
                            Lastname = retuObj["Lastname"],
                            MName = retuObj["MName"],
                        };
                        ret.Add(obk);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("OOPs, something went wrong.\n" + e);
            }
            return Ok(ret);

        }
    }
}
