using CarController.Pages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using System.Data.SqlClient;

namespace CarController.Pages.Vehicles
{
    public class IndexModel : PageModel
    {
        public List<Vehicle> listVehicle = new List<Vehicle>();
        
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
                                Vehicle vehicleinfo = new Vehicle();
                                vehicleinfo.Name = reader.GetString(1);
                                vehicleinfo.Status = reader.GetString(2);
                                vehicleinfo.TotalKilometersReversed = reader.GetString(3);
                                vehicleinfo.TotalKilometersDriven = reader.GetString(4);

                                listVehicle.Add(vehicleinfo);
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

}
    
    // Vehicle.cs
    public class Vehicle
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public string TotalKilometersDriven { get; set; }
        public string TotalKilometersReversed { get; set; }
        // Other properties as needed
    }

