namespace Helpers
{
    public static class TimeConverter
    {
        public static string ToFormatMinSec(int seconds)
        {
            var min = seconds / 60;
            var sec = seconds % 60;
            var strMin = min < 10 ? $"0{min}" : min.ToString();
            var strSec = sec < 10 ? $"0{sec}" : sec.ToString();
            return $"{strMin}:{strSec}";
        }
    }
}