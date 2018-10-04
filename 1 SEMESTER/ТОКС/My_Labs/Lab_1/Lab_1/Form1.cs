using System;
using System.IO.Ports;
using System.Windows.Forms;
using Lab_1.Enums;
using Lab_1.Services.Connection;
using Lab_1.Services.Utils;

namespace Lab_1
{
    public partial class ComChat : Form
    {
        public Connection Connection { get; set; }

        public ConnectionConfiguration ConnectionConfiguration { get; set; }

        public ComChat()
        {
            InitializeComponent();
            ConnectionConfiguration = new ConnectionConfiguration
            {
                ConnectionType = ConnectionType.ComConnection,
                DataReceivedHandler = ReceiveDataHandler
            };
            AvailablePorts.Items.AddRange(ComPortsUtils.GetAllComPorts());
        }

        private void ReceiveDataHandler(object sender, SerialDataReceivedEventArgs args)
        {
            string message = Connection.ReadMessage();
            if (string.IsNullOrEmpty(message))
            {
                XOnXOffButton.Enabled = !Connection.GetDebugInfo().IsAnotherPortBusy;
                return;
            }
            NumberOfInputBytes.Text = message.Length.ToString();
            OutputTextBox.AppendText(message);
            OutputTextBox.AppendText(Environment.NewLine);
        }

        private void ComPorts_DropDownChanged(object sender, EventArgs e)
        {
            var portName = (sender as ComboBox).SelectedItem.ToString();
            if (ConnectionConfiguration.ConnectionName == portName)
            {
                return;
            }

            SendButton.Enabled = true;
            ClearTextBoxes();
            Connection?.Dispose();
            ConnectionConfiguration.ConnectionName = portName;
            Connection = new Connection(ConnectionConfiguration);
        }

        private void SendButton_Click(object sender, EventArgs e)
        {
            var text = InputTextBox.Text;
            NumberOfOutputBytes.Text = text.Length.ToString();
            Connection.WriteMessage(text);
        }

        private void ClearTextBoxes()
        {
            InputTextBox.Clear();
            OutputTextBox.Clear();
            NumberOfInputBytes.Text = 0.ToString();
            NumberOfOutputBytes.Text = 0.ToString();
        }

        private void XOnXOffButton_Click(object sender, EventArgs e)
        {
            Connection?.ChangeFlowState(!Connection.GetDebugInfo().IsCurrentPortBusy);

            XOnXOffButton.Text = Connection?.GetDebugInfo().IsCurrentPortBusy ?? false
                ? "Send XOn"
                : "Send XOff";
        }
    }
}
