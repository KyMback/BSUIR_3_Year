﻿using System;
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
                return;
            }

            NumberOfInputBytes.Text = Connection.InputBytes.ToString();
            OutputTextBox.AppendText(message);
            OutputTextBox.AppendText(Environment.NewLine);
        }

        private void SendButton_Click(object sender, EventArgs e)
        {
            if (Connection.WriteMessage(InputTextBox.Text) != 0)
            {
                InputTextBox.Clear();
            }

            if (Connection.GetDebugInfo().Package != null)
            {
                PackageInfoTextBox.AppendText(BitConverter.ToString(Connection.GetDebugInfo().Package));
                PackageInfoTextBox.AppendText(Environment.NewLine);
            }

            NumberOfOutputBytes.Text = Connection.OutputBytes.ToString();
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

            ChangeXOnXOffState();
        }

        private void Open_port_button_Click(object sender, EventArgs e)
        {
            var portName = AvailablePorts.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(portName))
            {
                return;
            }
            Connection?.ChangeAddresses((byte)SourceAddress.Value, (byte)DestinationAddress.Value);
            ConnectionConfiguration.ConnectionName = portName;
            Connection = new Connection(ConnectionConfiguration);
            if (!Connection.IsConnectionEstablished)
            {
                MessageBox.Show(Connection.GetDebugInfo().LatestMessage, "Error");
                Close_port_button_Click(null, null);
                return;
            }
            ChangeCurrentStateOfPort(true);
        }

        private void Close_port_button_Click(object sender, EventArgs e)
        {
            ClearTextBoxes();
            Connection?.Dispose();
            Connection = null;
            ChangeCurrentStateOfPort(false);
        }

        private void ChangeCurrentStateOfPort(bool isNeedToOpen)
        {
            SendButton.Enabled = isNeedToOpen;
            Close_port_button.Enabled = isNeedToOpen;
            Open_port_button.Enabled = !isNeedToOpen;
            AvailablePorts.Enabled = !isNeedToOpen;
            XOnXOffButton.Enabled = isNeedToOpen;
            ChangeXOnXOffState();
        }

        private void ChangeXOnXOffState()
        {
            XOnXOffButton.Text = Connection?.GetDebugInfo().IsCurrentPortBusy ?? true
                ? "Send XOn"
                : "Send XOff";
        }

        private void SourceAddressChanged(object sender, EventArgs e)
        {
            Connection?.ChangeAddresses((byte)SourceAddress.Value, (byte)DestinationAddress.Value);
        }

        private void DestinationAddress_ValueChanged(object sender, EventArgs e)
        {
            Connection?.ChangeAddresses((byte)SourceAddress.Value, (byte)DestinationAddress.Value);
        }
    }
}
