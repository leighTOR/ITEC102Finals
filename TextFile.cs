using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ITEC102Finals_SurveyConsoleApp
{
    internal class TextFile
    {
        public void WritingInfo(string name, int age, string sex, string course, int[] answers)
        {
            // getting the average of all the answers
            double avg = Queryable.Average(answers.AsQueryable());
            int total = (int)Math.Round(avg);

            // writing students' information and their answers in a text file
            // i used append method in all the files to get all the updated information by the users
            FileStream fs = new FileStream(@"D:\ITEC102Finals\survey - info.txt", FileMode.Append, FileAccess.Write);
            using (StreamWriter sw = new StreamWriter(fs))
            {
                // this is to get the place number of surveyee and appends it
                int num = 0;
                if (File.Exists(@"D:\ITEC102Finals\survey - age.txt"))
                {
                    string[] surveyee = File.ReadAllLines(@"D:\ITEC102Finals\survey - age.txt");
                    num = surveyee.Length;
                }

                sw.WriteLine($"Surveyee #{num + 1}"); // to show what number the surveyee is 
                // info of surveyee
                sw.WriteLine($"Name   : {name}");
                sw.WriteLine($"Age    : {age}");
                sw.WriteLine($"Sex    : {sex}");
                sw.WriteLine($"Course : {course}");

                // answers of surveyee
                sw.WriteLine("Answers:");
                foreach (int ans in answers)
                {
                    // so the int ans will be converted into equivalent string
                    string ansString;
                    switch (ans)
                    {
                        case 1:
                            ansString = "Strongly Disagree";
                            sw.WriteLine("         " + ansString);
                            break;
                        case 2:
                            ansString = "Disagree";
                            sw.WriteLine("         " + ansString);
                            break;
                        case 3:
                            ansString = "Neutral";
                            sw.WriteLine("         " + ansString);
                            break;
                        case 4:
                            ansString = "Agree";
                            sw.WriteLine("         " + ansString);
                            break;
                        case 5:
                            ansString = "Strongly Agree";
                            sw.WriteLine("         " + ansString);
                            break;
                        default:
                            sw.WriteLine("         Wrong output");
                            break;
                    }
                }

                // writing the result or the average of the surveyees' answers
                sw.Write("\nResult : ");
                switch (total)
                {
                    case 1:
                        sw.WriteLine("Strongly Disagree");
                        break;
                    case 2:
                        sw.WriteLine("Disagree");
                        break;
                    case 3:
                        sw.WriteLine("Neutral");
                        break;
                    case 4:
                        sw.WriteLine("Agree");
                        break;
                    case 5:
                        sw.WriteLine("Strongly Agree");
                        break;
                    default:
                        sw.WriteLine("Wrong output");
                        break;
                }
                sw.WriteLine("\n==============================");
                sw.Close();
            }
            fs.Close();
        }

        public void WritingResults(double avg)
        {
            // writing the results of each surveyees in a seprate text file
            using (StreamWriter sr = File.AppendText(@"D:\ITEC102Finals\survey - results.txt"))
            {
                sr.WriteLine(avg);
                sr.Close();
            }
        }

        public void WritingAge(int age)
        {
            // writing age of the surveyees in a separate text file
            using (StreamWriter sa = File.AppendText(@"D:\ITEC102Finals\survey - age.txt"))
            {
                sa.WriteLine(age);
                sa.Close();
            }
        }

        public void WritingSex(string sex)
        {
            // writing the sex of the surveyee in a separate text file
            using (StreamWriter ss = File.AppendText(@"D:\ITEC102Finals\survey - sex.txt"))
            {
                ss.WriteLine(sex.ToUpper());
                ss.Close();
            }
        }

        public void WritingCourse(string course)
        {
            // writing the course of the surveyees in a separate text file
            using (StreamWriter sc = File.AppendText(@"D:\ITEC102Finals\survey - course.txt"))
            {
                sc.WriteLine(course.ToUpper());
                sc.Close();
            }
        }
    }
}