using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;

namespace ZomBot
{
    class AdminCommandDefinitions
    {
        internal static void CommandList(string _command, Channel _channel, DiscordClient _client, User _user, string _parameter = "100")
        {
            switch (_command)
            {
                case "!help": //Help command. Lists all other commands.
                    Console.WriteLine("Admin asked for help.");
                    _channel.SendMessage("Command: !exit: Exits the bot.");
                    break;
                case "!exit": //Exit Command. Closes the bot down.
                    Console.WriteLine("Client Shutting down.");
                    _client.Disconnect();
                    break;

            }
        }
    }
}
