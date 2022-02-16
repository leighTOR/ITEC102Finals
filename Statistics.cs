using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.IO;

namespace ITEC102Finals_SurveyConsoleApp
{
    internal class Statistics
    {
        int eighteen;
        int nineteen;
        int twenty;

        int female;
        int male;

        int bscs;
        int bsis;
        int bsit;

        int stronglyAgree;
        int agree;
        int neutral;
        int disagree;
        int stronglyDisagree;

        string[] arrayAge = File.ReadAllLines(@"D:\ITEC102Finals\survey - age.txt");

        // method for reading the age in the text file to show the statistics
        public void ReadingAge()
        {
            using (StreamReader readAge = new StreamReader(@"D:\ITEC102Finals\survey - age.txt"))
            {
                string contentsAge = readAge.ReadToEnd();

                MatchCollection _eighteen = Regex.Matches(contentsAge, @"(?i)\b18\b");
                eighteen = (int)Math.Round((double)(100 * _eighteen.Count) / arrayAge.Length);
                Console.WriteLine($"18: {eighteen}%");

                MatchCollection _nineteen = Regex.Matches(contentsAge, @"(?i)\b19\b");
                nineteen = (int)Math.Round((double)(100 * _nineteen.Count) / arrayAge.Length);
                Console.WriteLine($"19: {nineteen}%");

                MatchCollection _twenty = Regex.Matches(contentsAge, @"(?i)\b20\b");
                twenty = (int)Math.Round((double)(100 * _twenty.Count) / arrayAge.Length);
                Console.WriteLine($"20: {twenty}%");
            }
        }

        // method for reading the sex of surveyee in the text file for statistics
        public void ReadingSex()
        {
            using (StreamReader readSex = File.OpenText(@"D:\ITEC102Finals\survey - sex.txt"))
            {
                string contentsSex = readSex.ReadToEnd();
                string[] arraySex = File.ReadAllLines(@"D:\ITEC102Finals\survey - sex.txt");

                MatchCollection _female = Regex.Matches(contentsSex, @"(?i)\bFEMALE\b");
                female = (int)Math.Round((double)(100 * _female.Count) / arraySex.Length);
                Console.WriteLine($"Female: {female}%");

                MatchCollection _male = Regex.Matches(contentsSex, @"(?i)\bMALE\b");
                male = (int)Math.Round((double)(100 * _male.Count) / arraySex.Length);
                Console.WriteLine($"Male  : {male}%");
            }
        }

        // method for reading the course of surveyee inside the text file for statistics
        public void ReadingCourse()
        {
            using (StreamReader readCourse = File.OpenText(@"D:\ITEC102Finals\survey - course.txt"))
            {
                string contentsCourse = readCourse.ReadToEnd();
                string[] arrayCourse = File.ReadAllLines(@"D:\ITEC102Finals\survey - course.txt");

                MatchCollection _bscs = Regex.Matches(contentsCourse, @"(?i)\bBSCS\b");
                bscs = (int)Math.Round((double)(100 * _bscs.Count) / arrayCourse.Length);
                Console.WriteLine($"BSCS: {bscs}%");

                MatchCollection _bsis = Regex.Matches(contentsCourse, @"(?i)\bBSIS\b");
                bsis = (int)Math.Round((double)(100 * _bsis.Count) / arrayCourse.Length);
                Console.WriteLine($"BSIS: {bsis}%");

                MatchCollection _bsit = Regex.Matches(contentsCourse, @"(?i)\bBSIT\b");
                bsit = (int)Math.Round((double)(100 * _bsit.Count) / arrayCourse.Length);
                Console.WriteLine($"BSIT: {bsit}%");
            }
        }

        // method for reading the results of the surveyees inside the text file for statistics
        public void ReadingResults()
        {
            using (StreamReader readResults = File.OpenText(@"D:\ITEC102Finals\survey - results.txt"))
            {
                string contentResults = readResults.ReadToEnd();
                string[] arrayResults = File.ReadAllLines(@"D:\ITEC102Finals\survey - results.txt");

                MatchCollection _stronglyAgree = Regex.Matches(contentResults, @"(?i)\b5\b");
                stronglyAgree = (int)Math.Round((double)(100 * _stronglyAgree.Count) / arrayResults.Length);
                Console.WriteLine($"Strongly Agree   : {stronglyAgree}%");

                MatchCollection _agree = Regex.Matches(contentResults, @"(?i)\b4\b");
                agree = (int)Math.Round((double)(100 * _agree.Count) / arrayResults.Length);
                Console.WriteLine($"Agree            : {agree}%");

                MatchCollection _neutral = Regex.Matches(contentResults, @"(?i)\b3\b");
                neutral = (int)Math.Round((double)(100 * _neutral.Count) / arrayResults.Length);
                Console.WriteLine($"Neutral          : {neutral}%");

                MatchCollection _disagree = Regex.Matches(contentResults, @"(?i)\b2\b");
                disagree = (int)Math.Round((double)(100 * _disagree.Count) / arrayResults.Length);
                Console.WriteLine($"Disagree         : { disagree}%");

                MatchCollection _stronglyDisagree = Regex.Matches(contentResults, @"(?i)\b1\b");
                stronglyDisagree = (int)Math.Round((double)(100 * _stronglyDisagree.Count) / arrayResults.Length);
                Console.WriteLine($"Strongly Disagree: {stronglyDisagree}%");
            }
        }

        // method for writing the stats in a separate text file
        public void WritingStats()
        {
            using (StreamWriter ss = new StreamWriter(@"D:\ITEC102Finals\survey - statistics.txt"))
            {
                ss.WriteLine("Survey's Statistics");
                ss.WriteLine($"\nTotal number of surveyee: {arrayAge.Length}");
                ss.WriteLine("\nAge");
                ss.WriteLine($"18: {eighteen}%");
                ss.WriteLine($"19: {nineteen}%");
                ss.WriteLine($"20: {twenty}%");

                ss.WriteLine("\nSex");
                ss.WriteLine($"Female: {female}%");
                ss.WriteLine($"Male  : {male}%");

                ss.WriteLine("\nCourse");
                ss.WriteLine($"BSCS: {bscs}%");
                ss.WriteLine($"BSIS: {bsis}%");
                ss.WriteLine($"BSIT: {bsit}%");

                ss.WriteLine("\nResults");
                ss.WriteLine($"Strongly Agree   : {stronglyAgree}%");
                ss.WriteLine($"Agree            : {agree}%");
                ss.WriteLine($"Neutral          : {neutral}%");
                ss.WriteLine($"Disagree         : { disagree}%");
                ss.WriteLine($"Strongly Disagree: {stronglyDisagree}%");
            }
        }
    }
}