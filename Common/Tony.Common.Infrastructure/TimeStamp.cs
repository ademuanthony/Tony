using System;
using System.Globalization;

namespace Tony.Common.Infrastructure
{
    public class TimeStamp
    {
        //global fields
        long _timeStamp;
        DateTime _date;
        string y, M, d, H, m, s, f;

        #region//constructor
        /// <summary>
        /// <para>Initialize a new instance of TimeStamp class of the current day</para>
        /// </summary>
        /// <returns>TimeStamp timeStamp</returns>
        public TimeStamp(bool now = false)
        {            
            _date = DateTime.Now;
            _timeStamp = GetTimeStamp(_date);//empty one is today
            //_date will be for 00:00:00 if now is false
            if (!now)
            {
                string timeStampString = "";
                timeStampString = _date.Year.ToString();
                if (_date.Month.ToString().Length < 2)
                    timeStampString += "0" + _date.Month.ToString();
                else
                    timeStampString += _date.Month.ToString();
                if (_date.Day.ToString().Length < 2)
                    timeStampString += "0" + _date.Day.ToString();
                else
                    timeStampString += _date.Day.ToString();
                timeStampString += "0000000000";

                _timeStamp = long.Parse(timeStampString);
                _date = GetDate(_timeStamp);
            }
            
        }
        //from time stamp
        /// <summary>
        /// <para>Initialize a new instance of TimeStamp class of a specified long timeStamp</para>
        /// </summary>
        /// <returns>TimeStamp timeStamp</returns>
        public TimeStamp(long timeStamp, bool earliest = false)
        {
            if (!earliest)
            {
                _timeStamp = timeStamp;
                _date = GetDate(_timeStamp);
            }
            else
            {
                var dt = GetDate(timeStamp);
                var ts = new TimeStamp(dt, true);
                _timeStamp = ts.ToLong();
                _date = ts.Date;
            }
        }
        //from date
        /// <summary>
        /// <para>Initialize a new instance of TimeStamp class of a specified DateTime date</para>
        /// </summary>
        /// <returns>TimeStamp timeStamp</returns>
        public TimeStamp(DateTime date, bool ealiest = false)
        {
            if (ealiest)
            {
                _timeStamp = GetTimeStamp(date, ealiest);
                _date = GetDate(_timeStamp);
            }
            else
            {
                _timeStamp = GetTimeStamp(date);
                _date = date;
            }
        }

        #endregion

        #region//********************Instance members*********************//
        //getting time stamp in general ****parts of this was taken from stackoverflow.com
        private long GetTimeStamp(DateTime date, bool earliest = false)
        {
                       
            string timeStampString = "";
            //year
            timeStampString = date.Year.ToString();
            //month
            if (date.Month.ToString().Length < 2)
                timeStampString += "0" + date.Month.ToString();
            else
                timeStampString += date.Month.ToString();
            //day
            if (date.Day.ToString().Length < 2)
                timeStampString += "0" + date.Day.ToString();
            else
                timeStampString += date.Day.ToString();
            
            //check for ealiest
            if (earliest)
                goto _end;
            
            
            //hour
            if (date.Hour.ToString().Length < 2)
                timeStampString += "0" + date.Hour.ToString();
            else
                timeStampString += date.Hour.ToString();
            //munite
            if (date.Minute.ToString().Length < 2)
                timeStampString += "0" + date.Minute.ToString();
            else
                timeStampString += date.Minute.ToString();
            //second
            if (date.Second.ToString().Length < 2)
                timeStampString += "0" + date.Second.ToString();
            else
                timeStampString += date.Second.ToString();
            //millisecond
            if (date.Millisecond.ToString().Length < 2)
                timeStampString += "000" + date.Millisecond.ToString();
            else if (date.Millisecond.ToString().Length < 3)
                timeStampString += "00" + date.Millisecond.ToString();
            else if (date.Millisecond.ToString().Length < 4)
                timeStampString += "0" + date.Millisecond.ToString();
            else
                timeStampString += date.Millisecond.ToString();

            _end:
            if (earliest)
            {
                timeStampString += "0000000000";
            }
            return long.Parse(timeStampString);
    
        }

