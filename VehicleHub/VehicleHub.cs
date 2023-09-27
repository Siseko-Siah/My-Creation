
using Microsoft.AspNetCore.SignalR;
namespace CarController.VehicleHub
{
    public class VehicleHub
    {

        
        private static readonly int[] SimulatedData = new int[4];

        public void SendRealTimeData()
        {
            
            for (var i = 0; i < SimulatedData.Length; i++)
            {
                SimulatedData[i] = SimulatedData[i] + getRandomIncrement();
            }

           
        }

        private static int getRandomIncrement()
        {
            var random = new Random();
            return random.Next(1, 10);
        }
    }
}
