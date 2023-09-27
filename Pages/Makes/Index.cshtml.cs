using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using Microsoft.AspNetCore.SignalR;

namespace CarController.Pages.Makes
{
    public class IndexModel : PageModel
    {
        public List<MakesInfo> listMakes = new List<MakesInfo>();
        public void OnGet()
        {
            try
            {
                String connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Vehicles;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "SELECT * FROM Makes";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                MakesInfo makeinfo = new MakesInfo();
                                makeinfo.MakeName = reader.GetString(1);
                                makeinfo.MakeID = reader.GetString(2);
                               
                                listMakes.Add(makeinfo);
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

    public class MakesInfo
    {
       
        public  String MakeName;
        public  String MakeID;
        
        
    }
}
