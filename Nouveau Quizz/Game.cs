using Nouveau_Quizz.classes;
using System;

namespace Nouveau_Quizz
{
    internal class Game
    {
        //read questions from jsconfig1
        public static Quiz quiz = JsonFileManage.GetJson();
        public static int score;
        private static string[] GetQuestions()
        {
            string[] questions = quiz.Questions[quiz.Questions.Count - 1];
            return questions;
        }
        /**
         * 
         * */
        private static string[] GetRightAnswers()
        {
            string[] rightanswers = quiz.RightAnswers[quiz.RightAnswers.Count - 1];
            return rightanswers;
        }
        /**
         * Displays questions and gets user answers
         * arg: string[] questions : Array of questions to ask
         * arg: string[] rightanswers : Array of right answers to compare the user answers to
         * returns: user answers to the questions
         * */
        private static string[] AskQuestions(string[] questions, string[] rightanswers)
        {
            string[] userAnswers = new string[5];

            foreach (string question in questions)
            {
                Console.Clear();
                //Display question
                Console.WriteLine(question);
                //Read user answer and writes it to userAnswers
                userAnswers[Array.IndexOf(questions, question)] = Console.ReadLine();
                //Check if user answer is right (I.E. equal to right answer)
                if (CheckAnswer(userAnswers[Array.IndexOf(questions, question)].ToLower(),rightanswers[Array.IndexOf(questions, question)].ToLower()))
                {score++;}
                //Next Question
                if (Array.IndexOf(questions, question) != questions.Length - 1)
                {
                    Console.WriteLine("Question Suivante...");
                    Console.ReadKey();
                }
            }
            //adds questions list index at last index of userAnswers
            userAnswers[userAnswers.Length - 1] = Convert.ToString(quiz.Questions.Count - 1);
            //Display score
            Console.Clear();
            Console.WriteLine($"Quiz Terminé !\nScore : {score}");
            Console.ReadKey();
            return userAnswers;
        }
        public static void Play()
        {
            //Gameloop:
            score = 0;
            string[] userAnswers = AskQuestions(GetQuestions(), GetRightAnswers());
            //adds user answers to the userAnswers List in quiz object
            quiz.UserAnswers.Add(userAnswers);
            //Add score to admin stats
            int successNumber = Convert.ToInt32(quiz.Data.AboveAverageNbr);
            if(score >= 3)
            {
                successNumber++;
                quiz.Data.AboveAverageNbr = Convert.ToString(successNumber);
            }
            //Increment number of attempts
            int tryNumber = Convert.ToInt32(quiz.Data.Try);
            tryNumber ++;
            quiz.Data.Try = Convert.ToString(tryNumber);
            quiz.Data.SuccessRate = Convert.ToString(SuccessRate(tryNumber, successNumber));
            //save user answers to jsconfig1
            JsonFileManage.SetJson(quiz);
            //proposer de rejour(r) ou de retourner au menu(q)
            bool endgame = false;
            while (!endgame)
            {
                Console.Clear();
                Console.WriteLine("Souhaitez vous (r)ejouer ou (q)uitter ?");
                ConsoleKeyInfo cki = Console.ReadKey();
                if (cki.Key == ConsoleKey.R)
                {
                    endgame = true;
                    Play();
                }
                else if (cki.Key == ConsoleKey.Q)
                {
                    endgame = true;
                    //Return to main menu
                    return;
                }
            }
        }
        public static double SuccessRate(int tryNbr, int successNbr)
        {
            double successRate = Convert.ToDouble(successNbr) / Convert.ToDouble(tryNbr);
            return successRate;
        }
        /**
         * Checks if user answer contains the right answer
         * returns: "true" if user answer contains the right answer, "false" if not
         * */
        public static bool CheckAnswer(string userAnswer, string rightAnswer)
        {
            if (userAnswer.Contains(rightAnswer))
            {
                return true;
            } else return false;
        }
    }
}
