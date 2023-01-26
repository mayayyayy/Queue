using System;
//using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructure;

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

        public static int CountQRecursive<T>(Queue<T> q,Queue<T> temp)
        {
           // Queue<T> temp = new Queue<T>();

            //תנאי עצירה
            if (q.IsEmpty()) return 0;
           //יש איברים בתור
            temp.Insert(q.Remove());
            int count = 1 + CountQRecursive(q,temp);
            q.Insert(temp.Remove());
            return count;







            static void Main(string[] args)
        {
            Queue<int> q1 = new Queue<int>();
            q1.Insert(7);
            q1.Insert(8);
            q1.Insert(9);
            q1.Insert(1);
            Console.WriteLine(q1);
            Console.WriteLine(IsExist(q1,9));
            Console.WriteLine(q1);
            //int count = CountQ(q1);
            //Console.WriteLine(count);
            //Console.WriteLine(q1);
            Console.ReadKey();

        }
    }
}
