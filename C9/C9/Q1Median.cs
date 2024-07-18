using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
// using Priority_Queue;
using TestCommon;

namespace C9
{
    public class Q1Median : Processor
    {
        public Q1Median(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) => C7Processors.ProcessQ1Median(inStr, Solve);
        
        public class minheap{
            long[] heap;
            public minheap(long n){
                heap = new long[n];
            }
            public long parent(long i){
                return (i-1)/2;
            }
            public long leftchild(long i){
                return (2*i)+1;
            }
            public long rightchild(long i){
                return (2*i)+2;
            }

            public void siftup(long i){
                while(i > 0 && heap[parent(i)] > heap[i]){
                    long tmp = heap[parent(i)];
                    heap[parent(i)] = heap[i];
                    heap[i] = heap[parent(i)];
                    i = parent(i);
                }
            }
            public long size = -1;
            public void siftdown(long i){
                long maxidx = i;
                long l = leftchild(i);
                if(l <= size && heap[l] < heap[maxidx]){
                    maxidx = l;
                }
                long r = rightchild(i);
                if(r <= size && heap[r] < heap[maxidx]){
                    maxidx = r;
                }
                if(i != maxidx){
                    long tmp = heap[i];
                    heap[i] = heap[maxidx];
                    heap[maxidx] = tmp;
                    siftdown(maxidx);
                }
            }
            public void insert(long p){
                size++;
                heap[size] = p;
                siftup(size);
            }
            public long extractmin(){
                long result = heap[0];
                heap[0] = heap[size];
                size--;
                siftdown(0); 
                return result;
            }
            public long getmin(){
                return heap[0];
            }
            public void remove(long i){
                heap[i] = getmin() + 1;
                siftup(i);
                extractmin();
            }
            public bool empty(){
                if(size > -1){
                    return false;
                }
                return true;
            }
        }
        public class maxheap{
            long[] heap;
            public maxheap(long n){
                heap = new long[n];
            }
            public long parent(long i){
                return (i-1)/2;
            }
            public long leftchild(long i){
                return (2*i)+1;
            }
            public long rightchild(long i){
                return (2*i)+2;
            }

            public void siftup(long i){
                while(i > 0 && heap[parent(i)] < heap[i]){
                    long tmp = heap[parent(i)];
                    heap[parent(i)] = heap[i];
                    heap[i] = heap[parent(i)];
                    i = parent(i);
                }
            }
            public long size = -1;
            public void siftdown(long i){
                long maxidx = i;
                long l = leftchild(i);
                if(l <= size && heap[l] > heap[maxidx]){
                    maxidx = l;
                }
                long r = rightchild(i);
                if(r <= size && heap[r] > heap[maxidx]){
                    maxidx = r;
                }
                if(i != maxidx){
                    long tmp = heap[i];
                    heap[i] = heap[maxidx];
                    heap[maxidx] = tmp;
                    siftdown(maxidx);
                }
            }
            public void insert(long p){
                size++;
                heap[size] = p;
                siftup(size);
            }
            public long extractmax(){
                long result = heap[0];
                heap[0] = heap[size];
                size--;
                siftdown(0); 
                return result;
            }
            public long getmax(){
                return heap[0];
            }
            public void remove(long i){
                heap[i] = getmax() + 1;
                siftup(i);
                extractmax();
            }
            public bool empty(){
                if(size > -1){
                    return false;
                }
                return true;
            }
        }
        int Signum(long a, long b)
        {
            if( a == b )
                return 0;
        
            return a < b ? -1 : 1;
        }
        double getMedian(long e, double m, minheap min, maxheap max)
        {
            int sig = Signum(max.size, min.size); 
            switch(sig)
            {
            case 1: // There are more elements in left (max) heap
                if( e < m ) // current element fits in left (max) heap
                {
                    // Remore top element from left heap and
                    // insert into right heap
                    min.insert(max.extractmax());
        
                    // current element fits in left (max) heap
                    max.insert(e);
                }
                else
                {
                    // current element fits in right (min) heap
                    min.insert(e);
                }
        
                // Both heaps are balanced
                m = (double)(max.getmax() + min.getmin())/2;
        
                break;
        
            case 0: // The left and right heaps contain same number of elements
        
                if( e < m ) // current element fits in left (max) heap
                {
                    max.insert(e);
                    m = max.getmax();
                }
                else
                {
                    // current element fits in right (min) heap
                    min.insert(e);
                    m = min.getmin();
                }
        
                break;
        
            case -1: // There are more elements in right (min) heap
        
                if( e < m ) // current element fits in left (max) heap
                {
                    max.insert(e);
                }
                else
                {
                    // Remove top element from right heap and
                    // insert into left heap
                    max.insert(min.extractmin());
        
                    // current element fits in right (min) heap
                    min.insert(e);
                }
        
                // Both heaps are balanced
                m = (double) (max.getmax() + min.getmin())/2;
        
                break;
            }
        
            // No need to return, m already updated
            return m;
}
        public String Solve(long n,long[] arr)
        {
            double[] res = new double[n];
            maxheap maxh = new maxheap(n);
            minheap minh = new minheap(n);
            for(int i = 0; i < n; i++){
                if (maxh.empty() || arr[i] < maxh.getmax())
                {
                    maxh.insert(arr[i]);
                }
                else{
                    minh.insert(arr[i]);
                }
                if (maxh.size - minh.size > 1){
                    minh.insert(maxh.extractmax());
                }
                else if (minh.size - maxh.size > 1){
                    maxh.insert(minh.extractmin());
                }
                if(minh.size == maxh.size){
                    res[i] = ((double)maxh.getmax()+minh.getmin())/2;
                }
                else if(minh.size > maxh.size){
                    res[i] = minh.getmin();
                }
                else {
                    res[i] = maxh.getmax();
                }
            }
            // -------------------
            // your code here
            // -------------------
            var ans = res.Select(x => String.Format("{0:0.0}", x));
            return String.Join('\n',ans);
        }
    }
}
