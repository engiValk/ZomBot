using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
namespace ZomBot
{
    class ServerCommandDefinitions
    {
        internal static void CommandList(string _command, Channel _channel, DiscordClient _client, User _user, string _parameter = "100")
        {
            switch (_command)
            {
                case "!help": //Help command. Lists all other commands.
                   _channel.SendMessage("Command: !servertest: Tests if the user has server permissions.");
                    break;
                case "!servertest":
                    _channel.SendMessage("Test passed");
                    break;
            }
        }
    }
}
