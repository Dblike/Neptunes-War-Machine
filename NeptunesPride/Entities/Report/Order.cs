using System;
using System.Collections.Generic;
using System.Text;

namespace NeptunesWarMachine.Entities
{
    public class Order
    {
        public int Delay { get; set; }
        public int StarId { get; set; }
        public int Action { get; set; }
        public int Ships { get; set; }
    }
}
