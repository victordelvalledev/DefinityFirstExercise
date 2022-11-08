using System;

namespace DefinityFirstExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            var statup = new Startup();

            Console.ReadKey();

            //The main algorithm is in the folder Services-->MarblesService

            ////Time and space complexity: The algorithm will be executed N times(In this case 10).
            ////the data will be filtered with LINQ, where the system will manipulate the objects to prevent leaks on the memory.
            ///
            ////Deployment strategy: My deployment strategy will be to upload the application on Azure as a REST services 
            ////or azure function.I think that hosting the app on azure will bring us a good performance
            ////because if more CPU power or memory is necessary it will be given to the app almost automatically.

            ////Millions of marbles: If the list of marbles would millions, I think the app will process them with more CPU and memory.  
            ////Maybe it will be a good Idea to process the list concurrently.


        }
    }
}
