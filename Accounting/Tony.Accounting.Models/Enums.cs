namespace Tony.Accounting.Models
{

    public enum RecurrenceCircle
    {
        Daily = 0,
        Weekly = 1,
        BiWeekly = 2,
        EveryFourWeeks = 3,
        Monthly = 4,
        BiMonthly = 5,
        TriMonthly = 6,
        EverySixMonths = 7,
        Yearly = 8
    }

    public enum RecurrenceType 
    {
        Income = 0, Expenditure = 1 
    }
}
