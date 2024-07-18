using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A11
{
    public class Q4SetWithRangeSums : Processor
    {
        public Q4SetWithRangeSums(string testDataName) : base(testDataName)
        {
            CommandDict =
                        new Dictionary<char, Func<string, string>>()
                        {
                            ['+'] = Add,
                            ['-'] = Del,
                            ['?'] = Find,
                            ['s'] = Sum
                        };
        }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<string[], string[]>)Solve);

        public readonly Dictionary<char, Func<string, string>> CommandDict;

        public const long M = 1_000_000_001;

        public long X = 0;

        protected List<long> Data;
        public class Node{
            public long data;
            public long sum;
            public Node left;
            public Node right;
            public Node parent;
            public Node(long d, long s, Node l, Node r, Node p){
                data = d; sum = s; l = left; r = right; parent = p;
            }
        }
        void small_rotation(Node n){
            Node parent = n.parent;
            if(parent == null) return;
            Node grandparent = n.parent.parent;
            if(parent.left == n){
                Node m = n.right;
                n.right = parent;
                parent.left = m;
            }
            else {
                Node m = n.left;
                n.left = parent;
                parent.right = m;
            }
            update(parent);
            update(n);
            n.parent = grandparent;
            if (grandparent != null) {
                if (grandparent.left == parent) {
                grandparent.left = n;
                } else {
                grandparent.right = n;
                }
            }
        }

        void big_rotation(Node v) {
        if (v.parent.left == v && v.parent.parent.left == v.parent) {
            // Zig-zig
            small_rotation(v.parent);
            small_rotation(v);
        } else if (v.parent.right == v && v.parent.parent.right == v.parent) {
            // Zig-zig
            small_rotation(v.parent);
            small_rotation(v);
        } else {
            // Zig-zag
            small_rotation(v);
            small_rotation(v);
        }  
        }
        void splay(Node root, Node v) {
        if (v == null) return;
        while (v.parent != null) {
            if (v.parent.parent == null) {
            small_rotation(v);
            break;
            }   
            big_rotation(v);
        }
        root = v;
        }
        Node find(Node root, long data) {
            Node v = root;
            Node last = root;
            Node next = null;
            while (v != null) {
                if (v.data >= data && (next == null || v.data < next.data)) {
                    next = v;
                }
                last = v;
                if (v.data == data) {
                    break;      
                }
                if (v.data < data) {
                    v = v.right;
                } else {
                    v = v.left;
                }
            }
            splay(root, last);
            return next;
        }
        void update(Node n){
            if(n == null) return;
            long leftsum = 0, rightsum = 0;
            if(n.left != null){
                leftsum += n.left.sum;
            }
            if(n.right != null){
                rightsum += n.right.sum;
            }
            n.sum = n.data + leftsum + rightsum;
            if(n.left != null) { n.left.parent = n; }
            if(n.right != null) { n.right.parent = n; }
        }
        void split(Node root, long key, ref Node left, ref Node right) {
            right = find(root, key);
            splay(root, right);
            if (right == null) {
                left = root;
                return;
            }
            left = right.left;
            right.left = null;
            if (left != null) {
                left.parent = null;
            }
            update(left);
            update(right);
        }
        Node merge(Node left, Node right) {
            if (left == null) return right;
            if (right == null) return left;
            Node min_right = right;
            while (min_right.left != null) {
                min_right = min_right.left;
            }
            splay(right, min_right);
            right.left = left;
            update(right);
            return right;
        }
        Node root = null;

        void insert(long x) {
            Node left = null;
            Node right = null;
            Node new_vertex = null;  
            split(root, x, ref left, ref right);
            if (right == null || right.data != x) {
                new_vertex = new Node(x, x, null, null, null);
            }
            root = merge(merge(left, new_vertex), right);
        }
        public string[] Solve(string[] lines)
        {
            X = 0; root = null;
            Data = new List<long>();
            List<string> result = new List<string>();
            foreach (var line in lines)
            {
                char cmd = line[0];
                string args = line.Substring(1).Trim();
                var output = CommandDict[cmd](args);
                if (null != output)
                    result.Add(output);
            }
            return result.ToArray();
        }

        private long Convert(long i)
            => i = (i + X) % M;

        private string Add(string arg)
        {
            long i = Convert(long.Parse(arg));
            insert(i);
            return null;
        }

        private string Del(string arg)
        {
            long i = Convert(long.Parse(arg));
            int idx = Data.BinarySearch(i);
            if (idx >= 0)
                Data.RemoveAt(idx);
            return null;
        }

        private string Find(string arg)
        {
            long i = Convert(int.Parse(arg));
            Node f = find(root, i);
            if(f.data != i) { return "Not found"; }
            return "Found";
        }

        private string Sum(string arg)
        {
            var toks = arg.Split();
            long l = Convert(long.Parse(toks[0]));
            long r = Convert(long.Parse(toks[1]));

            l = Data.BinarySearch(l);
            if (l < 0)
                l = ~l;

            r = Data.BinarySearch(r);
            if (r < 0)
                r = (~r - 1);
            // If not ~r will point to a position with
            // a larger number. So we should not include 
            // that position in our search.

            long sum = 0;
            for (int i = (int)l; i <= r && i < Data.Count; i++)
                sum += Data[i];

            X = sum;

            return sum.ToString();
        }
    }
}
