using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Time_class
{
    public class Time


    {
        private int _hour;
        private int _millisecond;
        private int _minute;
        private int _second;

        public Time():this(0, 0, 0, 0) { }
        
        public Time(int hour):this(hour, 0, 0, 0) { }
        
        public Time(int hour, int minute):this(hour, minute, 0, 0) { }

        public Time(int hour, int minute, int second):this(hour, minute, second, 0) { }
               
        public Time(int hour , int minute , int second , int millisecond )
        {
            _hour = ValidateHour(hour);
            _millisecond = ValidateMillisecond(millisecond);
            _minute = ValidateMinute(minute);
            _second = ValidateSecond(second);
        }
        public Time Add(Time other)
        {
            int totalmillisecond = this.ToMillisecond() + other.ToMillisecond() % 86400000;
            int hour = (totalmillisecond / 3600000) % 24;            
            int minute =(totalmillisecond % 3600000) / 60000;            
            int second = (totalmillisecond % 60000 )/ 1000;
            int millisecond = totalmillisecond % 1000;
            return new Time (hour, minute, second, millisecond);

        }
        public bool IsOtherDay(Time other)
        {
            int totalmillisecond = this.ToMillisecond() + other.ToMillisecond();
            
             return totalmillisecond >= 86400000;
            
        }

        public override string ToString()
        {

            int hour1 = _hour % 12;
            if (hour1 == 0)
            {
                hour1 = 00;
            }
            string ampm = _hour < 12 ? "AM" : "PM";

            return $"{hour1:00}:{_minute:00}:{_second:00}.{_millisecond:000} {ampm}";

        }
        public int ToMillisecond()
        {
            return _hour * 3600000 + _minute * 60000 + _second * 1000 + _millisecond;
        }

        public int ToSecond()
        {
            return _hour * 3600 + _minute * 60 + _second;
        }

        public int ToMinute()
        {
            return _hour * 60 + _minute;
        }
        private int ValidateHour(int hour)
        {
            if( hour < 0 || hour > 23)
            {
                throw new ArgumentException($"The hour: {hour}, is not valid.");
            }
            return hour;
        }
        private int ValidateMinute(int minute)
        {
            if (minute < 0  || minute > 59)
            {
                throw new ArgumentException($"The minute: {minute}, is not valid.");
            }
            return minute;
        }
        private int ValidateSecond(int second)
        {
            if( second < 0 || second > 59)
            {
                throw new ArgumentException($"The second: {second}, is not valid.");
            }
            return second;
        }
        private int ValidateMillisecond(int millisecond)
        {
            if (millisecond < 0 || millisecond > 999)
            {
                throw new ArgumentException($"The Milisecond:{millisecond}, is not valid.");
            }
            return millisecond;
        }

        public int Hour
        {
            get => _hour;
            set => _hour = ValidateHour(value);
        }
        public int Milliseconde
        {
            get => _millisecond;
            set => _millisecond = ValidateMillisecond(value);
        }
        public int Minute
        {
            get => _minute;
            set => _minute = ValidateMinute (value);
        }
        public int Seconds
        {
            get => _second;
            set => _second = ValidateSecond(value);
        }

    }


}
