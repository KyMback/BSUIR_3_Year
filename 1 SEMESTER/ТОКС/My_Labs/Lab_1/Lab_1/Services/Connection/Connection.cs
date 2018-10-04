using System;
using Lab_1.Services.Connectors;

namespace Lab_1.Services.Connection
{
    public class Connection : IDisposable
    {
        private readonly IConnector connector;
        private readonly IConnectionConfiguration connectionConfiguration;

        public bool IsConnectionEstablished { get; private set; }

        public Connection(ConnectionConfiguration connectionConfiguration)
        {
            this.connectionConfiguration = connectionConfiguration;

            connector = ConnectionProvider.GetConnector(connectionConfiguration.ConnectionType);
            IsConnectionEstablished = connector.OpenConnection(connectionConfiguration);
        }

        public string ReadMessage()
        {
            return connector.ReadMessage();
        }

        public void WriteMessage(string message)
        {
            if (IsConnectionEstablished || (IsConnectionEstablished = RestoreConnection()))
            {
                connector.WriteMessage(message);
            }
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