        //getting date from time stamp
        private DateTime GetDate(long timeStamp)
        {
            DateTime dt;
            if (timeStamp.ToString().Length != 18)
            {
                throw new ArgumentOutOfRangeException("The expected format for timeStamp is yyyyMMddHHmmssffff");
            }
            string ts = timeStamp.ToString();
            //extracting y m d ... from ts
            y = ts.Substring(0, 4);
            M = ts.Substring(4, 2);
            d = ts.Substring(6, 2);
            H = ts.Substring(8, 2);
            m = ts.Substring(10, 2);
            s = ts.Substring(12, 2);
            f = ts.Substring(14, 4);
            /*
            //check the format of the time stamo
            if (y.Substring(0, 1) == "0" || M == "00" || d == "00")
            {
                throw new ArgumentOutOfRangeException("Invalid value for the agurment timeStamp.");
            }*/
            

            dt = DateTime.ParseExact(y + "-" + M + "-" + d + " " + H + ":" + m + ":" + s + "," + f, "yyyy-MM-dd HH:mm:ss,ffff",
                                        CultureInfo.InvariantCulture);

            return dt;
        }
        /// <summary>
        /// Returns the string representation of the time stamp
        /// </summary>
        /// <returns>string timeStamp</returns>
        public override string ToString()
        {
            return _timeStamp.ToString();
        }

        public string Greet()
        {
            if (Hour >= 5 & Hour < 12) return "Good Morning";
            if (Hour >= 12 && Hour < 16) return "Good Afternoon";
            if (Hour >= 16 && Hour <= 24) return "Good Evening";
            return "Good Night";
        }
        /// <summary>
        /// Returns the long representation of the time stamp
        /// </summary>
        /// <returns>long timeStamp</returns>
        public long ToLong()
        {
            return _timeStamp;
        }
        /// <summary>
        /// Returns the strind representation of the time stamp in human language
        /// </summary>
        /// <returns>long timeStamp</returns>
        public string ToWord()
        {
            string retVal = "";
            

            return retVal;
        }
        /// <summary>
        /// Returns the long representation of the time of the day of the timestamp
        /// </summary>
        /// <returns>long longTimeTimeStamp</returns>
        public long GetTimeToLong()
        {
            return long.Parse(_timeStamp.ToString().Substring(8)); 
        }
        //returning the date
        /// <summary>
        /// Returns the DateTime representation of the time stamp
        /// </summary>
        /// <returns>DateTime dateTime</returns>
        public DateTime Date
        {
            get { return _date;}
        }
        //getting year, month, day, day of the weak from time stamp
        /// <summary>
        /// Returns an int representing the value of year in the time stamp
        /// </summary>
        /// <returns>int year</returns>
        public int Year
        {
            get { return GetDate(_timeStamp).Year;} 
        }
        /// <summary>
        /// Returns an int representing the value of month of the year in the time stamp
        /// </summary>
        /// <returns>int month</returns>
        public int Month
        {
            get { return GetDate(_timeStamp).Month; }
        }
        /// <summary>
        /// Returns an int representing the value of day of the month in the time stamp
        /// </summary>
        /// <returns>int day</returns>
        public int Day
        {
            get { return GetDate(_timeStamp).Day; }
        }
        /// <summary>
        /// Returns an int representing the value of hour of the day in the time stamp
        /// </summary>
        /// <returns>int hour</returns>
        public int Hour
        {
            get { return GetDate(_timeStamp).Hour; }
        }
        /// <summary>
        /// Returns an int representing the value of Munite of the hour in the time stamp
        /// </summary>
        /// <returns>int Minute</returns>
        public int Minute 
        {
            get { return GetDate(_timeStamp).Minute; }
        }
        /// <summary>
        /// Returns an int representing the value of second of the munit in the time stamp
        /// </summary>
        /// <returns>int second</returns>
        public int Second
        {
            get { return GetDate(_timeStamp).Second; }
        }
        /// <summary>
        /// Returns an int representing the value of milliseconds of the second in the time stamp
        /// </summary>
        /// <returns>int millisecond</returns>
        public int MilliSecond
        {
            get { return GetDate(_timeStamp).Millisecond; }
        }
        /// <summary>
        /// Returns a System.DayOfWeek struct representing the value of the day of the weak in the time stamp
        /// </summary>
        /// <returns>DayOfWeak dayOfTheWeak</returns>
        public DayOfWeek DayOfTheWeak
        {
            get { return GetDate(_timeStamp).DayOfWeek; }
        }

