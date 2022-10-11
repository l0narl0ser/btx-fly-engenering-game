using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sky
{
    public class Engine
    {
        private Gear[] gears;

        public Engine(Gear[] gears)
        {
            this.gears = gears;
        }
        public int SearchGear(int countEdge) 
        {
            int summerGear = 0;

            for(int i = 0; i < gears.Length; i++)
            {
                if(gears[i].GetEdge() > countEdge) {
                    summerGear++;
                }
            }
            return summerGear;
        }

    }
}
