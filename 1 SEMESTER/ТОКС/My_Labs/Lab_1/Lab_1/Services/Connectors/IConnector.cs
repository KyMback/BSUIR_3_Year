using Lab_1.Services.Connection;

namespace Lab_1.Services.Connectors
{
    public interface IConnector
    {
        bool OpenConnection(IConnectionConfiguration configuration);

        string ReadMessage();

        void WriteMessage(string message);

        void CloseConnection();

        void ChangeCurrentFlowState(bool isCurrentFlowEnable);

        DebugInfo GetDebugInfo();
    }
}
