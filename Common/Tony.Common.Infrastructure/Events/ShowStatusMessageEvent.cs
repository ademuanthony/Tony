namespace Tony.Common.Infrastructure.Events
{
    public class ShowStatusMessageEvent
    {
        string _message = "Ready";
        public string Message { get { return _message; } set { _message = value; } }

        public bool IsError { get; set; }

        bool? _showProgressBar;
        public bool? ShowProgressBar { get { return _showProgressBar; }
            set { _showProgressBar = value; }
        }

        public string Title { get; set; }
    }
}
