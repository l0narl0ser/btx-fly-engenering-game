using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sky
{
    public class Gear
    {
        private string id;
        private int edge;

        public void SetId(string id)
        {
            this.id = id;
        }
        public string GetId()
        {
            return id;
        }

        public void SetEdge(int edge)
        {
            this.edge = edge;
        }
        public int GetEdge()
        {
            return edge;
        }
    }
}
