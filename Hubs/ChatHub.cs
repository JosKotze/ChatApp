using Microsoft.AspNetCore.SignalR;
using ChatApp.Controllers;
using Serilog;
using ChatApp.Models;

namespace ChatApp.Hubs
{

    public class ChatHub : Hub
    {
        private readonly ILogger<ChatHub> _messageLogger;
        private readonly ILogger<ChatHub> _errorLogger;

        public ChatHub(ILogger<ChatHub> messageLogger, ILogger<ChatHub> errorLogger)
        {
            _messageLogger = messageLogger;
            _errorLogger = errorLogger;
            // injecting logger instances into constructor.
        }

        public async Task SendMessage(string user, string message)
        {
            try
            {
                Message chat = new Message(user, message);
                chat.Username = user;
                chat.Content = message;

                // Simulate an error by throwing a custom exception
                //throw new Exception("Intentional error for testing purposes");
                // << TO TEST ERROR LOG >>

                await Clients.All.SendAsync("ReceiveMessage", chat.Username, chat.Content);
                //sends object to javascript
                _messageLogger.LogInformation("{User}: {Message}", chat.Username, chat.Content);
            }
            catch (Exception ex)
            {
                _errorLogger.LogError(ex, "Error sending message.");
            }

        }
    }
}





