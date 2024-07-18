using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace secondCours
{
    class Program
    {
        protected static Dictionary<int, string> phoneBookList;

        public static string[] Solve(string [] commands)
        {
            phoneBookList = new Dictionary<int, string>();
            List<string> result = new List<string>();
            foreach(var cmd in commands)
            {
                var toks = cmd.Split();
                var cmdType = toks[0];
                var args = toks.Skip(1).ToArray();
                int number = int.Parse(args[0]);
                switch (cmdType)
                {
                    case "add":
                        Add(args[1], number);
                        break;
                    case "del":
                        Delete(number);
                        break;
                    case "find":
                        result.Add(Find(number));
                        break;
                }
            }
            return result.ToArray();
        }

        public static void Add(string name, int number)
        {
            if(phoneBookList.ContainsKey(number)){ 
                phoneBookList[number] = name;
            }
            else{
                phoneBookList.Add(number, name);
            }
        }

        public static string Find(int number)
        {
            if(phoneBookList.ContainsKey(number)) { return phoneBookList[number]; }
            return "not found";
        }

        public static void Delete(int number)
        {
            if(phoneBookList.ContainsKey(number)){
                phoneBookList.Remove(number);
            }
        }      
        
        static void Main(string[] args){
            int count = int.Parse(Console.ReadLine());
            string[] commands = new string[count];
            for(int i = 0; i < count; i++){
                commands[i] = Console.ReadLine();
            }
            string[] ans = Solve(commands);
            foreach(var i in ans) {
                Console.WriteLine(i);
            }
        }
    }
    }

