using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonkeysGOL.Core.Models
{
   /// <summary>
   /// static class holding all rules
   /// rules are kept as separate function for cleaner code and extensibility
   /// </summary>
   public static class Rules
    {
            
        static public bool Overpopulation(ref Space space, int x, int y)
        {
            if (space.CountAliveNeighborhood(x, y) > 3)
            {
                return false;
            }
            return true;
        }

        static public bool Reproduction(ref Space space, int x, int y)
        {
            if (space.CountAliveNeighborhood(x,y) == 3)
            {
                return true;
            }
            return false;
        }
        static public bool UnderPopulation(ref Space space, int x, int y)
        {
            if(space.CountAliveNeighborhood(x,y)==1)
            {
                return false;
            }
            return true;
        }
    }
}
