using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
        public class Queue<T>
        {
            public Node<T> first;
            public Node<T> last;


            public Queue()
            {
                this.first = null;
                this.last = null;
            }

            public void Insert(T x)
            {
                Node<T> temp = new Node<T>(x);
                if (first == null)
                    first = temp;
                else
                    last.SetNext(temp);
                last = temp;
            }

            public T Remove()
            {
                T x = first.GetValue();
                first = first.GetNext();
                if (first == null)
                    last = null;
                return x;
            }

            public T Head()
            {
                return first.GetValue();
            }

            public bool IsEmpty()
            {
                return first == null;
            }

            public override string ToString()
            {
                Node<T> current = first;
                string temp = "";
                while (current != null)
                {
                    temp += current.GetValue() + " --> ";
                    current = current.GetNext();
                }
                return "head -> " + temp + "end";
            }
        }
    }


