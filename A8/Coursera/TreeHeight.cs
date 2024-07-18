using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace secondCours
{
    class Program
    {
        public class Node{
            public long Data = -2;
            public Node(){}
            public Node(long data){
                Data = data;
            }
            public override string ToString(){
                return Data.ToString();
            }
            public List<Node> children = new List<Node>();
        }
        public static long buildtree(long nodeCount, long[] tree){
            int root = 0;
            Node[] nodes = new Node[nodeCount];
            for (int i=0; i<nodeCount; i++){
                nodes[i] = new Node();
            }
            for (int i=0; i<nodeCount; i++){
                if(tree[i] == -1){
                    root = i;
                }
                else{
                    nodes[tree[i]].Data = tree[i];
                    nodes[tree[i]].children.Add(new Node(i));
                }
            }
            return maxHeight(root, nodes);
        }
        public static int maxHeight(long root, Node[] nodes){
            Queue Q = new Queue();
            int Height=0;
            Q.Enqueue(root);
            while (Q.Count != 0){
                Height++;
                int hold = Q.Count;
                for(int j=0; j<hold; j++){
                    root = Int64.Parse(Q.Peek().ToString());
                    Q.Dequeue();
                    int cnt = nodes[root].children.Count;
                    for(int i=0; i<cnt; i++){
                        Q.Enqueue(nodes[root].children[i]);
                    }
                }
                }
            return Height;
        }
        static void Main(string[] args)
        {
            string cnts = Console.ReadLine();
            int cnt = int.Parse(cnts);
            long[] tree = new long[cnt];
            string[] s = Console.ReadLine().Split();
            for(int i=0; i<cnt; i++){
                tree[i] = Int64.Parse(s[i]);
            }
            Console.WriteLine(buildtree(cnt, tree));
        }
    }
}
