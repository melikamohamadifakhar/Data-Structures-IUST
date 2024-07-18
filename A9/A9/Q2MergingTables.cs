using System;
using System.Collections.Generic;
using System.Linq;
using TestCommon;

namespace A9
{
    public class Q2MergingTables : Processor
    {

        public Q2MergingTables(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[], long[], long[], long[]>)Solve);

        public class Table {
            public Table parent;
            public long rank;
            public long info;

            public Table(int info, long rank) {
                this.info = info;
                this.rank = rank;
                parent = this;
            }
            public static Table getParent(Table t) {
                while (t.parent != t)
                {
                    t = t.parent;
                }
                return t;
            }
        }
        public static long merge(Table destination, Table source) {
            Table DestinationRoot = Table.getParent(destination);
            Table SourceRoot = Table.getParent(source);
            long newRank = 0;
            if (DestinationRoot != SourceRoot) {
                source.parent = DestinationRoot.parent;
                SourceRoot.parent = DestinationRoot.parent;
                newRank = SourceRoot.rank + DestinationRoot.rank ;
                destination.rank = newRank; 
                source.rank = newRank ;
                DestinationRoot.rank = newRank;
                SourceRoot.rank = newRank; 
            }
            return newRank;
        }
        public long[] Solve(long[] tableSizes, long[] targetTables, long[] sourceTables)
        { 
            List<long> result = new List<long>();
            long max = tableSizes.Max();
            List<Table> resultTables = new List<Table>();
            for(int i = 1 ; i <= tableSizes.Length ; i++)
            {
                resultTables.Add(new Table(i,tableSizes[i-1]));
            }
            for(int i = 0 ; i < targetTables.Length; i++)
            {
                long MergedRank = merge(
                    resultTables[(int)targetTables[i]-1],
                    resultTables[(int)sourceTables[i]-1]);
                max = Math.Max(max, MergedRank);
                result.Add(max);
            }
            return result.ToArray();
        }

    }
}
