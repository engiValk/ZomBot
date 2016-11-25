using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;

namespace ZomBot
{
    class ModeratorCommandDefinitions
    {
        static Channel _storedChannel = null;
        internal static void CommandList(string _command, Channel _channel, DiscordClient _client, User _user, string[] _splitArray, string _parameter = "100")
        {
            switch (_command)
            {
                case "!help": //Help command. Lists all other commands.
                    _channel.SendMessage("Command: !modtest: Tests if the user has mod permissions.");
                    _channel.SendMessage("Command: !delete: Deletes messages in the channel, using parameter to declare a number of messages. Only works if you can normally delete a message there.");
                    _channel.SendMessage("Command: !userinfo + parameter: Posts user's info including date and time joined and last activity.");
                    _channel.SendMessage("Command: !focus: Focusses the bot on the current channel");
                    _channel.SendMessage("Command: !say (PM): Sends a message from the bot via a PM to the focussed channel");
                    break;

                case "!modtest":
                    _channel.SendMessage("Test passed");
                    break;

                case "!delete":
                    Console.WriteLine(_channel.Users);
                    var userPermissions = _user.GetPermissions(_channel).ManageMessages;
                    Console.WriteLine("Admin" + userPermissions);
                    int number = int.Parse(_parameter);
                    Message[] message = new Message[number];
                    message = _channel.DownloadMessages(number).Result;
                    if (userPermissions == true)
                    {
                        _channel.DeleteMessages(message);
                        Console.WriteLine("Channel Admin: " + _user + " deleted messages from the channel: " + _channel);
                    }
                    else
                    {
                        Console.WriteLine("User: " + _user + " tried to delete messages from: #" + _channel + " when they aren't an admin there.");
                    }
                    break;

                case "!userinfo":
                    foreach (var i in _channel.Server.Users)
                    {
                        Console.WriteLine(i.Name + " " +i.Nickname);
                        if (i.Name.StartsWith(_parameter) || (i.Nickname != null && i.Nickname.StartsWith(_parameter)))

                        {
                            _channel.SendMessage("User Name: " + i.Name);
                            _channel.SendMessage("User Nickname: " + i.Nickname);
                            _channel.SendMessage("User ID: " + i.Id);
                            _channel.SendMessage("User Joined: " + i.JoinedAt);
                            _channel.SendMessage("Last Online: " + i.LastOnlineAt);
                        }
                    }
                    break;

                case "!focus":
                    _storedChannel = _channel;
                    Console.WriteLine("I stored the channel: " + _channel);
                    Message[] newMessage = new Message[1];
                    newMessage = _channel.DownloadMessages(1).Result;
                    _channel.DeleteMessages(newMessage);
                    break;

                case "!say":
                    _storedChannel?.SendMessage(string.Join(" ", _splitArray));
                    break;
            }
        }
    }
}
