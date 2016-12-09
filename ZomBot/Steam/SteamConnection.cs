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

namespace ZomBot.Steam
{
    class SteamConnection
    {
        public static void Connect()
        {
            SteamWebAPI.SetGlobalKey("121DBEF14537D73A0ED2B9612FDEC3EA");
        }

        public static void testFunction(string _parameter, Channel _channel, DiscordClient _client, User _user)
        {
            var steamIdentity = SteamIdentity.FromSteamID(76561198019373573);
            string steamUserVanity = SteamWebAPI.General().ISteamUser().ResolveVanityURL(_parameter).GetResponseString();
            string friendsList = SteamWebAPI.General().ISteamUser().GetFriendList(steamIdentity, RelationshipType.Friend).GetResponseString();
            //JToken token = JObject.Parse(friendsList);
            //long steamID = (long)token.SelectToken("steamid");
            dynamic results = JsonConvert.DeserializeObject<dynamic>(friendsList);
            _channel.SendMessage(steamUserVanity);
            _channel.SendMessage("Steam ID: " + results.steamid);
        }
    }
}
