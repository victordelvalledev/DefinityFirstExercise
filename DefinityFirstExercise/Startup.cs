using DefinityFirstExercise.Contracts;
using DefinityFirstExercise.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;

namespace DefinityFirstExercise
{
    public class Startup
    {
        public Startup()
        {
            var serviceCollection = new ServiceCollection();
            var builder = new ConfigurationBuilder()
                      .SetBasePath(Directory.GetCurrentDirectory())
                      .AddJsonFile("appsettings.json", optional: false);

            IConfiguration config = builder.Build();

            serviceCollection.AddSingleton(config);
            serviceCollection.AddSingleton<IAppConfiguration, AppConfiguration>();
            serviceCollection.AddSingleton<MarblesService>();

            var serviceProvider = serviceCollection.BuildServiceProvider();
            var runApp = serviceProvider.GetService<MarblesService>();

            runApp.RunProcess();
        }
    }
}
