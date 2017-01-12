using System.Configuration;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace test.DevTestHub
{
    public class DevTestHubs : Hub
    {
        private static string conString = ConfigurationManager.ConnectionStrings["DbTestContext"].ToString();

        public void Hello()
        {
            Clients.All.hello();
        }

        [HubMethodName("sendMessages")]
        public static void SendMessages()
        {
            IHubContext context = GlobalHost.ConnectionManager.GetHubContext<DevTestHubs>();
            context.Clients.All.updateMessages();
        }
    }
}