using System;

namespace AlymSoftGo.Domain.Common
{
    /// <summary>
    /// Utilidad centralizada para conversiones seguras de fechas y zonas horarias.
    /// Garantiza persistencia y consultas en UTC preservando el contexto local del cliente.
    /// </summary>
    public static class DateTimeHelper
    {
        public const string DefaultWindowsTimeZone = "Central Standard Time (Mexico)";
        public const string DefaultIanaTimeZone = "America/Mexico_City";

        /// <summary>
        /// Obtiene el objeto TimeZoneInfo soportando tanto identificadores Windows como IANA.
        /// </summary>
        public static TimeZoneInfo GetTimeZone(string? timeZoneId)
        {
            if (string.IsNullOrWhiteSpace(timeZoneId))
            {
                timeZoneId = DefaultWindowsTimeZone;
            }

            try
            {
                return TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
            }
            catch
            {
                // Fallback de contingencia si el servidor no reconoce la zona
                try
                {
                    return TimeZoneInfo.FindSystemTimeZoneById(DefaultIanaTimeZone);
                }
                catch
                {
                    return TimeZoneInfo.Utc;
                }
            }
        }

        /// <summary>
        /// Calcula el rango UTC exacto (Inicio y Fin) correspondiente a un día o rango local.
        /// Ideal para enviar parámetros de búsqueda SARGables a Stored Procedures.
        /// </summary>
        public static (DateTime StartUtc, DateTime EndUtc) ToUtcDayRange(DateTime localDate, string? timeZoneId = null)
        {
            var tz = GetTimeZone(timeZoneId);
            
            var startOfDayLocal = localDate.Date;
            var endOfDayLocal = startOfDayLocal.AddDays(1);

            var startUtc = TimeZoneInfo.ConvertTimeToUtc(startOfDayLocal, tz);
            var endUtc = TimeZoneInfo.ConvertTimeToUtc(endOfDayLocal, tz);

            return (startUtc, endUtc);
        }

        /// <summary>
        /// Convierte una fecha y hora UTC a la hora local correspondiente a la zona horaria del cliente.
        /// </summary>
        public static DateTime ToLocal(DateTime utcDateTime, string? timeZoneId = null)
        {
            var tz = GetTimeZone(timeZoneId);
            return TimeZoneInfo.ConvertTimeFromUtc(DateTime.SpecifyKind(utcDateTime, DateTimeKind.Utc), tz);
        }
    }
}
