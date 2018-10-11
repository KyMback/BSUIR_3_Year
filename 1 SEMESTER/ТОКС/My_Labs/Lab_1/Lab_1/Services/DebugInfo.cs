namespace Lab_1.Services
{
    public class DebugInfo
    {
        public bool IsCurrentPortBusy { get; set; }

        public bool IsAnotherPortBusy { get; set; }

        public bool IsConnectionEstablished { get; set; }

        public string LatestMessage { get; set; }

        public bool IsPortsInitialized { get; set; }
    }
}
