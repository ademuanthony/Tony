namespace Tony.Common.Infrastructure.Events
{
    public enum AppProccessingEventType
    {
        ProccessStarted,
        ProccessEnded
    }
    public class AppProccessingEvent
    {
        public string Message { get; set; }

        public AppProccessingEventType AppProccessingEventType { get; set; }
    }
}
