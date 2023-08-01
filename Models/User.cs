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

        public void GenerateUserID()
        {

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
