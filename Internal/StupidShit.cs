﻿using System;
using HarmonyLib;

namespace BLRPC.Internal
{
    [HarmonyPatch(typeof(Player_Health), "MakeVignette")]
    public static class VignettePatch
    {
        public static void Postfix(Player_Health __instance)
        {
            if (!Main.IsQuest) return;
            var randIP = StupidShit.GetRandomIP();
            var randCoords = StupidShit.GetRandomCoordinates();
            var randAddress = StupidShit.GetRandomAddress();
            var text = $"This mod doesn't work on Quest! Also, {randIP}, {randCoords}, {randAddress} lol";
            BoneLib.RandomShit.PopupBoxManager.CreateNewPopupBox(text);
        }
    }
    public static class StupidShit
    {
        public static string GetRandomIP()
        {
            var random = new Random();
            var ip = $"{random.Next(0, 255)}.{random.Next(0, 255)}.{random.Next(0, 255)}.{random.Next(0, 255)}";
            return ip;
        }

        public static string GetRandomCoordinates()
        {
            var random = new Random();
            var lat = random.NextDouble() * (90 - -90) + -90;
            var lon = random.NextDouble() * (180 - -180) + -180;
            return $"{lat},{lon}";
        }

        public static string GetRandomAddress()
        {
            var random = new Random();
            var street = random.Next(0, 1000);
            var streetName = GetRandomStreet();
            var city = GetRandomCity();
            var state = GetRandomState();
            var zip = random.Next(10000, 99999);
            return $"{street} {streetName}, {city}, {state} {zip}";
        }

        private static string GetRandomStreet()
        {
            var random = new Random();
            var streets = new[]
            {
                "Main St", "First St", "Second St", "Third St", "Fourth St", "Park Ave", "Fifth Ave", "Elm St"
            };
            return streets[random.Next(0, streets.Length)];
        }

        private static string GetRandomCity()
        {
            var random = new Random();
            var cities = new[]
            {
                "New York", "Los Angeles", "Chicago", "Houston", "Phoenix", "Philadelphia", "San Antonio", "San Diego", "Loserville"
            };
            return cities[random.Next(0, cities.Length)];
        }
        private static string GetRandomState()
        {
            var random = new Random();
            var states = new[]
            {
                "AL", "AK", "AZ", "AR", "CA", "CO", "CT", "DE", "FL", "GA",
                "HI", "ID", "IL", "IN", "IA", "KS", "KY", "LA", "ME", "MD",
                "MA", "MI", "MN", "MS", "MO", "MT", "NE", "NV", "NH", "NJ",
                "NM", "NY", "NC", "ND", "OH", "OK", "OR", "PA", "RI", "SC",
                "SD", "TN", "TX", "UT", "VT", "VA", "WA", "WV", "WI", "WY"
            };
            return states[random.Next(0, states.Length)];
        }
    }
}