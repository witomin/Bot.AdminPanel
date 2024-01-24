using System;

namespace Bot.AdminPanel.Extensions {
    public static class DateTimeExtensions {
        /// <summary>
        /// Время конца дня. Например для 29.07.2023 возвращается 29.07.2023 23:59:59
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static DateTime EndDay (this DateTime dateTime) {
            return dateTime.Date.AddDays(1).AddSeconds(-1);
        }
    }
}
