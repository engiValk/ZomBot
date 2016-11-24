using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZomBot
{
    class PermissionManager
    {
        internal static void FileReader(string _authorID)
        {

            int counter = 0;
            string line;
            //Resets author Rank to User for it to check new ranks.
            AuthorObject.authorRank = "User";
            // Read the file and display it line by line.
            System.IO.StreamReader modCheck = new System.IO.StreamReader("mod.txt");
            while ((line = modCheck.ReadLine()) != null)
            {
                if (_authorID == line)
                {
                    AuthorObject.AuthorObj(_authorID, "moderator");
                }
                else
                {
                    counter++;
                }
            }

            modCheck.Close();

            System.IO.StreamReader serverCheck = new System.IO.StreamReader("server.txt");
            while ((line = serverCheck.ReadLine()) != null)
            {
                if (_authorID == line)
                {
                    AuthorObject.AuthorObj(_authorID, "server");
                }
                else
                {
                    counter++;
                }
            }

            serverCheck.Close();

            System.IO.StreamReader servmodCheck = new System.IO.StreamReader("servmod.txt");
            while ((line = servmodCheck.ReadLine()) != null)
            {
                if (_authorID == line)
                {
                    AuthorObject.AuthorObj(_authorID, "servmod");
                }
                else
                {
                    counter++;
                }
            }

            servmodCheck.Close();

            System.IO.StreamReader adminCheck = new System.IO.StreamReader("admin.txt");
            while ((line = adminCheck.ReadLine()) != null)
            {
                if (_authorID == line)
                {
                    AuthorObject.AuthorObj(_authorID, "admin");
                } else
                {
                    counter++;
                }
            }

            adminCheck.Close();
        }
    }
}
