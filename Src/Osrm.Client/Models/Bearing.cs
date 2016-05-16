using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osrm.Client.Models
{
    public class Bearing
    {
        protected int item1;
        protected int item2;

        /// <summary>
        /// value integer 0 .. 360
        /// </summary>
        public int Item1
        {
            get
            {
                return item1;
            }
            set
            {
                if (value < 0 || value > 360)
                {
                    throw new ArgumentOutOfRangeException("integer 0 .. 360");
                }

                item1 = value;
            }
        }

        /// <summary>
        /// Range integer 0 .. 180
        /// </summary>
        public int Item2
        {
            get
            {
                return item2;
            }
            set
            {
                if (value < 0 || value > 180)
                {
                    throw new ArgumentOutOfRangeException("integer 0 .. 180");
                }

                item2 = value;
            }
        }

        public Bearing(int item1, int item2)
        {
            Item1 = item1;
            Item2 = item2;
        }
    }
}