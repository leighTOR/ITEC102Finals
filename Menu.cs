using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ITEC102Finals_SurveyConsoleApp
{
    internal class Menu
    {
        // encapsulated fields and properties
        private string name { get; set; }
        private int age { get; set; }
        private string sex { get; set; }
        private string course { get; set; }
        private int[] answers { get; set; } = new int[10];

        // parameters and constructors for the menu class
        public Menu(string name, int age, string sex, string course, int[] answers)
        {
            this.name = name;
            this.age = age;
            this.sex = sex;
            this.course = course;
            this.answers = answers;
        }

        public void AnswerSurvey()
        {
            // getting the information of the surveyee
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Student's Information");
            Console.ResetColor();
            Console.Write("Name   : ");
            name = Console.ReadLine();
            Console.Write("Age    : ");
            age = Convert.ToInt32(Console.ReadLine());
            Console.Write("Sex:   : ");
            sex = Console.ReadLine();
            Console.Write("Course : ");
            course = Console.ReadLine();

            // instructions for the survey
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nDirections: Please indicate how much you agree or disagree with each of these statements. Just put the number only.");
            Console.ResetColor();
            Console.WriteLine("5 - Strongly Agree\n4 - Agree\n3 - Neutral\n2 - Disagree\n1 - Strongly Disagree");

            // these are the questions and where the users will answer
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nStatements:");

            Console.WriteLine("\nDuring this new normal, online class, in the midst of the pandemic," +
                "\nI've noticed any changes in my physique, particularly in terms of weight.");
            Console.ResetColor();
            Console.Write("Answer: ");
            answers[0] = Convert.ToInt32(Console.ReadLine());

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nI’m losing my appetite.");
            Console.ResetColor();
            Console.Write("Answer: ");
            answers[1] = Convert.ToInt32(Console.ReadLine());

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nI have a habit of procrastinating on my schoolwork.");
            Console.ResetColor();
            Console.Write("Answer: ");
            answers[2] = Convert.ToInt32(Console.ReadLine());

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nI always stay up late to do my schoolwork.");
            Console.ResetColor();
            Console.Write("Answer: ");
            answers[3] = Convert.ToInt32(Console.ReadLine());

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nI was having trouble focusing on my studies and/or work.");
            Console.ResetColor();
            Console.Write("Answer: ");
            answers[4] = Convert.ToInt32(Console.ReadLine());

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nMy anxiety grew as a result of the pressure I put on myself to complete all of the requirements.");
            Console.ResetColor();
            Console.Write("Answer: ");
            answers[5] = Convert.ToInt32(Console.ReadLine());

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nI was unable to maintain a healthy study routine.");
            Console.ResetColor();
            Console.Write("Answer: ");
            answers[6] = Convert.ToInt32(Console.ReadLine());

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nBecause the online course offers a lot of information, it affects my mental state and does not improve my memory.");
            Console.ResetColor();
            Console.Write("Answer: ");
            answers[7] = Convert.ToInt32(Console.ReadLine());

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nMy self-discipline worsened, and my time management suffered as a result.");
            Console.ResetColor();
            Console.Write("Answer: ");
            answers[8] = Convert.ToInt32(Console.ReadLine());

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nI get frustrated when the internet is slow, and as a result, I get stressed and upset.");
            Console.ResetColor();
            Console.Write("Answer: ");
            answers[9] = Convert.ToInt32(Console.ReadLine());

            // below is to show the result of the survey
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n======================");
            Console.WriteLine("Result");
            Console.ResetColor();

            // calling the method inside the same class to calculate to avg
            Total(answers);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("======================");
            Console.ResetColor();

            // instance of the class TextFile
            TextFile txtFile = new TextFile();

            // calling the methods inside the TextFile class to write the surveyee's info right away
            txtFile.WritingInfo(name, age, sex, course, answers);
            txtFile.WritingAge(age);
            txtFile.WritingSex(sex);
            txtFile.WritingCourse(course);

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("\nThank you for answering!");
            Console.ResetColor();
        }

        public void Total(int[] answers)
        {
            // getting the average of all the answers
            double avg = Queryable.Average(answers.AsQueryable());

            // calling the method or the result according to the average avg
            switch (avg)
            {
                case 1:
                    Console.WriteLine("Strongly Disagree");
                    break;
                case 2:
                    Console.WriteLine("Disagree");
                    break;
                case 3:
                    Console.WriteLine("Neutral");
                    break;
                case 4:
                    Console.WriteLine("Agree");
                    break;
                case 5:
                    Console.WriteLine("Strongly Agree");
                    break;
                default:
                    Console.WriteLine("Wrong computation");
                    break;
            }
            // instance of the class TextFile
            TextFile txtFile = new TextFile();

            // calling the method in TextFile Class to write the result
            txtFile.WritingResults(avg);
        }

        // to show less statistics in the console
        public void ShowCurrentStats()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n================================");
            Console.WriteLine("Survey's Statistics");
            Console.ResetColor();

            // getting the number of surveyees by reading the length of ages wrote in its textfile
            string[] ageStats = File.ReadAllLines(@"D:\ITEC102Finals\survey - age.txt");
            int surveyees = ageStats.Length;

            // instance of the class Statistics
            Statistics stats = new Statistics();

            // read the number of surveyee starting from the start in text file
            Console.WriteLine($"\nTotal number of surveyee: {surveyees}");

            // calling the methods in the Statistics class
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nAge");
            Console.ResetColor();
            stats.ReadingAge();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nSex");
            Console.ResetColor();
            stats.ReadingSex();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nCourse");
            Console.ResetColor();
            stats.ReadingCourse();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nResults");
            Console.ResetColor();
            stats.ReadingResults();

            stats.WritingStats();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n================================");
            Console.ResetColor();
        }

        // method for exiting the program
        public void Exit()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Press any key to exit the program...");
            Console.ResetColor();
            Console.ReadKey(true);
        }
    }
}