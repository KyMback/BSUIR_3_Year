using System;
using System.Threading;
using System.Windows.Forms;

namespace Lab_4
{
    public partial class Lab_4 : Form
    {
        private Random Random { get; }
        private string Buffer { get; set; }

        private const int Pwd = 50;
        private const int MaximumAttempts = 10;
        private const string CollisionSymbol = "X";

        private bool IsChannelFree() => Random.Next(0, 2) == 1;

        private bool IsCollisionOccured() => Random.Next(0, 3) != 1;

        private int GetDelayForCollisionWaiting(int count) =>
            Random.Next(0, (int) Math.Pow(2, Math.Min(count, MaximumAttempts))) * 10;

        public Lab_4()
        {
            InitializeComponent();
            Random = new Random();
        }

        private void SendButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(InputTextBox.Text))
            {
                return;
            }
            var data = InputTextBox.Text.ToCharArray();
            InputTextBox.Clear();

            foreach (var symbol in data)
            {
                int counter = 0;
                bool flag;
                while (!(flag = TryToSend(symbol)))
                {
                    counter++;
                    if (counter > MaximumAttempts)
                    {
                        break;
                    }
                    Thread.Sleep(GetDelayForCollisionWaiting(counter));
                }
                if(flag){
                    OutputTextBox.AppendText(Buffer);
                }              
                Buffer = string.Empty;
                DebugTextBox.AppendText(Environment.NewLine);
            }
            OutputTextBox.AppendText(Environment.NewLine);
        }

        private bool TryToSend(char data)
        {
            while (!IsChannelFree()) { }
            Thread.Sleep(Pwd);
            if(string.IsNullOrEmpty(Buffer)){
                Buffer += data.ToString();
            }
            if (IsCollisionOccured())
            {
                DebugTextBox.AppendText(CollisionSymbol);
                return false;
            }
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InputTextBox.Clear();
            OutputTextBox.Clear();
            DebugTextBox.Clear();
        }
    }
}
