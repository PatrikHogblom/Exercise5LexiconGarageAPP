namespace Exercise5LexiconGarage
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var manager = new ManagerAPP();
                manager.RunProgram();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            //Console.ReadLine();
        }
    }
}
