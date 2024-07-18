using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using TestCommon;

namespace C6
{
    public class Q1Circle : Processor
    {
        public Q1Circle(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) => C6Processors.ProcessQ1Circle(inStr, Solve);
        

        public long Solve(SinglyLinkedList llist)
        {
            SinglyLinkedListNode blue = llist.head;
            SinglyLinkedListNode red = llist.head;
            while(blue.next != null && blue.next.next != null ){
                if(blue.next.next == red.next)
                    return 1;
                blue = blue.next.next;
                red = red.next;
            }
            return 0;
        }
    }
}
