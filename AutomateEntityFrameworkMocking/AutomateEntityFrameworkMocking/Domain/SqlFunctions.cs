namespace AutomateEntityFrameworkMocking.Domain
{
    using System;
    using System.Data.Objects.DataClasses;

    /// <summary>
    /// Replaces Entity Framework class with equivalents that support unit testing
    /// </summary>
    public static class SqlFunctions
    {
        [EdmFunction("SqlServer", "STR")]
        public static string StringConvert(double? number)
        {
            return number.ToString();
        }

        [EdmFunction("SqlServer", "STR")]
        public static string StringConvert(short? number)
        {
            return number.ToString();
        }

        [EdmFunction("SqlServer", "STR")]
        public static string StringConvert(int? number)
        {
            return number.ToString();
        }

        [EdmFunction("SqlServer", "STR")]
        public static string StringConvert(decimal? number)
        {
            return number.ToString();
        }

        [EdmFunction("Edm", "TruncateTime")]
        public static DateTime? TruncateTime(DateTime? dateValue)
        {
            if (!dateValue.HasValue)
            {
                return null;
            }

            return dateValue.Value.Date;
        }

        [EdmFunction("Edm", "TruncateTime")]
        public static DateTime TruncateTime(DateTime dateValue)
        {
            return dateValue.Date;
        }
    }
}
