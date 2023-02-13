using System;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using DataStructure;

namespace ConsoleApp5
{
    internal class Program
    {
        public static Queue<T> CopyQ<T>(Queue<T> q)
        {
            Queue<T> temp = new Queue<T>();
            Queue<T> copy=new Queue<T>();
            while(!q.IsEmpty())
            {
                copy.Insert(q.Head());
                temp.Insert(q.Remove());
            }
            while(!temp.IsEmpty())
                q.Insert(temp.Remove());
            return copy;
        }

        public static bool IsExistWithCopy<T> (Queue<T> q,T x)
        {
            Queue<T> temp=CopyQ<T>(q);
            while(!temp.IsEmpty())
            {
                if (temp.Head().Equals(x))
                    return true;

            }
            return false;

        }

        
        public static bool IsExist<T>(Queue<T> q,T x)
        {
            Queue<T> temp = new Queue<T>();
            bool found=false;
            //כל עוד יש איברים בתור

            while(!q.IsEmpty())
            {
                //אם מצאתי
                if (q.Head().Equals(x))
                    found= true;
                //אחרת נמשיך לאיבר הבא
                temp.Insert(q.Remove());
            }
            //התור ריק - לא מצאתי
            //נשחזר
            while(!temp.IsEmpty())
            {
                q.Insert(temp.Remove());
            }
            return found;
        }
        public static int CountQ<T>(Queue<T> q)
        {
            Queue<T> temp=new Queue<T>();
            int count = 0;  
            while(!q.IsEmpty())
            {
                //גיבוי של התור
                temp.Insert(q.Remove());
                count++;
            }
            //החזרה של התור למצב המקורי
            while(!temp.IsEmpty())
            {
                q.Insert(temp.Remove());
            }
            return count; 
        }
        public static int CountQRecursive<T>(Queue<T> q)
        {
            return CountQRecursive(q,new Queue<T>());
        }
        /// <summary>
        /// קוד  תקין לפעם הבאה
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="q"></param>
        /// <returns></returns>

        public static int CountQRecursive<T>(Queue<T> q, Queue<T> temp)
        {
            // Queue<T> temp = new Queue<T>();

            //תנאי עצירה
            if (q.IsEmpty()) return 0;
            //יש איברים בתור
            temp.Insert(q.Remove());
            int count = 1 + CountQRecursive(q, temp);
            q.Insert(temp.Remove());
            return count;

        }

        public static bool IsExistsRecursive<T>(Queue<T> queue,T x )
        {
            return IsExistsRecursive(queue, x, new Queue<T>());
        }

        private static bool IsExistsRecursive<T>(Queue<T> queue, T x, Queue<T> backup)
        {
            
            //תנאי עצירה
            if (queue.IsEmpty())
                return false;
            //הערך שבראש התור
            T val = queue.Remove();
            //נגבה אותו
            backup.Insert(val);
            //האם הערך קיים בחיפוש הנוכחי או בשאר התור
            bool found= IsExistsRecursive(queue, x, backup)||val.Equals(x); 
            //החזרה למצב מקורי
           queue.Insert(backup.Remove());
            return found;

        }

        public static Queue<int> ReverseQ(Queue<int> qu, Queue<int> newq)
        {
            int x = qu.Remove();
            if (qu.IsEmpty())
            {
                newq.Insert(x);
                return newq;
            }
            newq = ReverseQ(qu, newq);
            newq.Insert(x);
            return newq;
        }

        public static void EvenNumsAtTheEnd(Queue<int> que, int n)
        {
            int x;
            if (n>0)
            {
                x = que.Remove();
                if (x % 2 == 1) que.Insert(x);
                EvenNumsAtTheEnd(que, n - 1);
                if(x%2==0) que.Insert(x);   

            }
        }

        public static int MaxNumInQ(Queue<int> q)
        {
            Queue<int> copyQ = new Queue<int>();
            int max = int.MinValue;
            while (!q.IsEmpty())
            {
                int x = q.Remove();
                if (x > max) max = x;
                copyQ.Insert(q.Remove());   
            }
            while (!copyQ.IsEmpty())
            {
                q.Insert(copyQ.Remove());
            }
            return max;
        }

        public static void Add5(Queue<int> q)
        {
            Queue<int> copyQ = new Queue<int>();
            while (!q.IsEmpty())
            {
                int x = q.Remove();
                if (x < 10)
                {
                    x += 5;
                }
                copyQ.Insert(x);
            }
            while (!copyQ.IsEmpty())
            {
                q.Insert(copyQ.Remove());
            }
        }

        public static bool IsSorted(Queue<int> q)
        {
            bool b = true;
            Queue<int> copyQ = new Queue<int>(); //DONT FORGET COPY
            while (!q.IsEmpty())
            {
                int x = q.Remove();
                if (x > q.Head())
                {
                    b = false; //CANT RETURN Q IN THE MIDDLE 
                }
                copyQ.Insert(x);
            }
            while (!copyQ.IsEmpty())
            {
                q.Insert(copyQ.Remove());
            }
            return b;
        }





        static void Main(string[] args)
        {
            Queue<int> q1 = new Queue<int>();
            q1.Insert(2);
            q1.Insert(6);
            q1.Insert(7);
            q1.Insert(5);
            Queue<int> q2 = new Queue<int>();
            //Console.WriteLine(ReverseQ(q1,q2));
            //EvenNumsAtTheEnd(q1, 5);
            //Console.WriteLine(q1);
            Console.WriteLine(MaxNumInQ(q1));
            
            

        }
    }
}
