
namespace Exercise5LexiconGarage
{
    internal class UI
    {
        internal static void MainMenu()
        {
            bool programRun = true;
            do
            {
                Console.WriteLine("1. Create garage and its capacity");
                Console.WriteLine("2. Choose garage to use and go to its submenu: ");
                Console.WriteLine("3. Exit the program");

                var input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        throw new NotImplementedException();
                        break;
                    case "2":
                        throw new NotImplementedException();
                        break;
                    case "3":
                        programRun = false;
                        break;

                }
            }while (programRun);


        }
    }
}