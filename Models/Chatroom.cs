namespace ChatApp.Models
{
    public class Chatroom
    {
        public string ChatroomName { get; set; }
        public string ChatroomID { get; set; }
        public string JoinCode { get; set; }
        public string DateCreated { get; set; }
        public string CreatorID { get; set; }
        public string logFileName { get; set; }

        //public List<Log> ChatHistory { get; set; }

        // Constructor
        public Chatroom()
        {
            //ChatHistory = new List<Message>();
        }

        // Methods

        // :)

        public void createLogFile()
        {

            // Create text file if !exists

        }
        public void GetChatLog()
        {
            // get log.txt file from server and convert to list or array.

        }
    }
}