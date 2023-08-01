using System;
using System.Collections.Generic;

namespace ChatApp.Models
{
    public class User
    {

        // prvate fields -> 
        private string userID;
        private string username;
        private string password;

        // getters and setters
        public string UserID
        {
            get { return userID; }
            set { userID = value; }
        }

        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }


        /*
        public List<Chatroom> ChatroomsList
        {
            get {return chatroomsList;}
            set {chatroomsList = value;}
        }
        */


        //Functions:


        public static string GenerateUserID()
        {
            Random random = new Random();
            string[] abc = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
            int i = random.Next(0, 26);
            int x = random.Next(0, 26);

            // only called when registered. So where does that happen?

            string part1 = abc[x] + abc[i];
            string part2 = DateTime.Now.Ticks.ToString();
            int part3 = random.Next(1000, 10000);
            string uniqueID = $"{part2}{part3}";
            string UserID = part1 + uniqueID.Substring(0, 6);
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
