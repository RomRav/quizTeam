using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Nouveau_Quizz.classes
{
    internal class JsonFileManage
    {
        public static string fileName = "jsconfig1.json";

        //Récupère le contenu du fichier Json et le sérialise en objet Quiz.
        public static Quiz GetJson()
        {
            try
            {
                string jsonString = File.ReadAllText($"../../{fileName}");
                Quiz quiz = JsonSerializer.Deserialize<Quiz>(jsonString);
                return quiz;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        //Enregistre le contenu de l'objet envoyé en paramètre dans le fichier Json.
        public static bool SetJson(Quiz quiz)
        {
            try
            {
                var options = new JsonSerializerOptions { WriteIndented = true };
                string jsonString = JsonSerializer.Serialize(quiz, options);
                File.WriteAllText($"../../{fileName}", jsonString);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
