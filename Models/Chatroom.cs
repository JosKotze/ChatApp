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

        public void CreateRoom()
        {
            // get log.txt file from server and convert to list or array.

        }

        static string GenerateRoomJoinCode()
        {   // only called when registered. So where does that happen?

            Random random = new Random();
            string[] abc = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
            string q = abc[random.Next(0, 26)];
            string w = abc[random.Next(0, 26)];
            string e = abc[random.Next(0, 26)];
            string r = abc[random.Next(0, 26)];
            string t = abc[random.Next(0, 26)];
            string y = abc[random.Next(0, 26)];

            string part1 = q + w + e; // PART 1: starts with 3 random letters

            string part2 = ((DateTime.Now.Millisecond + DateTime.Now.Second) * 3).ToString(); // 3 random numbers

            string part3 = r + t + y; // PART 3: ends with 3 random letters

            string UserID = $"{part1}{part2}{part3}"; // string concatenation

            Console.WriteLine(UserID);
            return UserID;
        }
    }
}