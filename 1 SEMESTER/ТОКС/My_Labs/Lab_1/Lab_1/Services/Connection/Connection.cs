using System;
using Lab_1.Services.Connectors;

namespace Lab_1.Services.Connection
{
    public class Connection : IDisposable
    {
        private readonly IConnector connector;
        private readonly IConnectionConfiguration connectionConfiguration;

        public bool IsConnectionEstablished { get; private set; }

        public int OutputBytes { get; private set; }

        public int InputBytes { get; private set; }

        public Connection(ConnectionConfiguration connectionConfiguration)
        {
            this.connectionConfiguration = connectionConfiguration;

            connector = ConnectionProvider.GetConnector(connectionConfiguration.ConnectionType);
            IsConnectionEstablished = connector.OpenConnection(connectionConfiguration);
            ChangeFlowState(true);
        }

        public string ReadMessage()
        {
            string message = connector.ReadMessage();
            InputBytes += message.Length;
            return message;
        }

        public int WriteMessage(string message)
        {
            if (IsConnectionEstablished || (IsConnectionEstablished = RestoreConnection()))
            {
                int number = connector.WriteMessage(message);
                OutputBytes += number;
                return number;
            }

            return 0;
        }

        public bool RestoreConnection()
        {
            connector.CloseConnection();
            return connector.OpenConnection(connectionConfiguration);
        }

        public void Dispose()
        {
            connector?.CloseConnection();
        }

        public void ChangeFlowState(bool isBusy)
        {
            if (!IsConnectionEstablished)
            {
                return;
            }
            connector.ChangeCurrentFlowState(!isBusy);
        }

        public DebugInfo GetDebugInfo()
        {
            return connector.GetDebugInfo();
        }
    }
}
