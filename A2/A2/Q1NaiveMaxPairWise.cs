﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A2
{
    public class Q1NaiveMaxPairWise : Processor
    {
        public Q1NaiveMaxPairWise(string testDataName) : base(testDataName) { }
        public override string Process(string inStr) => 
            Solve(inStr.Split(new char[] { '\n', '\r', ' ' },
                StringSplitOptions.RemoveEmptyEntries)
                .Select(s => long.Parse(s))
                .ToArray()).ToString();

        public virtual long Solve(long[] numbers){
            long mul=0;
            for(int i=0; i<numbers.Length; i++)
                for(int j=0; j<numbers.Length; j++){
                    long newmul = numbers[i]*numbers[j];
                    if((i!=j) && newmul>mul)
                        mul = newmul;
                }
                return mul;
            
        }
    }
}

