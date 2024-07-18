using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using TestCommon;

namespace C8
{
	public class Q1Line : Processor
	{
		public Q1Line(string testDataName) : base(testDataName) {}

		public override string Process(string inStr) => C8Processors.ProcessQ1Line(inStr, Solve);

		// public double GetProportion(long y1, long y2, long x1, long x2){
		// 	return (double)((long)(y1-y2)/(x1-x2));
		// }
		public string Solve(long n, long[][] p)
		{

			int Maximum = 0 ;
			double proportion = 0 ;
			if (n < 2){ return n.ToString(); }

			for (int i = 0; i < p.Length; i++)
			{
				List<long> vertical = new List<long>();
				int max = 0;
				int samepoint = 1;
				Dictionary<double,int> dict = new Dictionary<double,int>();
				for (int j = i+1; j < p.Length; j++)
				{
					if (p[i][0] == p[j][0] && p[i][1] == p[j][1]) 
						samepoint++;
					else if (p[i][0] == p[j][0]) 
					{
						vertical.Add(p[j][0]);
					}
					else {
						proportion = (double)(p[i][1]-p[j][1])/(p[i][0]-p[j][0]);
						if(dict.ContainsKey(proportion))
							dict[proportion]++;
						else
							dict[proportion] = 1 ;
					}
				}
				foreach (var key in dict.Keys)
				{
					max = Math.Max(dict[key], max);
				}
				int v = vertical.Count + 1;
				int OtherMax = Math.Max(max + samepoint, Maximum);
				if(OtherMax > v) { Maximum = OtherMax;}
				else { Maximum = v;}
			}
			return Maximum.ToString();
		}

	}
}
