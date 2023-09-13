using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Workers.Data
{
    public class Manager : Employee
    {
        /// <summary>
        /// Props and ctor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="position"></param>
        /// <param name="hourlyRate"></param>
        /// <param name="bonus"></param>

        private int _bonus;

        [JsonProperty("Bonus")]
        public int Bonus
        {
            get { return _bonus; }
            set { _bonus = value;}
        }
        public Manager(string name, string position, int hourlyRate) : base(name, position, hourlyRate) { }

        [JsonConstructor] // for newton json
        public Manager(string name, string position, int hourlyRate, int bonus) : base(name, position, hourlyRate)
        {
            Bonus = bonus;
        }
    }
}
