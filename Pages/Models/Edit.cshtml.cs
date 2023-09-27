using CarController.Pages.Makes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace CarController.Pages.Models
{
    public class EditModel : PageModel
    {

        public ModelsInfo modelInfo = new ModelsInfo();
        public String errorMessage = "";
        public String successMessage = "";
        public void OnGet()
        {
            String ModelID = Request.Query["ID"];

            try
            {
                String connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Vehicles;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "SELECT * FROM Models WHERE ModelID=@ModelID ";
                    using (SqlCommand cmd = new SqlCommand(sql, connection))
                    {

                        cmd.Parameters.AddWithValue("@ModelID", ModelID);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                ModelsInfo modelinfo = new ModelsInfo();
                                modelinfo.ModelName = reader.GetString(1);
                                modelinfo.ModelID = reader.GetString(2);

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
            modelInfo.ModelID = Request.Form["ID"];
            modelInfo.ModelName = Request.Form["Name"];

            try
            {
                String connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Vehicles;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "UPDATE Models" +
                        "SET ModelID=@ModelID, ModelName=@ModelName" +
                        "WHERE ModelID=@ModelID";
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