        #region diff

        /// <summary>
        /// Returns an int representing the value of the day of the year in the time stamp
        /// </summary>
        /// <returns>int dayOfTheWeak</returns>
        public int DayOfTheYear
        {
            get { return GetDate(_timeStamp).DayOfYear; }
        }
        /// <summary>
        /// Tells wheathere this instance is a time in feature or not
        /// </summary>
        /// <returns>bool</returns>
        public bool IsAhead
        {
            get
            {
                return ToLong() > new TimeStamp(true).ToLong();
            }
        }
        /// <summary>
        /// Tells wheather this instance is a leap year or not
        /// </summary>
        /// <returns>bool</returns>
        public bool IsALeapYear
        {
            get
            {
                return DateTime.IsLeapYear(Year);
            }
        }
        //getting date difference in second, menute, hours, days, months, and years
        //this will serve for time ago
        /// <summary>
        /// <para>Returns the value of an int representing the value of the year difference between</para>
        /// <para>this instance and the timeStamp. -ve returns means the timeStamp is ahead of this</para>
        /// </summary>
        /// <returns>int YearsDifference</returns>
        public int YearsDifference(TimeStamp timeStamp)
        {
            return Math.Abs(Year - timeStamp.Year);
        }
        /// <summary>
        /// <para>Returns the value of an int representing the value of the extra month difference</para>
        /// <para> between this instance and the timeStamp. -ve return means the month is ahead</para>
        /// </summary>
        /// <returns>int MonthDifference</returns>
        public int MonthDifference(TimeStamp timeStamp)
        {
            int diff = 0;
            if (ToLong() > timeStamp.ToLong())
            {
                //time ago. first = this
                if (Month < timeStamp.Month)
                {
                    diff = timeStamp.Month - Month;
                    if (Day > timeStamp.Day)
                        diff -= 1;
                }
                else
                {
                    diff = (12 - timeStamp.Month) + Month;
                }

            }
            else
            {
                //time ahead. first = timeStamp
            }
            return diff;
        }
        /// <summary>
        /// <para>Returns the value of an int representing the value of the exta day difference</para>
        /// <para> between this instance and the timeStamp. -ve return means the day is ahead</para>
        /// </summary>
        /// <returns>int DaysDifference</returns>
        public int DaysDifference(TimeStamp timeStamp)
        {
            int diff = 0;

            TimeStamp t1, t2;
            if (ToLong() > timeStamp.ToLong())
            {
                t1 = this;
                t2 = timeStamp;
            }
            else
            {
                t1 = timeStamp;
                t2 = this;
            }

            if (t1.Month == t2.Month)
                diff = t1.Day - t2.Day;
            else
                diff = (DateTime.DaysInMonth(t2.Year, t2.Month) - t2.Day) + t1.Day;

            return diff;
        }
        /// <summary>
        /// <para>Returns the value of an int representing the value of the extra hour difference</para>
        /// <para> between this instance and the timeStamp. -ve return means the hour is ahead</para>
        /// </summary>
        /// <returns>int HourDifference</returns>
        public int HourDifference(TimeStamp timeStamp)
        {
            int diff = 0;
            if (ToLong() > timeStamp.ToLong())
            {
                //time ago. first = this
                if (Hour < timeStamp.Hour)
                {
                    diff = timeStamp.Hour - Hour;
                    if (Minute > timeStamp.Minute)
                        diff -= 1;
                }
                else
                {
                    diff = (24 - timeStamp.Hour) + Hour;
                }

            }
            else
            {
                //time ahead. first = timeStamp
            }
            return diff;
        }
        /// <summary>
        /// <para>Returns the value of an int representing the value of the extra minute difference</para>
        /// <para> between this instance and the timeStamp. -ve return means the minute is ahead</para>
        /// </summary>
        /// <returns>int MinuteDifferenc</returns>
        public int MinuteDifferenc(TimeStamp timeStamp)
        {
            int diff = 0;
            if (ToLong() > timeStamp.ToLong())
            {
                //time ago. first = this
                if (Minute < timeStamp.Minute)
                {
                    diff = timeStamp.Minute - Minute;
                    if (Second > timeStamp.Second)
                        diff -= 1;
                }
                else
                {
                    diff = (60 - timeStamp.Minute) + Minute;
                }

            }
            else
            {
                //time ahead. first = timeStamp
            }
            return diff;
        }
        /// <summary>
        /// <para>Returns the value of an int representing the value of the extra minute difference</para>
        /// <para> between this instance and the timeStamp. -ve return means the second is ahead</para>
        /// </summary>
        /// <returns>int MinuteDifferenc</returns>
        public int SecondsDifference(TimeStamp timeStamp)
        {
            int diff = 0;
            if (ToLong() > timeStamp.ToLong())
            {
                //time ago. first = this
                if (Second < timeStamp.Second)
                {
                    diff = timeStamp.Second - Second;
                    if (MilliSecond > timeStamp.MilliSecond)
                        diff -= 1;
                }
                else
                {
                    diff = (60 - timeStamp.Second) + Second;
                }

            }
            else
            {
                //time ahead. first = timeStamp
            }
            return diff;
        }
        /// <summary>
        /// <para>Returns the value of an int representing the value of the minute difference</para>
        /// <para> between this instance and the timeStamp. -ve return means the second is ahead</para>
        /// </summary>
        /// <returns>int MinuteDifferenc</returns>
        public int MilliSecondsDifference(TimeStamp timeStamp)
        {
            int diff = 0;
            if (ToLong() > timeStamp.ToLong())
            {
                //time ago. first = this
                if (MilliSecond < timeStamp.MilliSecond)
                    diff = timeStamp.MilliSecond - MilliSecond;
                else
                {
                    diff = (1000 - timeStamp.MilliSecond) + MilliSecond;
                }

            }
            else
            {
                //time ahead. first = timeStamp
            }
            return diff;
        }
        #endregion

