using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using Nouveau_Quizz.classes;

namespace Nouveau_Quizz
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Quiz quiz = JsonFileManage.GetJson();


            //var user
            string user;
            //var password's user
            string passwordUser ="";
            do
            {
                //Ask the user his name
                Console.WriteLine("Votre nom : (Admin ou User)");
                user = Console.ReadLine();
                if (quiz.CheckLogInput(user) == "Admin") //show me the admin right password for associated with Admin
                {
                    Console.WriteLine("Votre mot de passe : (4dmin)");
                    passwordUser = Console.ReadLine();
                    if (quiz.CheckPwdInput(passwordUser, user) == "4dmin")
                    {
                        Console.WriteLine("Vous allez être dirigé vers l'espace administrateur...");
                        Admin.displayAdmin();
                    }
                    else
                    {
                        Console.WriteLine("Mot de passe incorrect");
                    };
                }
                else if (quiz.CheckLogInput(user) == "User") //show me the admin right password for associated with User
                {
                    Console.WriteLine("Votre mot de passe : (useR)");
                    passwordUser = Console.ReadLine();
                    if (passwordUser == "useR")
                    {
                        Console.WriteLine("Vous allez être dirigé vers le meilleur quiz au MONDE...");
                        Game.Play();
                    }
                    else
                    {
                        Console.WriteLine("Mot de passe incorrect");
                    }
                }
                else
                {
                    Console.WriteLine("Veuillez saisir un nom entre \"Admin\" et \"User\"");
                };
            } while (passwordUser != "4dmin" || passwordUser != "useR");
        }
    }
}
