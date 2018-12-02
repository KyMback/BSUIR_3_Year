namespace Lab_5
{
    public class Package
    {
        // 0 - Token , 1 - Frame
        public bool Control { get; set; }

        public byte DestinationAddress { get; set; }

        public byte SourceAddress { get; set; }

        // 0 - default, 1 - data was read
        public bool Status { get; set; }

        // 0- default, 1 - Monitors flag
        public bool Monitor { get; set; }

        public byte Data { get; set; }

        public byte NextAddress { get; set; }
    }
}
