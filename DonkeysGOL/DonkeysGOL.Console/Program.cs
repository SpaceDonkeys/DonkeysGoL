using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DonkeysGOL.Console.View;
using DonkeysGOL.Core.Models;

namespace DonkeysGOL.Console
{
    class Program
    {

        static void Main(string[] args)
        {
            Game game = new Game();
            game.Run();
            View.CrudeRenderer.RenderSpace(game.Space);
            System.Console.ReadKey();
        }


    }



}

