using System;
using System.Linq;
using System.Collections.Generic;
using TestCommon;

namespace A10
{

    public class Q1PhoneBook : Processor
    {
        public Q1PhoneBook(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<string[], string[]>)Solve);

        protected Dictionary<int, string> phoneBookList;

        public string[] Solve(string [] commands)
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

        public void Add(string name, int number)
        {
            if(phoneBookList.ContainsKey(number)){ 
                phoneBookList[number] = name;
            }
            else{
                phoneBookList.Add(number, name);
            }
        }

        public string Find(int number)
        {
            if(phoneBookList.ContainsKey(number)) { return phoneBookList[number]; }
            return "not found";
        }

        public void Delete(int number)
        {
            if(phoneBookList.ContainsKey(number)){
                phoneBookList.Remove(number);
            }
        }
    }
}