        /// <summary>
        /// <para>Return an array of int the contains the result of the specified units </para>
        /// <para>added and the excess in terms of the specified fraction</para>
        /// <param name="unit1">One of the integers to be added</param>
        /// <param name="unit2">One of the integers to be added</param>
        /// <param name="fraction">Int. The base in which they should be added</param>
        /// </summary>
        /// <returns>TimeStamp timeStamp</returns>
        /// 
        private int[] addUnits(int unit1, int unit2, int fraction)
        {
            int[] outPut = new int[2];

            int excess = 0;//will hold the acess at each stage
            int unit = unit1 + unit2;
            //for millisecond
            if (unit > fraction)
            {
                if (unit % fraction != 0)
                {
                    excess = (unit - (unit % fraction)) / fraction;
                    unit = unit % fraction;
                }
                else
                {
                    excess = (unit - fraction) / fraction;
                    unit = fraction;
                }

            }
            else
            {
                excess = 0;
            }
            outPut[0] = unit;
            outPut[1] = excess;
            return outPut;
        }
        //adding time(when any thing is added) recreat the time stamp
        /// <summary>
        /// <para>Returns a new value of TimeStamp that add the specified time units to this instance</para>
        /// </summary>
        /// <returns>TimeStamp timeStamp</returns>
        /// 
        private TimeStamp addTimeUnits(int _y, int _M, int _d, int _H, int _m, int _s, int _f)
        {
            //tmp dateTime
            DateTime dt = Date;
            //using the datetime add methods
            dt = dt.AddMilliseconds(Convert.ToDouble(_f));
            dt = dt.AddSeconds(Convert.ToDouble(_s));
            dt = dt.AddMinutes(Convert.ToDouble(_m));
            dt = dt.AddHours(Convert.ToDouble(_H));
            dt = dt.AddDays(Convert.ToDouble(_d));
            dt = dt.AddMonths(_M);
            dt = dt.AddYears(_y);

            return new TimeStamp(dt);
         
        }
        /// <summary>
        /// <para>Returns a new value of TimeStamp that add the specified TimeStamp to this instance(which will not be changed)</para>
        /// </summary>
        /// <returns>TimeStamp timeStamp</returns>
        /// 
        public TimeStamp Add(TimeStamp timeStamp)
        {
            return addTimeUnits(timeStamp.Year, timeStamp.Month, timeStamp.Day, timeStamp.Hour, timeStamp.Minute, timeStamp.Second, timeStamp.MilliSecond);

        }
        /// <summary>
        /// <para>Returns a new value of TimeStamp that add the specified int years to this instance(which will not be changed)</para>
        /// </summary>
        /// <returns>TimeStamp timeStamp</returns>
        /// 
        public TimeStamp AddYears(int years)
        {
            return addTimeUnits(years, 0, 0, 0, 0, 0, 0);

        }
        /// <summary>
        /// <para>Returns a new value of TimeStamp that add the specified int months to this instance(which will not be changed)</para>
        /// </summary>
        /// <returns>TimeStamp timeStamp</returns>
        /// 
        public TimeStamp AddMonths(int months)
        {
            return addTimeUnits(0, months, 0, 0, 0, 0, 0);

        }
        /// <summary>
        /// <para>Returns a new value of TimeStamp that add the specified int days to this instance(which will not be changed)</para>
        /// <para>This can be used for performing days different</para>        
        /// </summary>
        /// <returns>TimeStamp timeStamp</returns>
        /// 
        public TimeStamp AddDays(int days)
        {
            return addTimeUnits(0, 0, days, 0, 0, 0, 0);

        }
        /// <summary>
        /// <para>Returns a new value of TimeStamp that add the specified int hours to this instance(which will not be changed)</para>
        /// </summary>
        /// <returns>TimeStamp timeStamp</returns>
        /// 
        public TimeStamp AddHours(int hours)
        {
            return addTimeUnits(0, 0, 0, hours, 0, 0, 0);

        }
        /// <summary>
        /// <para>Returns a new value of TimeStamp that add the specified int minutes to this instance(which will not be changed)</para>
        /// </summary>
        /// <returns>TimeStamp timeStamp</returns>
        /// 
        public TimeStamp AddMinutes(int minutes)
        {
            return addTimeUnits(0, 0, 0, 0, minutes, 0, 0);

        }
        /// <summary>
        /// <para>Returns a new value of TimeStamp that add the specified int seconds to this instance(which will not be changed)</para>
        /// </summary>
        /// <returns>TimeStamp timeStamp</returns>
        /// 
        public TimeStamp AddSeconds(int seconds)
        {
            return addTimeUnits(0, 0, 0, 0, 0, seconds, 0);

        }
        /// <summary>
        /// <para>Returns a new value of TimeStamp that add the specified int milliseconds to this instance(which will not be changed)</para>
        /// </summary>
        /// <returns>TimeStamp timeStamp</returns>
        /// 
        public TimeStamp AddMilliSeconds(int milliseconds)
        {
            return addTimeUnits(0, 0, 0, 0, 0, 0, milliseconds);

        }

