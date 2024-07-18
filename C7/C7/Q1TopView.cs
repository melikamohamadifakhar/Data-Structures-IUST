using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using TestCommon;

namespace C7
{
    public class Q1TopView : Processor
    {
        public Q1TopView(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) => C7Processors.ProcessQ1TopView(inStr, Solve);
        

        public string Solve(long n, BinarySearchTree tree)
        {
            SortedDictionary<long, Node> d = new SortedDictionary<long, Node>();
            Queue<Node> Q = new Queue<Node>();
            Node R = tree.root;
            Q.Enqueue(R);
            while (Q.Count != 0){
                Node newnode = Q.Dequeue();
                long h = newnode.h;
                long Level = newnode.level;
                int hold = Q.Count;
                if(!d.ContainsKey(h)){
                        d.Add(h, newnode);
                }
                else{ 
                        if(d[h].level > newnode.level){ 
                            d[h] = newnode;}
                    }
                Node left = newnode.left;
                Node right = newnode.right;
                if(left != null){ 
                    left.h = h-1;
                    left.level = Level+1;
                    Q.Enqueue(left);}
                    if(right != null){ 
                        right.h = h+1;
                        right.level = Level+1;
                        Q.Enqueue(right);
                        }
                }
                string s = "";
                foreach(var i in d){
                    s += i.Value.info.ToString() + " ";
                }
                return s;
        }
    }
}
