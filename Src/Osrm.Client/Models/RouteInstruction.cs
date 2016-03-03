using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osrm.Client.Models
{
    public class RouteInstruction //: IEnumerable<object>
    {
        protected string[] InstructionElements { get; set; }

        /// <summary>
        /// integer or string in format 11-{exit_number} (where exit_number is an integer)
        /// </summary>
        public string DriveInstructionCode { get { return GetFromArray<string>(0); } }

        /// <summary>
        /// name of the street
        /// </summary>
        public string StreetName { get { return GetFromArray<string>(1); } }

        /// <summary>
        ///  length of the street in meters
        /// </summary>
        public int Length { get { return GetFromArray<int>(2); } }

        /// <summary>
        /// index to the list of coordinates represented by the decoded route_geometry
        /// </summary>
        public int LocationIndex { get { return GetFromArray<int>(3); } }

        /// <summary>
        /// travel time in seconds
        /// </summary>
        public int Time { get { return GetFromArray<int>(4); } }

        /// <summary>
        /// length with unit
        /// </summary>
        public string FormatedLength { get { return GetFromArray<string>(5); } }

        /// <summary>
        /// abbreviation N: north, S: south, E: east, W: west, NW: North West,  ...
        /// </summary>
        public string PostTurnDirection { get { return GetFromArray<string>(6); } }

        public int PostTurnAzimuth { get { return GetFromArray<int>(7); } }

        /// <summary>
        /// mode of transportation as defined in the profile as integer (usually 1 means the default mode, e.g. 'car' for the car profile, 'bike' for the bicycle profile etc.)
        /// </summary>
        public int Mode { get { return GetFromArray<int>(8); } }

        /// <summary>
        /// abbreviation N: north, S: south, E: east, W: west, NW: North West, ...
        /// </summary>
        public string PreTurnDirection { get { return GetFromArray<string>(9); } }

        public int PreTurnAzimuth { get { return GetFromArray<int>(10); } }

        public RouteInstruction(string[] instructionElements)
        {
            InstructionElements = instructionElements;
        }

        protected T GetFromArray<T>(int i)
        {
            if (InstructionElements == null
                || InstructionElements.Length <= i)
            {
                return default(T);
            }

            try
            {
                return (T)TypeDescriptor.GetConverter(typeof(T)).ConvertFrom(InstructionElements[i]);
                //return (T)instructionElements[i];
            }
            catch (Exception ex)
            {
                return default(T);
            }
        }
    }
}