        #endregion

        #region/***********Some Static Members*************************/
        /// <summary>
        /// Returns the hour of the day of the supplied timelong
        /// </summary>
        /// <param name="timeLong"></param>
        /// <returns></returns>
        public static int GetHourFromTimeLong(long timeLong)
        {
            return int.Parse(timeLong.ToString().Substring(0, 2));
        }

        /// <summary>
        /// return the munite of the hour of the supplied timelong
        /// </summary>
        /// <param name="timeLong"></param>
        /// <returns></returns>
        public static int GetMuniteFromTimeLong(long timeLong)
        {
            return int.Parse(timeLong.ToString().Substring(2, 2));
        }

        /// <summary>
        /// <para>Returns a new value of TimeStamp that subtracts the specified int days from today</para>
        /// <para>An alternative to this is the AddDay</para>        
        /// </summary>
        /// <returns>TimeStamp timeStamp</returns>
        /// 
        public static TimeStamp DaysBehind(int days)
        {
            if (days < 0)
                throw new ArgumentOutOfRangeException("The value of the int day cannot be less than 1");

            return new TimeStamp().AddDays(-days);
        }
        /// <summary>
        /// <para>Returns a new value of TimeStamp that add the specified int days to today</para>
        /// <para>An alternative to this is the AddDay</para>        
        /// </summary>
        /// <returns>TimeStamp timeStamp</returns>
        /// 
        public static TimeStamp DaysAhead(int days)
        {
            if (days < 0)
                throw new ArgumentOutOfRangeException("The value of the int day cannot be less than 1");
            return new TimeStamp().AddDays(days);
        }
        /// <summary>
        /// <para>Returns the value of TimeStamp for today</para>       
        /// </summary>
        /// <returns>TimeStamp timeStamp</returns>
        /// 
        public static TimeStamp Today
        {
            get
            {
                return new TimeStamp();
            }
        }
        /// <summary>
        /// <para>Returns the value of TimeStamp for the current datetime</para>       
        /// </summary>
        /// <returns>TimeStamp timeStamp</returns>
        /// 
        public static TimeStamp Now
        {
            get
            {
                return new TimeStamp(true);
            }
        }
        /// <summary>
        /// <para>Returns the value of TimeStamp for yesterday</para>
        /// <para>An alternative to this is the DaysBehind(1)</para>        
        /// </summary>
        /// <returns>TimeStamp timeStamp</returns>
        /// 
        public static TimeStamp Yesterday
        {
            get
            {
                return DaysBehind(1);
            }
        }
        /// <summary>
        /// <para>Returns the value of TimeStamp for tomorow</para>
        /// </summary>
        /// <returns>TimeStamp timeStamp</returns>
        /// 
        public static TimeStamp Tomorow
        {
            get
            {
                return DaysAhead(1);
            }
        }
        /// <summary>
        /// <para>Returns the value of TimeStamp for this weak's sunday</para>      
        /// </summary>
        /// <returns>TimeStamp timeStamp</returns>
        /// 
        public static TimeStamp ThisWeak
        {
            get
            {
                int dayDiff = 0;
                TimeStamp tsToday = new TimeStamp();
                //checking the currrent day of the weak
                switch (tsToday.DayOfTheWeak)
                {
                    case DayOfWeek.Sunday:
                        dayDiff = 0;
                        break;
                    case DayOfWeek.Monday:
                        dayDiff = 1;
                        break;
                    case DayOfWeek.Tuesday:
                        dayDiff = 2;
                        break;
                    case DayOfWeek.Wednesday:
                        dayDiff = 3;
                        break;
                    case DayOfWeek.Thursday:
                        dayDiff = 4;
                        break;
                    case DayOfWeek.Friday:
                        dayDiff = 5;
                        break;
                    case DayOfWeek.Saturday:
                        dayDiff = 6;
                        break;

                }
                //returning the TimeStamp() for sunday this weak
                return DaysBehind(dayDiff);
            }
        }
        /// <summary>
        /// <para>Returns the value of TimeStamp for next weak's sunday</para>      
        /// </summary>
        /// <returns>TimeStamp timeStamp</returns>
        /// 
        public static TimeStamp NextWeak
        {
            get
            {

                int dayDiff = 0;
                TimeStamp tsToday = new TimeStamp();
                //checking the currrent day of the weak
                switch (tsToday.DayOfTheWeak)
                {
                    case DayOfWeek.Sunday:
                        dayDiff = 7;
                        break;
                    case DayOfWeek.Monday:
                        dayDiff = 6;
                        break;
                    case DayOfWeek.Tuesday:
                        dayDiff = 5;
                        break;
                    case DayOfWeek.Wednesday:
                        dayDiff = 4;
                        break;
                    case DayOfWeek.Thursday:
                        dayDiff = 3;
                        break;
                    case DayOfWeek.Friday:
                        dayDiff = 2;
                        break;
                    case DayOfWeek.Saturday:
                        dayDiff = 1;
                        break;

                }
                //returning the TimeStamp() for sunday next weak
                return DaysAhead(dayDiff);
            }
        }
        /// <summary>
        /// <para>Returns the value of TimeStamp for Last weak's sunday</para>      
        /// </summary>
        /// <returns>TimeStamp timeStamp</returns>
        /// 
        public static TimeStamp LastWeak
        {
            get
            {
                //get this weak sunday and remove 7 days
                return ThisWeak.AddDays(-7);
            }
        }
        /// <summary>
        /// <para>Returns the value of TimeStamp for the first day of this month</para>      
        /// </summary>
        /// <returns>TimeStamp timeStamp</returns>
        /// 
        public static TimeStamp ThisMonth
        {
            get
            {
                TimeStamp ts = new TimeStamp();
                //getting todays date andgoing back by it + 1
                return ts.AddDays(-ts.Day + 1);
            }
        }
        /// <summary>
        /// <para>Returns the value of TimeStamp for the first day of last month</para>      
        /// </summary>
        /// <returns>TimeStamp timeStamp</returns>
        /// 
        public static TimeStamp LastMonth
        {
            get
            {
                //if today date if first, going back by one will take us to yesterday
                TimeStamp ts = new TimeStamp();
                //going to the first day of last month
                switch (ts.Month)
                {
                    //in each case, get this month and go back by the number of days in last month
                    case 12:
                        return ThisMonth.AddDays(-30);//Nov
                    case 11:
                        return ThisMonth.AddDays(-31);//Oct
                    case 10:
                        return ThisMonth.AddDays(-30);//Sept
                    case 9:
                        return ThisMonth.AddDays(-31);//Aug
                    case 8:
                        return ThisMonth.AddDays(-31);//July
                    case 7:
                        return ThisMonth.AddDays(-30);//June
                    case 6:
                        return ThisMonth.AddDays(-31);//May
                    case 5:
                        return ThisMonth.AddDays(-30);//April
                    case 4:
                        return ThisMonth.AddDays(-31);//Match
                    case 3:
                        if(DateTime.IsLeapYear(DateTime.Now.Year))
                            return ThisMonth.AddDays(-28);//Feb
                        else
                            return ThisMonth.AddDays(-29);//Feb in leap year

                    case 2:
                        return ThisMonth.AddDays(-31);//Jen
                    case 1:
                        return ThisMonth.AddDays(-31);//Dec
                    default:
                        return null;
                }
                
                
            }
        }
        /// <summary>
        /// <para>Returns the value of TimeStamp for the first day of next month</para>      
        /// </summary>
        /// <returns>TimeStamp timeStamp</returns>
        /// 
        public static TimeStamp NextMonth
        {
            get
            {
                //if today date if first, going back by one will take us to yesterday
                TimeStamp ts = new TimeStamp();
                //int for holding day diff
                int dayDiff = 0;
                //going to the first day of last month
                switch (ts.Month)
                {
                    //in each case, take todays' date off the rest path of this month to know how many daysleft in this month
                    case 12:
                    case 10:
                    case 8:
                    case 7:
                    case 5:
                    case 3:
                    case 1:
                        dayDiff = 31 - ts.Day;
                        break;
                    case 11:
                    case 9:
                    case 6:
                    case 4:
                        dayDiff = 30 - ts.Day;
                        break;
                    case 2:
                        if (DateTime.IsLeapYear(DateTime.Now.Year))
                            dayDiff = 28 - ts.Day;
                        else
                            dayDiff = 29 - ts.Day;
                        break;
                    default:
                        return null;
                }
                //go one day ahead of this month ending
                dayDiff += 1;
                //return the TimeStamp for the day ahead
                return DaysAhead(dayDiff);

            }
        }
        /// <summary>
        /// <para>Returns the value of TimeStamp for the first day of this year</para>      
        /// </summary>
        /// <returns>TimeStamp timeStamp</returns>
        /// 
        public static TimeStamp ThisYear
        {
            get
            {
                DateTime dt = DateTime.Now;
                string tsStr = dt.Year + "01010000000000";
                TimeStamp ts = new TimeStamp(long.Parse(tsStr));
                //getting todays date andgoing back by it + 1
                return ts;
            }
        }
        /// <summary>
        /// <para>Returns the value of TimeStamp for the first day of last year</para>      
        /// </summary>
        /// <returns>TimeStamp timeStamp</returns>
        /// 
        public static TimeStamp LastYear
        {
            get
            {
                DateTime dt = DateTime.Now.AddYears(-1);
                string tsStr = dt.Year + "01010000000000";
                TimeStamp ts = new TimeStamp(long.Parse(tsStr));
                return ts;
            }
        }
        /// <summary>
        /// <para>Returns the value of TimeStamp for the first day of next year</para>      
        /// </summary>
        /// <returns>TimeStamp timeStamp</returns>
        /// 
        public static TimeStamp NextYear
        {
            get
            {
                DateTime dt = DateTime.Now.AddYears(1);
                string tsStr = dt.Year + "01010000000000";
                TimeStamp ts = new TimeStamp(long.Parse(tsStr));
                //getting todays date andgoing back by it + 1
                return ts;
            }
        }

        #endregion
    }
}
