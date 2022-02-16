namespace ITEC102Finals_SurveyConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // wrote in Visual Studio 2022
            try
            {
                Console.Title = "Survey";
                // variables to store surveyee's data
                string name = "";
                int age = 0;
                string sex = "";
                string course = "";
                int[] answers = new int[10];

                // instance of the class Menu with arguments
                Menu menu = new Menu(name, age, sex, course, answers);

                // first thing to show, welcoming part
                Console.WriteLine("Survey on CCS's Freshman Students' Mental Well-being\n");

                int i = 0;
                while (i >= 0) // to loop until there's nothing to do or hits the break
                {
                    // menu that will be displayed to the user
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("==MENU==");
                    Console.WriteLine("[A]NSWER SURVEY\n[S]HOW CURRENT STATISTICS\n[E]XIT");
                    Console.ResetColor();
                    Console.Write("Enter your choice: ");
                    char c = Convert.ToChar(Console.ReadLine().ToUpper());
                    Console.WriteLine();

                    // to call out the method according to the choice
                    if (c == 'A')
                        menu.AnswerSurvey();
                    else if (c == 'S')
                        menu.ShowCurrentStats();
                    else
                    {
                        if (c == 'E')
                        {
                            menu.Exit();
                            break;
                        }
                        Console.WriteLine("Wrong input.");
                    }
                    Console.WriteLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message); // so that the errors would be catch
            }
        }
    }
}