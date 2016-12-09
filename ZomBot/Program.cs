using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using Discord;
using ZomBot.Steam;

namespace ZomBot
{
    class Program
    {
        static void Main(string[] args)
        {
            ///Initilize the client
            var _client = new DiscordClient();
            StreamReader apifile = File.OpenText("api.txt");
            SteamConnection.Connect();
            Console.WriteLine("Connected to steam.");
            _client.MessageReceived += (s, e) => {
                if (e.Message.IsMentioningMe())
                    ClientMentioned(s, e);
                Command.CommandController(_client, e.Channel, e.Message.RawText, e.User.Id.ToString(), e.User);
            };
            _client.ExecuteAndWait(async () =>
            {
            await _client.Connect(apifile.ReadToEnd(), TokenType.Bot);}
            );
        }
        //Responds to a client mentioning the bot.
        private static void ClientMentioned(object sender, MessageEventArgs e)
        {
            if (e.Message.IsAuthor || e.User.IsBot) return;
            Console.WriteLine(e.User + ": ID:  " + e.User.Id + " mentioned me!");
            e.Channel.SendMessage("*Zombie Groans at* " + e.User + " " + e.User.Id);
        }
    }
}
