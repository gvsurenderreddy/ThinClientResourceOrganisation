using System;

namespace WTS.WorkSuite.Library.DomainTypes.Time.Clocks {

    /// <summary>
    ///     Used to get the current time 
    /// </summary>
    public class Clock {

        public virtual UtcTime now () {

            var time = DateTime.UtcNow;

            return new UtcTime( 
                year: time.Year,
                month: time.Month,
                day: time.Day,

                hours: time.Hour,
                minutes: time.Minute,
                seconds: time.Second,
                milliseconds: time.Millisecond                
            );

        }
    }

}