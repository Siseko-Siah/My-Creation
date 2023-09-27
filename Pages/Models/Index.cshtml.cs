using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using Microsoft.AspNetCore.SignalR;

namespace CarController.Pages.Models
{
    public class IndexModel : PageModel
    {
  
        public List<ModelsInfo> listModels = new List<ModelsInfo>();
        public void OnGet()
        {
            try
            {
                String connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Vehicles;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustSer";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "SELECT * FROM Models";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ModelsInfo makeinfo = new ModelsInfo();
                                makeinfo.ModelName = reader.GetString(1);
                                makeinfo.ModelID = reader.GetString(2);

                                listModels.Add(makeinfo);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    public class ModelsInfo
    {

        public String ModelName;
        public String ModelID;


    }
}
