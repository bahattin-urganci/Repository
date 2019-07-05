using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace PawPos.Infrastructure.Extension
{
    public static class DateTimeExtensions
    {

        public static DateTime Truncate(this DateTime dateTime, TimeSpan timeSpan) => timeSpan == TimeSpan.Zero ? dateTime : dateTime.AddTicks(-(dateTime.Ticks % timeSpan.Ticks));
        public static DateTime JavascriptDateToDatetime(this string date) => DateTime.ParseExact(date.Substring(0, 24), "ddd MMM dd yyyy HH:mm:ss", CultureInfo.InvariantCulture);
        public static DateTime ToDateTime(this string date) => Convert.ToDateTime(date);
        /// <summary>
        /// Gelen Tarih formatını sql stringine çevirir
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static string ToSqlShortDateString(this DateTime dateTime) => dateTime.ToString("yyyy-MM-dd");
        public static string ToSqlDateTimeString(this DateTime dateTime) => dateTime.ToString("yyyy-MM-dd HH:mm:ss");
        public static string TimeSpanToShortTimeString(this TimeSpan timeSpan) => String.Format("{0:00}:{1:00}:{2:00}.{3:00}", timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds, timeSpan.Milliseconds / 10);
        public static DateTime UnixTimeStampToDateTime(this double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }

        public static double ToUnixTimeStamp(this DateTime dateTime)
        {
            var dateTimeOffset = new DateTimeOffset(dateTime);
            var unixDateTime = (double)dateTimeOffset.ToUnixTimeSeconds();
            return unixDateTime;
        }

    }
}
