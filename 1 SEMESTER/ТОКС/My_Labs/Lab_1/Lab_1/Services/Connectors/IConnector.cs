using Lab_1.Services.Connection;

namespace Lab_1.Services.Connectors
{
    public interface IConnector
    {
        byte SourceAddress { get; set; }

        byte DestinationAddress { get; set; }

        bool OpenConnection(IConnectionConfiguration configuration);

        string ReadMessage();

        int WriteMessage(string message, bool isForceWrite = false, bool skipPackaging = false);

        void CloseConnection();

        void ChangeCurrentFlowState(bool isCurrentFlowEnable);

        DebugInfo GetDebugInfo();
    }
}
