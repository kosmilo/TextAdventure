namespace TextAdventure
{
    static class MainMenu
    {
        public static void ShowMenu()
        {
            Thread.Sleep(400);
            Console.Clear();
            Console.WriteLine(@"
.---. 
: .; :
:  _.'
: :   
:_;   

            ");
            Thread.Sleep(200);
            Console.Clear();
            Console.WriteLine(@"
.---.  
: .; : 
:  _.'.-..-.
: :   : :; :
:_;   `.__.'

");
            Thread.Sleep(200);
            Console.Clear();

            Console.WriteLine(@"
.---.       .-.       
: .; :      : :   
:  _.'.-..-.: :    
: :   : :; :: :_ 
:_;   `.__.'`.__;

");
            Thread.Sleep(200);
            Console.Clear();

            Console.WriteLine(@"
.---.       .-.        
: .; :      : :       
:  _.'.-..-.: :   .--. 
: :   : :; :: :_ '  ..'
:_;   `.__.'`.__;`.__.'

");
            Thread.Sleep(200);
            Console.Clear();

            Console.WriteLine(@"
.---.       .-.        .-.       
: .; :      : :        : :      
:  _.'.-..-.: :   .--. : `-. 
: :   : :; :: :_ '  ..': .. :
:_;   `.__.'`.__;`.__.':_;:_;

");
            Thread.Sleep(200);
            Console.Clear();

            Console.WriteLine(@"
.---.       .-.        .-.        
: .; :      : :        : :       
:  _.'.-..-.: :   .--. : `-. .--. 
: :   : :; :: :_ '  ..': .. :: ..'
:_;   `.__.'`.__;`.__.':_;:_;:_;  

");
            Thread.Sleep(200);
            Console.Clear();

            Console.WriteLine(@"
.---.       .-.        .-.         _  
: .; :      : :        : :        :_;
:  _.'.-..-.: :   .--. : `-. .--. .-.
: :   : :; :: :_ '  ..': .. :: ..': :
:_;   `.__.'`.__;`.__.':_;:_;:_;  :_;

");
            Thread.Sleep(200);
            Console.Clear();

            Console.WriteLine(@"
.---.       .-.        .-.         _  .-.  
: .; :      : :        : :        :_;.' `. 
:  _.'.-..-.: :   .--. : `-. .--. .-.`. .'
: :   : :; :: :_ '  ..': .. :: ..': : : : 
:_;   `.__.'`.__;`.__.':_;:_;:_;  :_; :_; 

");
            Thread.Sleep(200);
            Console.Clear();

            Console.WriteLine(@"
.---.       .-.        .-.         _  .-.         
: .; :      : :        : :        :_;.' `.        
:  _.'.-..-.: :   .--. : `-. .--. .-.`. .'.-..-. 
: :   : :; :: :_ '  ..': .. :: ..': : : : : :; :
:_;   `.__.'`.__;`.__.':_;:_;:_;  :_; :_; `.__.'

");
            Thread.Sleep(200);
            Console.Clear();

            Console.WriteLine(@"
.---.       .-.        .-.         _  .-.          .-.      
: .; :      : :        : :        :_;.' `.         : :      
:  _.'.-..-.: :   .--. : `-. .--. .-.`. .'.-..-. .-' :
: :   : :; :: :_ '  ..': .. :: ..': : : : : :; :' .; :
:_;   `.__.'`.__;`.__.':_;:_;:_;  :_; :_; `.__.'`.__.'

");
            Thread.Sleep(200);
            Console.Clear();

            Console.WriteLine(@"
.---.       .-.        .-.         _  .-.          .-.      
: .; :      : :        : :        :_;.' `.         : :      
:  _.'.-..-.: :   .--. : `-. .--. .-.`. .'.-..-. .-' : .--. 
: :   : :; :: :_ '  ..': .. :: ..': : : : : :; :' .; :' .; :
:_;   `.__.'`.__;`.__.':_;:_;:_;  :_; :_; `.__.'`.__.'`.__.'

");
            Thread.Sleep(200);

            while (true)
            {
                Console.Clear();
                Console.WriteLine(@"
.---.       .-.        .-.         _  .-.          .-.      
: .; :      : :        : :        :_;.' `.         : :      
:  _.'.-..-.: :   .--. : `-. .--. .-.`. .'.-..-. .-' : .--. 
: :   : :; :: :_ '  ..': .. :: ..': : : : : :; :' .; :' .; :
:_;   `.__.'`.__;`.__.':_;:_;:_;  :_; :_; `.__.'`.__.'`.__.'

");
                Writer.WriteTxt(TextEdit.hintClr + "Use up and down arrows to change selection. Press ENTER to confirm. ", isInstant: true);
                List<string> menuChoices = new List<string>{ "New Game", "Continue", "Credits", "Quit" };
                int choice = InputReader.GetChoice(menuChoices);

                switch (choice)
                {
                    case 0:
                        ChapterZero.Play();
                        break;
                    case 1:
                        UserData save = SaveHandler.GetSave();
                        if (save != null) {
                            ChapterUtils.PlayChapter(save);
                        }
                        break;
                    case 2:
                        Credits.RollCredits();
                        break;
                    case 3:
                        Environment.Exit(0);
                        break;
                    default:
                        Writer.WriteTxt("Wait what... ? That's not an option!");
                        break;
                }
            }
        }
    }
}
