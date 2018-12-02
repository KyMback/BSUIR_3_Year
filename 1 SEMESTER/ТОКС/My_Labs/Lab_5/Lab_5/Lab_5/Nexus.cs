using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Lab_5
{
    public partial class Nexus : Form
    {
        protected readonly string MarkerSymbol = "*";

        protected readonly int Delay = 1000;

        protected readonly byte Address;
        protected readonly byte PreviousAddress;
        protected readonly byte NextAddress;

        protected static Package _data;
        protected static object _locker = new object();

        public delegate void DataReceivedHandler(Package data);
        public static event DataReceivedHandler DataReceivedEvent1;
        public static event DataReceivedHandler DataReceivedEvent2;
        public static event DataReceivedHandler DataReceivedEvent3;

        public static Package Data
        {
            get => _data;
            set
            {
                lock (_locker)
                {
                    _data = value;
                }
                //DataReceivedEvent(value);
            }
        }

        public Nexus(byte address, byte previousAddress, byte nextAddress)
        {
            Address = address;
            NextAddress = nextAddress;
            PreviousAddress = previousAddress;
            InitializeComponent();
            switch (address)
            {
                   case 1: DataReceivedEvent1 += DataReceived; break;
                   case 2: DataReceivedEvent2 += DataReceived; break;
                   case 3: DataReceivedEvent3 += DataReceived; break;
            }
           
        }

        protected virtual void DataReceived(Package data)
        {
            if (data.NextAddress != Address)
            {
                return;
            }

            if (data.DestinationAddress != SourceAddress.Text?.ToCharArray().FirstOrDefault())
            {
                ReceivedPackageDebugProcessor(data);
                return;
            }

            ReceivedPackageDebugProcessor(data);
        }

        protected void ReceivedPackageDebugProcessor(Package data)
        {
            data.NextAddress = NextAddress;
            Debug.AppendText(MarkerSymbol);

            Thread.Sleep(Delay);
            //Data = Data;
            Debug.Clear();
            switch (NextAddress)
            {
                case 1: DataReceivedEvent1(Data); break;
                case 2: DataReceivedEvent2(Data); break;
                case 3: DataReceivedEvent3(Data); break;
            }
        }
    }
}
