

namespace Exercise5LexiconGarage
{
    public class ManagerAPP
    {
        private UI ui;

        public ManagerAPP()
        {
            ui = new UI();
        }

        public void RunProgram()
        {
            ui.DisplayMainMenu();
        }
    }
}