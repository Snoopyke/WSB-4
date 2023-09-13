using Newtonsoft.Json;
using System.Data;

namespace Workers.Data
{
    public class Employee 
    {
        /// <summary>
        /// Props and Ctor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="position"></param>
        /// <param name="hourlyRate"></param>
        /// <exception cref="ArgumentException"></exception>

        protected long _mployeeId;
        protected string? _name;
        protected string? _position;
        protected int _hourlyRate;

        public long EmployeeId
        {
            get { return _mployeeId; }
            set { if (value > 100000000000000000) { _mployeeId = value; } else throw new ArgumentException(); }
        }
        public string? Name
        {
            get { return _name; }
            set { if (value != null | value?.Length > 0) { _name = value; } else throw new ArgumentException(); }
        }
        public string? Position
        {
            get { return _position; }
            set { if (value != null | value?.Length > 0) { _position = value; } else throw new ArgumentException(); }
        }
        public int HourlyRate
        {
            get { return _hourlyRate; }
            set { if (value > 0) { _hourlyRate = value; } else throw new ArgumentException(); }
        }

        public Employee(string name, string position, int hourlyRate)
        {
            Name = name;
            Position = position;
            HourlyRate = hourlyRate;
            EmployeeId = (long)DateTime.Now.Ticks;
        }

    }
} 