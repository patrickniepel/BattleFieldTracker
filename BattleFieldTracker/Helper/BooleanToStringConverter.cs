namespace BattleFieldTracker.Helper
{
    public class BooleanToStringConverter
    {
        public string ConvertToString(bool value)
        {
            if (value)
            {
                return "Yes";
            }
            return "No";
        }
    }
}
