namespace ITJob.Infrastructure.Helper
{
    public static  class StringHelper
    {
        /// <summary>
        /// اعمال متن خالی به ...
        /// </summary>
        /// <param name="str">متن</param>
        /// <param name="replacement">متن جایگزین</param>
        /// <returns>متن غیر خالی</returns>
        public static string SetEmptyTo(this string str, string replacement = "-")
        {
            return string.IsNullOrEmpty(str) ? replacement : str;
        }
    }
}