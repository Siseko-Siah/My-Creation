using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace CarController.Pages.Models
{
    public class CreateModel : PageModel
    {
       
        public ModelsInfo modelInfo = new ModelsInfo();
        public string errorMessage = "";
        public void OnGet()
        {

        }

        public void OnPost()
        {
            modelInfo.ModelName = Request.Form["ModelName"];
            modelInfo.ModelID = Request.Form["ModelID"];

            try
            {
                String connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Vehicles;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "INSERT INTO Model " +
                                 "(ModelId, ModelName)" +
                                 "(@ModelID, @ModelName)";

                    using (SqlCommand cmd = new SqlCommand(sql, connection))
                    {

                        cmd.Parameters.AddWithValue("@ModelID", modelInfo.ModelID);
                        cmd.Parameters.AddWithValue("@ModelName", modelInfo.ModelName);

                        cmd.ExecuteNonQuery();
                    }

                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return;
            }

            Response.Redirect("/Models/Index");

        }

    }
}
