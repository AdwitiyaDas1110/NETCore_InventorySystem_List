using Microsoft.Extensions.Configuration;

namespace OdeToFood
{
    public interface IGreeter
    {
        string GetMessage();
    }
    public class Greeter : IGreeter
    {
        private IConfiguration _config;

        public Greeter(IConfiguration configuration)
        {
            _config = configuration;
        }

        public string GetMessage()
        {
            return _config["GreetUsers"];
        }
    }
}