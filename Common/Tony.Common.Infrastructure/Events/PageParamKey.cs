namespace Tony.Common.Infrastructure.Events
{
    public enum PageParamKey
    {
        None = 0,
        FormalPage = 1,
        Seat = 2,
        SeatType,
        Event,
        EventDetail,
        Ticket,
        EventTicket,
        Account,
        Income,
        Expenditure,
        Transfer
    }

    public enum SeatStatus
    {
        Available, NotAvailable, Sold
    }
}
