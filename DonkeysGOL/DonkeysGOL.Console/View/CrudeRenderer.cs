﻿using DonkeysGOL.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace DonkeysGOL.Console.View
{
    public static class CrudeRenderer
    {

        /// <summary>
        /// ONLY FOR DEBUGGING PURPOSES, IT WILL BE CHANGED, DONT RELY ON IT!
        /// </summary>
        /// 

        public static void PeriodicRender(Space space)
        {
            Timer timer = new System.Timers.Timer(3000); //change period
            timer.Elapsed += (sender, e) => RenderSpace(space, sender, e);
            timer.Enabled = true;
        }
        public static void RenderState(Space space)
        {
            System.Console.Clear();
            for (int i = 0; i < space.SpaceArray.GetLength(0); i++)
            {
                for (int j = 0; j < space.SpaceArray.GetLength(1); j++)
                {
                    System.Console.Write(space.SpaceArray[i, j] ? "■" : " ");
                    System.Console.Write(" ");
                }
                System.Console.WriteLine("");
            }
        }
        public static void RenderSpace(Space space,object sender, ElapsedEventArgs e)
        {
            RenderState(space);        
        }
    }
}
