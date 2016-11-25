using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
namespace ZomBot
{
    class CommandDefinitions
    {
        internal static void CommandList(string _command, Channel _channel, DiscordClient _client, User _user, string _parameter = "100")
        {
            Random rnd = new Random();
            switch (_command)
            {
                case "!help": //Help command. Lists all other commands.
                    _channel.SendMessage("Command: !author: Prints my creator.\n" +
                                         "Command: !trump + parameter: Makes me post a joke about trump and his wall.\n" +
                                         "Command: !image + parameter.filetype: Uploads a reaction image to chat.\n" +
                                         "Command: !dice: Rolls a d6.\n" +
                                         "Command: !noise: Makes a random noise.\n");
                    break;

                case "!author": //Author Command. Prints who made the bot.
                    _channel.SendMessage("My creator is @engi_valk#3982");
                    break;

                case "!trump": //Trump Command. Makes a wall joke.
                    _channel.SendMessage("We should build a wall and make " + _parameter + " pay for it!");
                    break;

                case "!image": //Image Command. Posts an image.
                    if (_parameter == "blank")
                    {
                        _channel.SendMessage("I need a filename and its type!");
                        break;
                    }
                    else
                    {
                        _channel.SendFile(_parameter);
                        break;
                    }

                case "!dice":
                    int number = rnd.Next(0, 6);
                    string[] numberWord = new string[6];
                    numberWord[0] = "one";
                    numberWord[1] = "two";
                    numberWord[2] = "three";
                    numberWord[3] = "four";
                    numberWord[4] = "five";
                    numberWord[5] = "six";
                    _channel.SendMessage(":" + numberWord[number] + ":");
                    break;

                case "!noise":
                    int counter = 0;
                    string line;
                    System.IO.StreamReader noiseMaker = new System.IO.StreamReader("noise.txt");
                    int lineNumber = rnd.Next(1, 8);
                    while ((line = noiseMaker.ReadLine()) != null)
                    {
                        counter++;
                        if (lineNumber == counter)
                        {
                            _channel.SendMessage(line);
                        }
                    }

                    noiseMaker.Close();
                    break; 
            }
        }
    }
}
