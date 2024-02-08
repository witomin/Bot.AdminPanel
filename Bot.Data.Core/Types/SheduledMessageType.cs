using System.ComponentModel;

namespace Bot.Data.Core.Types {
    /// <summary>
    /// Типы рассылаемых сообщений
    /// </summary>
    public enum SheduledMessageType {
        /// <summary>
        /// Прогноз на сегодня
        /// </summary>
        [Description("Прогноз на сегодня")]
        ForecastToday = 0,
        /// <summary>
        /// Прогноз на завтра
        /// </summary>
        [Description("Прогноз на завтра")]
        ForecastTomorow = 1,
        /// <summary>
        /// Прогноз на 5 дней
        /// </summary>
        [Description("Прогноз на 5 дней")]
        Forecast5Day = 2,
        /// <summary>
        /// Прогноз на 5 дней
        /// </summary>
        [Description("Прогноз на 10 дней")]
        Forecast10Day = 3
    }
}
