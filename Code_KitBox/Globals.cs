using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface_5
{
    static class Globals
    {
        // global int
        public static int counter;

        // global function
        //public static string HelloWorld()
        //{
          //  return "Hello World";
        //}

        // global int using get/set
        static int _getsetcounter;
        public static int getsetcounter
        {
            set { _getsetcounter = value; }
            get { return _getsetcounter; }
        }
        public static Order order;
        public static Furniture furniture;

        public static Box box;
    }
}
