using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace API1.Model
{
    public class TestStudentRepository : IStudentRepository
    {
        private IConfiguration _configuration;

        public TestStudentRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        //public List<Student> DataSource()
        //{
        //    string connString = this._configuration.GetConnectionString("StudConnection");

        //    using (SqlConnection con = new SqlConnection(connString))
        //    {
        //        using (SqlCommand cmd = new SqlCommand("studentEntryView"))
        //        {
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.AddWithValue("@Action", "View");
        //            cmd.Parameters.AddWithValue("@name", "");
        //            cmd.Parameters.AddWithValue("@branch", "");
        //            cmd.Parameters.AddWithValue("@section", "");
        //            cmd.Parameters.AddWithValue("@gender", "");
        //            cmd.Connection = con;
        //            con.Open();
        //            var stud = cmd.ExecuteReader();
        //            con.Close();
        //        }
        //    }

        //    //SqlConnection  _sqlConnection = new SqlConnection(connString);
        //    //SqlCommand _sqlCommand = new SqlCommand();

        //    //_sqlConnection.Open();

        //    //_sqlCommand.CommandText = "dbo.studentEntryView";
        //    //_sqlCommand.CommandType = CommandType.StoredProcedure;
        //    //_sqlCommand.Parameters.AddWithValue("@Action", "View");
        //    //_sqlCommand.Parameters.AddWithValue("@name", "");
        //    //_sqlCommand.Parameters.AddWithValue("@branch", "");
        //    //_sqlCommand.Parameters.AddWithValue("@section", "");
        //    //_sqlCommand.Parameters.AddWithValue("@gender", "");

        //    //var res = _sqlCommand.ExecuteReader();

        //    //SqlDataAdapter _sqlDataAdapter = new SqlDataAdapter(_sqlCommand);



        //    return new List<Student>()
        //    {
        //        new Student() { StudentId = 101, Name = "James", Branch = "CSE", Section = "A", Gender = "Male" },
        //        new Student() { StudentId = 102, Name = "Smith", Branch = "ETC", Section = "B", Gender = "Male" },
        //        new Student() { StudentId = 103, Name = "David", Branch = "CSE", Section = "A", Gender = "Male" },
        //        new Student() { StudentId = 104, Name = "Sara", Branch = "CSE", Section = "A", Gender = "Female" },
        //        new Student() { StudentId = 105, Name = "Pam", Branch = "ETC", Section = "B", Gender = "Female" }
        //    };
        //}


        //public Student GetStudentById(int StudentId)
        //{
        //    return DataSource().FirstOrDefault(e => e.StudentId == StudentId);
        //}
    }
}
