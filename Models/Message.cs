namespace ChatApp.Models
{
    public class Message
    {
        public string SenderID { get; set; }
        public string Content { get; set; }
        public DateTime Timestamp { get; set; }


        // Constructor
        public Message(string senderID, string content)
        {
            SenderID = senderID;
            Content = content;
            Timestamp = DateTime.Now;
        }


        //function:

        public static void LogChat()
        {
            // need to figure out structure of log and then save it to text file on server.

            // <<<== Example of log structure ==>>>
            //  Room   | username | timestampt  | message
            //  Room104, bob,       201101011029, hi
            //  Room104, jen,       201101011030, how are you?
            //  Room104, bob,       201101011030, fine thanks.
            //  Room104, jannie,    201101021203, what time do you call this?
            //

        }
    }
}
