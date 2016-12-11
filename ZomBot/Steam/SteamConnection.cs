using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PortableSteam;
using PortableSteam.Fluent;
using PortableSteam.Infrastructure;
using PortableSteam.Interfaces;
using Discord;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Xml;
using System.IO;

namespace ZomBot.Steam
{
    class SteamConnection
    {
        public static void Connect()
        {
            StreamReader steamapifile = File.OpenText("steamapi.txt");
            SteamWebAPI.SetGlobalKey(steamapifile.ReadToEnd());
        }

        public static void testFunction(string _parameter, Channel _channel, DiscordClient _client, User _user)
        {
            var steamIdentity = SteamIdentity.FromSteamID(Convert.ToInt64(_parameter));
            string steamUserVanity = SteamWebAPI.General().ISteamUser().ResolveVanityURL(_parameter).GetResponseString();
            string friendsList = SteamWebAPI.General().ISteamUser().GetFriendList(steamIdentity, RelationshipType.Friend).GetResponseString(RequestFormat.XML);
            _channel.SendMessage(steamUserVanity);
            _channel.SendMessage("Steam ID: " + friendsList);
        }
    }
}
