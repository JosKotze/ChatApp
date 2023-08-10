using System;
using System.Collections.Generic;

namespace ChatApp.Models
{
    public class User
    {

        // prvate fields -> 
        private string username { get; set; }

        /*
        public List<Chatroom> ChatroomsList
        {
            get {return chatroomsList;}
            set {chatroomsList = value;}
        }
        */


        //Functions:
        static string GenerateUserID()
        {   // only called when registered. So where does that happen?

            Random random = new Random(); // PART 1: starts with 2 random letters
            string[] abc = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
            int i = random.Next(0, 26);
            int x = random.Next(0, 26);
            string part1 = abc[x] + abc[i];

            string part2 = DateTime.Now.Millisecond.ToString() + DateTime.Now.Second.ToString();
            // PART 2: Is a combination of numerical digits that are from milliseconds and then seconds

            Random random2 = new Random(); // PART 3: ends with 2 random letters
            int e = random.Next(0, 26);
            int y = random.Next(0, 26);
            string part3 = abc[e] + abc[y];

            string UserID = $"{part1}{part2}{part3}"; // string concatenation

            Console.WriteLine(UserID);
            return UserID;
        }

        public void EnterUserName()
        {

        }

        public void EnterRoomCode()
        {

        }

        public void DeleteRoom()
        {

        }
    }
}
