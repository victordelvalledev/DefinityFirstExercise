using DefinityFirstExercise.Contracts;
using Microsoft.Extensions.Configuration;

namespace DefinityFirstExercise.Repository
{
    class AppConfiguration : IAppConfiguration
    {
        private IConfiguration _config;

        public AppConfiguration(IConfiguration config)
        {
            this._config = config;
        }
        public string OrderList
        {
            get
            {
                var value = _config["OrderList"];
                return value;
            }
            set { }
        }
    }
}
