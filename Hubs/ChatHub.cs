using Microsoft.AspNetCore.SignalR;

namespace ChatApp.Hubs
{

 // SignalR hub defined and named ChatHub, which will handle real-time communication.
 public class ChatHub : Hub
    {
        // method to send message from a user to all connected clients.
        public async Task SendMessage(string user, string message)
        {
            // Send received message to all connected clients.
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}





