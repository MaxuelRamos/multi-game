namespace Stores
{
    public class AppStore : Singleton<AppStore>
    {
        private static readonly string SERVER_ADDRESS = "http://localhost:3000/api";

        public string ServerAddress => SERVER_ADDRESS;
    }
}