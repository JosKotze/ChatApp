using System.Security.Cryptography;
using System.Text;

namespace ChatApp.Models
{
    public class Security
    {

        public static bool ValidateUser(string username)
        {

            // check if user in database

            //if valid
            return true;
            //else return false;
        }

        public static string HashPassword(string password)
        {
            /// call this when register
            string hashedPassword;
            using (var sha256 = new SHA256Managed())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                hashedPassword = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
                return hashedPassword;
            }
        }

        public static bool Login(string username, string password)
        {
            if (!ValidateUser(username))
            {
                // some message like user does not exist in db
            }
            else if (!ValidateUser(password))
            {
                // incorrect password
            }


            return true;
        }

        public static bool ValidatePassword(string loginPassword, string hashedPassword)
        {
            // not sure how this will work
            // get hashed password from db.
            // call HashPassword(loginPassword)
            // compare the two. if not same return false. if same return true

            //if valid
            return true;
        }

    }
}