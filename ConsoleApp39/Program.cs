using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp39
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string [] ops = { "5", "2", "C", "D", "+" };
            int total = CalcPoints(ops); //30

            ops = new string[]{ "5", "-2", "4", "C", "D", "9", "+", "+" };
            total = CalcPoints(ops); //27

            ops = new string[] { "1"};
            total = CalcPoints(ops); //1
        }

        static int CalcPoints(string [] ops)
        {
            Stack<int> points = new Stack<int>();

            for (int i = 0; i < ops.Length; i++)
            {
                switch (ops[i])
                {
                    case "C":
                        if (points.Count() != 0)
                        {
                            points.Pop();
                        }
                        break;
                    case "D":
                        if (points.Count() >= 1)
                        {
                            points.Push(points.Peek() * 2);
                        }
                        break;
                    case "+":
                        if (points.Count() >= 2)
                        {
                            int top = points.Pop();
                            int prv = points.Peek();
                            points.Push(top);
                            points.Push(prv + top );
                        }                       
                        break;
                    default:
                        int.TryParse(ops[i], out int res);
                        points.Push(res);                                                  
                        break;
                }
            }
            return points.Sum();
        }
    }
}
