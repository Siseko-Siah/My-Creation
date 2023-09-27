using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace CarController.Pages.Makes
{
    public class CreateModel : PageModel
    {
        public MakesInfo makesInfo = new MakesInfo();
        public string errorMessage = "";
        public void OnGet()
        {

        }

        public void OnPost()
        {
            makesInfo.MakeName = Request.Form["MakeName"];
            makesInfo.MakeID = Request.Form["MakeID"];

            try
            {
                String connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Vehicles;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                using(SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "INSERT INTO Makes " +
                                 "(MakeId, MakeName)" +
                                 "(@MakeID, @MakeName)";

                    using (SqlCommand cmd = new SqlCommand(sql, connection))
                    {

                        cmd.Parameters.AddWithValue("@MakeID", makesInfo.MakeID);
                        cmd.Parameters.AddWithValue("@MakeName", makesInfo.MakeName);

                        cmd.ExecuteNonQuery();
                    }

                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return;
            }

            Response.Redirect("/Makes/Index");
            
        }

    }
}
