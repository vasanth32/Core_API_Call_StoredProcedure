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

        //string connString = _configuration.GetConnectionString("StudConnection");

        public List<Student> DataSource()
        {
            string connString = this._configuration.GetConnectionString("StudConnection");
            dynamic retuObj;

            try
            {


                using (SqlConnection con = new SqlConnection(connString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("EXEC studentEntryView"))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "View");
                    cmd.Parameters.AddWithValue("@fname", "");
                    cmd.Parameters.AddWithValue("@Mname", "");
                    cmd.Parameters.AddWithValue("@Lname", "");
                    cmd.Connection = con;

                    retuObj = cmd.ExecuteReader();
                    con.Close();
                }
            }
        }
            catch (Exception ex)
            {
                retuObj = new DataTable();
            }
        return retuObj;


}

        public List<Student> GetStudent()
        {
            List<Student> retu = new List<Student>();
            retu = DataSource();
            return retu;
        }
    }
}
