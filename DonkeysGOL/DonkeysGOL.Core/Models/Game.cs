using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace DonkeysGOL.Core.Models
{
    public class Game
    {
        public Space Space { get; set; }
        private MethodInfo[] rules;
        public Game()
        {
            Space = new Space();
            rules=typeof(Rules).GetMethods(BindingFlags.Static | BindingFlags.Public );
        }


         private void ApplyRules()
        {
            for(int i =0; i < Space.SPACE_SIZE; i++)
            {
                for(int j =0; j<Space.SPACE_SIZE;j++)
                {
                    foreach (MethodInfo rule in rules)
                    {
                        object[] parameters = { this.Space , i,j};
                        rule.Invoke(null, parameters);
                        
                    }
                }
            }
        }

         public void Run()
        {
            this.ApplyRules();
        }
    }
}
