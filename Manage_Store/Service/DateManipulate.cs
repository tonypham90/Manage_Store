namespace Manage_Store.Service;

public class DateManipulate
{
    public static string ConvertDatetoString(DateTime dateTime)
    {
        string result = $"{dateTime.Day.ToString("00")}-{dateTime.Month.ToString("00")}-{dateTime.Year.ToString("0000")}";
        return result;
    }

    public static DateTime ConvertStringtoDateTime(string stringDate)
    {
        string[] rawDate = stringDate.Split("-");
        int day = int.Parse(rawDate[0]);
        int month = int.Parse(rawDate[1]);
        int year = int.Parse(rawDate[2]);
        return new DateTime(year, month, day);
    }
}