namespace IntegraQnest.Client.Services
{
    public class UserState
    {
        private string _status = "Online";
        public string Status
        {
            get => _status;
            set
            {
                if (_status != value)
                {
                    _status = value;

                    if (this is { Status: "DND" })
                    {
                        Console.WriteLine("🔕 User does not want to be disturbed.");
                    }
                    else if (this is { Status: "Away" })
                    {
                        Console.WriteLine("🕓 User is away. Consider delaying notifications.");
                    }

                    NotifyStateChanged();
                }
            }
        }

        public event Action? OnChange;

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
