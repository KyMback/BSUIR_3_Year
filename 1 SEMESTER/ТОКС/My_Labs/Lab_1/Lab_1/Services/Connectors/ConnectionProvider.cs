using Lab_1.Enums;

namespace Lab_1.Services.Connectors
{
    public class ConnectionProvider
    {
        public static IConnector GetConnector(ConnectionType connectionType)
        {
            return new ComConnector();
        }
    }
}
