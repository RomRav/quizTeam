using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nouveau_Quizz.classes
{
    internal class QuizData
    {
        public string Try { get; set; }
        public string SuccessRate { get; set; }
        public string AboveAverageNbr { get; set; }

        public static void ShowData(QuizData Data)
        {
            Console.WriteLine($"Le questionnaire à été réalisé {Data.Try} fois.\n {Data.AboveAverageNbr} utilisateurs sur {Data.Try} ont eu plus que la moyenne.");
        }
    }
}
