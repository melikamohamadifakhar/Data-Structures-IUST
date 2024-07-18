using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
// using Priority_Queue;
using TestCommon;

namespace C9
{
    public class Q2Snakes : Processor
    {
        public Q2Snakes(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) => C7Processors.ProcessQ2Snakes(inStr, Solve);
        
    public class Cells
    {
        public int vertex = 0;
        public int num = 0;
    }

    static int snakesDiceNum(int[] move)
    {
        bool isPossible = false;
        bool[] is_visited = new bool[100];
        Queue<Cells> q = new Queue<Cells>();
        Cells qe = new Cells();
        is_visited[0] = true;
        q.Enqueue(qe);
        int cnt = q.Count;
        for(int i = 0; i<100; i++){
            if(cnt > 0){
                qe = q.Dequeue(); cnt--;
                int vertex = qe.vertex;
                if (vertex == 99) { isPossible = true; break;}
                for (int j = vertex + 1; j < (vertex + 7) && j < 100; j++)
                {
                    if (!is_visited[j])
                    {
                        Cells a = new Cells();
                        a.num = (qe.num + 1);
                        is_visited[j] = true;
                        if (move[j] == -1){
                            a.vertex = j;
                            q.Enqueue(a); cnt++;
                            continue;
                        }
                        a.vertex = move[j];
                        q.Enqueue(a); cnt++;
                    }
                }
            }
        }
        if(!isPossible) {return -1;}
        return qe.num;
    }

        public long Solve(long n,long[][] ladders, long m,long[][] snakes)
        {
            int[] moves = new int[100];
            for(int i = 0; i < 100; i++){ moves[i] = -1;}

            for(int i = 0; i < n; i++){
                long x = ladders[i][0];
                moves[(int)x - 1] = (int) ladders[i][1] - 1;
            }

            for(int i = 0; i < m; i++){
                long x = snakes[i][0];
                moves[(int)x - 1] = (int) snakes[i][1] - 1;
            }
            return snakesDiceNum(moves);
        }
    }
}
