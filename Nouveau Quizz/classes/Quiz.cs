using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nouveau_Quizz.classes
{
    internal class Quiz
    {
        public User[] Users { get; set; }
        public List<string[]> Questions { get; set; }
        public List<string[]> RightAnswers { get; set; }
        public List<string[]> UserAnswers { get; set; }
        public QuizData Data { get; set; }
        
        public string CheckLogInput(string userInput)
        {
            string result = "wrong";
                if(userInput == this.Users[0].Name)
                {
                    return userInput;
                }
                else if(userInput == this.Users[1].Name)
                {
                    return userInput;
                }
            return result;
        }
            
        

        public string CheckPwdInput(string userInput, string logId)
        {
            int index;   
            if(logId == "Admin")
            {
                index = 0;
            }
            else
            {
                index = 1;
            }
            if (userInput == this.Users[index].Password)
            {
                return userInput;
            }
            else
            {
                return "wrong";
            }
        }
    }
}
