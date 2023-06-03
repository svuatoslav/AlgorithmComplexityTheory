using System;
using System.Collections.Generic;
using System.IO;

namespace AlgorithmComplexityTheory
{
    internal sealed class SecondLaboratoryWork : LaboratoryWorksAutomaton
    {
        //private List<Active> actives = new();
        private Active action = null;
        private sealed class Active
        {
            internal State state = State.Start;
            internal Stack<char> stack = new();
            internal string history = $"State: {State.Start}, Stack: # -> ";
            internal bool active = true;
            public Active(State state)
            {
                this.state = state;
                stack.Push('#');
            }
            public Active(State state, string parentHistory)
            {
                this.state = state;
                history = parentHistory;
                stack.Push('#');
            }
        }
        private enum State
        {
            Start,
            q1,
            q2,
            q3,
            q4,
            q5,
            q6,
            q7,
            q8,
            q9,
            q10,
            q11,
        }
        public SecondLaboratoryWork(char[] alphabet, string w) : base(alphabet, w) { Start(w); }

        public sealed override void Start(string w)
        {
            bool result = false;
            action = new Active(State.Start);
            if (w != string.Empty)
            {
                bool check = CheckingAlphabet(w);
                if (!check)
                    return;
                else
                    _w = w;
                //actives.Add(new Active(State.Start));
                Check(w);
                foreach (char symbol in _w)
                {
                    //for (int i = actives.Count - 1; i >= 0; i--)
                    //{
                    //    if (actives[i].active)
                    //    {
                    //        FiniteAutomaton(actives[i], symbol);
                    //        Write(actives[i], symbol);
                    //    }
                    //}
                    FiniteAutomaton(action, symbol);
                    Write(action, symbol);
                }
            }
            using (StreamWriter writer = new("result.txt", false))
            {
                //foreach (Active action in actives)
                //{
                //    writer.WriteLine(action.history);
                //    if (action.state != State.Exit && action.state != State.q1)
                //        result = true;
                //}
                writer.WriteLine(action.history);
                if (action.state != State.q1)
                    result = true;
                writer.WriteLine(result);
            }
        }
        private void FiniteAutomaton(Active active, char symbol)
        {
            //actives.Add(new Active(State.q5, active.history));
            //actives.Last().stack.Push('1');
            bool read = false;
            switch (active.state)
            {
                case State.Start:
                    {
                        if (read)
                            break;
                        if (active.stack.Peek() == '#')
                        {
                            active.state = State.q1;
                            goto case State.q1;
                        }
                        else
                            goto default;
                    }
                case State.q1:
                    {
                        if (read)
                            break;
                        read = true;
                        if (symbol == '0' && active.stack.Peek() == '#')
                        {
                            active.stack.Push('1');
                            active.stack.Push('1');
                            active.stack.Push('1');
                            active.state = State.q2;
                            goto case State.q2;
                        }
                        else if(symbol == '1' && active.stack.Peek() == '#')
                        {
                            active.stack.Push('1');
                            active.state = State.q5;
                            goto case State.q5;
                        }
                        else
                            goto default;
                    }
                case State.q2:
                    {
                        if (active.stack.Peek() == '#')
                        {
                            active.state = State.q1;
                            goto case State.q1;
                        }
                        if (read)
                            break;
                        read = true;
                        if (symbol == '0' && active.stack.Peek() == '1')
                        {
                            active.stack.Push('1');
                            active.stack.Push('1');
                            active.stack.Push('1');
                            goto case State.q2;
                        }
                        else if (symbol == '1' && active.stack.Peek() == '1')
                        {
                            active.stack.Pop();
                            active.state = State.q3;
                            goto case State.q3;
                        }
                        else
                            goto default;
                    }
                case State.q3:
                    {
                        if (read)
                            break;
                        read = true;
                        if (symbol == '0' && active.stack.Peek() == '1')
                        {
                            active.stack.Push('1');
                            active.stack.Push('1');
                            active.stack.Push('1');
                            goto case State.q3;
                        }
                        else if (symbol == '1' && active.stack.Peek() == '1')
                        {
                            active.stack.Pop();
                            active.state = State.q4;
                            goto case State.q4;
                        }
                        else 
                            goto default;
                    }
                case State.q4:
                    {
                        if (read)
                            break;
                        read = true;
                        if (symbol == '1' && active.stack.Peek() == '1')
                        {
                            active.stack.Pop();
                            active.state = State.q2;
                            goto case State.q2;
                        }
                        else if (symbol == '0' && active.stack.Peek() == '1')
                        {
                            active.stack.Push('1');
                            active.stack.Push('1');
                            active.stack.Push('1');
                            goto case State.q4;
                        }
                        else
                            goto default;
                    }
                case State.q5:
                    {
                        if (read)
                            break;
                        read = true;
                        if (symbol == '0' && active.stack.Peek() == '1')
                        {
                            active.stack.Pop();
                            active.state = State.q6;
                            goto case State.q6;
                        }
                        else if (symbol == '1' && active.stack.Peek() == '1')
                        {
                            active.stack.Push('1');
                            active.state = State.q8;
                            goto case State.q8;
                        }
                        else
                            goto default;
                    }
                case State.q6:
                    {
                        if (active.stack.Peek() == '#')
                        {
                            active.stack.Push('1');
                            active.stack.Push('1');
                            active.state = State.q3;
                            goto case State.q3;
                        }
                        else if (active.stack.Peek() == '1')
                        {
                            active.stack.Pop();
                            active.state = State.q7;
                            goto case State.q7;
                        }
                        else
                            goto default;
                    }
                case State.q7:
                    {
                        if (active.stack.Peek() == '1')
                        {
                            active.stack.Pop();
                            active.state = State.q5;
                            goto case State.q5;
                        }
                        else
                            goto default;
                    }
                case State.q8:
                    {
                        if (read)
                            break;
                        read = true;
                        if (symbol == '0' && active.stack.Peek() == '1')
                        {
                            active.stack.Pop();
                            active.state = State.q9;
                            goto case State.q9;
                        }
                        else if (symbol == '1' && active.stack.Peek() == '1')
                        {
                            active.stack.Push('1');
                            active.state = State.q11;
                            goto case State.q11;
                        }
                        else
                            goto default;
                    }
                case State.q9:
                    {
                        if (active.stack.Peek() == '1')
                        {
                            active.stack.Pop();
                            active.state = State.q10;
                            goto case State.q10;
                        }
                        else
                            goto default;
                    }
                case State.q10:
                    {
                        if (active.stack.Peek() == '#')
                        {
                            active.stack.Push('1');
                            active.state = State.q4;
                            goto case State.q4;
                        }
                        else if (active.stack.Peek() == '1')
                        {
                            active.stack.Pop();
                            active.state = State.q8;
                            goto case State.q8;
                        }
                        else
                            goto default;
                    }
                case State.q11:
                    {
                        if (active.stack.Peek() == '#')
                        {
                            active.state = State.q1;
                            goto case State.q1;
                        }
                        if (read)
                            break;
                        read = true;
                        if (symbol == '1' && active.stack.Peek() == '1')
                        {
                            active.stack.Push('1');
                            active.state = State.q5;
                            goto case State.q5;
                        } 
                        else if (symbol == '0' && active.stack.Peek() == '1')
                        {
                            active.stack.Pop();
                            active.stack.Pop();
                            active.stack.Pop();
                            goto case State.q11;
                        }
                        else
                            goto default;
                    }
                default:
                    {
                        Console.WriteLine("Конец");
                        //Console.WriteLine($"{active.state}, строка: {actives.IndexOf(active)}");
                        Console.WriteLine($"{active.state}");
                        Console.ReadKey();
                        return;
                    }
            }
        }
        private void Write(Active active, char symbol) => active.history += $"Input: {symbol}, State: {active.state}, Stack: {string.Join(",", active.stack.ToArray())} -> ";
        private void Check(string w) 
        {
            int[] count = new int[Alphabet.Length];
            for (int i = 0; i < w.Length; i++)
                for (int j = 0; j < Alphabet.Length; j++)
                    if (w[i] == Alphabet[j])
                        count[j]++;
            Console.WriteLine($"Количество {Alphabet[0]} = {count[0]}, количество {Alphabet[1]} = {count[1]}.\n{count[1] / count[0]} => Подходит? {count[0] * 3 != count[1]}");
        }
    }
}
