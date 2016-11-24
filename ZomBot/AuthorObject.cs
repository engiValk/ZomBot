using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZomBot
{
    class AuthorObject
    {
        public static string authorRank;
        internal static void AuthorObj(string _authorID, string _authorRank)
        {
            string authorID = _authorID;
            authorRank = _authorRank;
            Console.WriteLine(authorRank);
        }
    }
}
