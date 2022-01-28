using Nouveau_Quizz.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nouveau_Quizz
{
    internal class Admin
    {
        public static Quiz Quiz = JsonFileManage.GetJson();
        public static void displayAdmin()
        {
            Console.Clear();
            Console.WriteLine("Saisissez 1, 2 ou 3 pour faire votre choix : ");
            Console.WriteLine("1. Ajoutez un questionnaire.");
            Console.WriteLine("2. Afficher les stats des questionnaires.");
            Console.WriteLine("4. Afficher les questionnaires");
            string choice = Console.ReadLine();
            Console.Clear();
            switch (choice)
            {
                case "1":
                    SurveyManager();
                    break;
                case "2":
                    QuizData.ShowData(Quiz.Data);
                    break;
                case "3":
                    break;
                default:
                    break;
            }
        }
        //Crée un nouveau questionnaire et l'ajout au fichier Json
        public static void SurveyManager()
        {
            Console.Clear();
            List<string> NewQuestionlist = new List<string>();
            List<string> NewAnswerList = new List<string>();
            for(int i = 1; i <= 4; i++)
            {
                Console.Clear();
                Console.WriteLine($"Saisissez la question {i} : ");
                NewQuestionlist.Add(Console.ReadLine());
                Console.WriteLine("Saisissez la réponse à cette question : ");
                NewAnswerList.Add(Console.ReadLine());
            }
            Quiz.Questions.Add(NewQuestionlist.ToArray());
            Quiz.RightAnswers.Add(NewAnswerList.ToArray());
            if (JsonFileManage.SetJson(Quiz))
            {
                Console.WriteLine("Questionnaire bien ajouté.");
            }
            else
            {
                Console.WriteLine("Une erreur c'est produit.");
            }
        }
    }
}
