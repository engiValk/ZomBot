using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
namespace ZomBot
{
    class Command
    {
        internal static void CommandController(DiscordClient _client, Channel _channel , string message, string _authorID, User _user)
        {
            ////Checks if the first character is a ! which denotes it being a command.
            if (string.IsNullOrEmpty(message)) return;
            if (message[0] == '!')
            {
                //Splits the string (message) into each word and stores into an array.
                var SplitString = message.Split(' ');
                Console.WriteLine("I saw and split the message correctly! See:" + SplitString[0]);
                PermissionManager.FileReader(_authorID);
                if (SplitString.Length >= 2)
                {
                    if (AuthorObject.authorRank == "admin")
                    {
                        AdminCommandDefinitions.CommandList(SplitString[0], _channel, _client, _user ,SplitString[1]);
                    } if (AuthorObject.authorRank == "moderator" || AuthorObject.authorRank == "admin" || AuthorObject.authorRank == "servmod")
                    {
                        ModeratorCommandDefinitions.CommandList(SplitString[0], _channel, _client, _user, SplitString.Skip(1).ToArray(), SplitString[1]);
                    } if (AuthorObject.authorRank == "server" || AuthorObject.authorRank == "admin" || AuthorObject.authorRank == "servmod")
                    {
                        ServerCommandDefinitions.CommandList(SplitString[0], _channel, _client, _user, SplitString[1]);
                    }
                    CommandDefinitions.CommandList(SplitString[0], _channel, _client, _user, SplitString[1]);
                } else
                {
                    if (AuthorObject.authorRank == "admin")
                    {
                        AdminCommandDefinitions.CommandList(SplitString[0], _channel, _client, _user);
                    } if (AuthorObject.authorRank == "moderator" || AuthorObject.authorRank == "admin" || AuthorObject.authorRank == "servmod")
                    {
                        ModeratorCommandDefinitions.CommandList(SplitString[0], _channel, _client, _user, SplitString);
                    } if (AuthorObject.authorRank == "server" || AuthorObject.authorRank == "admin" || AuthorObject.authorRank == "servmod")
                    {
                        ServerCommandDefinitions.CommandList(SplitString[0], _channel, _client, _user);
                    }
                    CommandDefinitions.CommandList(SplitString[0], _channel, _client, _user);
                }
            }
        }
    }
}
