using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonkeysGOL.Core.Models
{
   public class Space
    {
        private Random seed;

        public const int SPACE_SIZE = 100;
        public bool [,] SpaceArray { get; set; }
        
        public int CountAliveNeighborhood(int x, int y)
        {
            //modulos make array wrap around so thet crossing left border you go right same with top and bottom
            int neighborCount=0;
            for (int i = -1; i < 2; i++)
            {
                neighborCount+= SpaceArray[MathMod((i+x), SPACE_SIZE) ,MathMod((y+1), SPACE_SIZE)]? 1:0;
                neighborCount += SpaceArray[MathMod((i+x), SPACE_SIZE), MathMod((y + 1), SPACE_SIZE)] ? 1 : 0;

            }
            neighborCount += SpaceArray[MathMod((x - 1), SPACE_SIZE), y] ? 1 : 0;
            neighborCount += SpaceArray[MathMod((x + 1), SPACE_SIZE), y] ? 1 : 0;

            return neighborCount;    
        }
        public Space()
        { 
            seed = new Random();
            SpaceArray = new bool[SPACE_SIZE, SPACE_SIZE];

            initializeSpaceFromSeed();
        }

        public Space(Random hseed)
        {
            this.seed = hseed;
            SpaceArray = new bool[SPACE_SIZE, SPACE_SIZE];

            initializeSpaceFromSeed();
        }

        private void initializeSpaceFromSeed()
        {
            for (int i =0; i<SPACE_SIZE; i++)
            {
                for (int j=0; j<SPACE_SIZE; j++)
                {
                    SpaceArray[i, j] = seed.NextDouble() >= 0.5;
                }
            }
        }

        //moulo that behaves like mathematical one with negative numbers
        private static int MathMod(int a, int b)
        {
            return (Math.Abs(a * b) + a) % b;
        }
    }
}
