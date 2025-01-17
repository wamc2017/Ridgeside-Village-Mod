﻿using StardewValley;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RidgesideVillage
{
    internal static class Log
    {
        internal static void Error(string msg) => ModEntry.ModMonitor.Log(msg, StardewModdingAPI.LogLevel.Error);
        internal static void Alert(string msg) => ModEntry.ModMonitor.Log(msg, StardewModdingAPI.LogLevel.Alert);
        internal static void Warn(string msg) => ModEntry.ModMonitor.Log(msg, StardewModdingAPI.LogLevel.Warn);
        internal static void Info(string msg) => ModEntry.ModMonitor.Log(msg, StardewModdingAPI.LogLevel.Info);
        internal static void Debug(string msg) => ModEntry.ModMonitor.Log(msg, StardewModdingAPI.LogLevel.Debug);
        internal static void Trace(string msg) => ModEntry.ModMonitor.Log(msg, StardewModdingAPI.LogLevel.Trace);

    }

    internal static class UtilFunctions
    {
        //3 hours of trying and tears :c
        internal static void StartEvent(StardewValley.Event EventObj, string locationName, int x, int y){
            if (Game1.currentLocation.Name.Equals(locationName))
            {
                Game1.delayedActions.Add(new DelayedAction(500, delegate
                 {
                     Game1.currentLocation.startEvent(EventObj);
                 }));
                Game1.fadeScreenToBlack();
            }
            else
            {

                LocationRequest warpRequest = Game1.getLocationRequest(locationName);
                warpRequest.OnLoad += delegate
                {
                    Game1.currentLocation.currentEvent = EventObj;
                };
                Game1.warpFarmer(warpRequest, x, y, Game1.player.FacingDirection);
            }
            
        }
    }   
}
