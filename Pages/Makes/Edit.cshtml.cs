using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace CarController.Pages.Makes
{
    public class EditModel : PageModel
    {
        public MakesInfo makesInfo = new MakesInfo();
        public String errorMessage = "";
        public String successMessage = "";
        public void OnGet()
        {
            String MakeID = Request.Query["ID"];

            try
            {
                String connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Vehicles;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "SELECT * FROM Makes WHERE MakeID=@MakeID ";
                    using (SqlCommand cmd = new SqlCommand(sql, connection))
                    {

                        cmd.Parameters.AddWithValue("@MakeID", MakeID);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                MakesInfo makeinfo = new MakesInfo();
                                makeinfo.MakeName = reader.GetString(1);
                                makeinfo.MakeID = reader.GetString(2);

                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }
        }
        public void OnPost()
        {
            makesInfo.MakeID = Request.Form["ID"];
            makesInfo.MakeName = Request.Form["Name"];

            try
            {
                String connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Vehicles;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "UPDATE Makes" +
                        "SET MakeID=@MakeID, MakeName=@MakeName" +
                        "WHERE MakeID=@MakeID";
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
