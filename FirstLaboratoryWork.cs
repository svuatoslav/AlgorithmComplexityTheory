using System;

namespace AlgorithmComplexityTheory
{
    internal sealed class FirstLaboratoryWork : LaboratoryWorksAutomaton
    {
        private State _state = State.Start;
        private enum State
        {
            Start,
            q1,
            q2,
            q3,
            q4,
            q5,
            Exit
        }
        public FirstLaboratoryWork(char[] alphabet, string w) : base(alphabet, w)
        {
            if (w != null)
                Start(w);
        }
        public sealed override void Start(string w)
        {
            //bool check = CheckingAlphabet(new string(value));// without new, if the string is replaced the char[]
            bool check = CheckingAlphabet(w);// without new, if the string is replaced the char[] }
            _state = State.Start;
            if (w == string.Empty)
            {
                Console.Write($"{_state}\nw допущен");
                Console.ReadLine();
                return;
            }
            else if (!check)
                return;
            else
                _w = w;
            FiniteAutomaton();
        }
        private void FiniteAutomaton()
        {
            int i = 0;
            try
            {
                switch (_state)
                {
                    case State.Start:
                        {
                            Console.WriteLine($"\t{_state}");
                            goto case State.q1;
                        }
                    case State.q1:
                        {
                            _state = State.q1; //state += 1;
                            Console.WriteLine($"{_w[i]}\t{_state}"); i++;
                            if(_w[i] == '1'|| _w[i] == '0')
                                goto case State.q2;
                            else
                                goto default;
                        }
                    case State.q2:
                        {
                            _state = State.q2;
                            Console.WriteLine($"{_w[i]}\t{_state}"); i++;
                            if (_w[i] == '1' || _w[i] == '0')
                                goto case State.q3;
                            else
                                goto default;
                        }
                    case State.q3:
                        {
                            _state = State.q3;
                            Console.WriteLine($"{_w[i]}\t{_state}"); i++;
                            if (_w[i] == '1' || _w[i] == '0')
                                goto case State.q4;
                            else
                                goto default;
                        }
                    case State.q4:
                        {
                            _state = State.q4;
                            Console.WriteLine($"{_w[i]}\t{_state}"); i++;
                            if (_w[i] == '1' || _w[i] == '0')
                                goto case State.q5;
                            else
                                goto default;
                        }
                    case State.q5:
                        {
                            _state = State.q5;
                            Console.WriteLine($"{_w[i]}\t{_state}"); i++;
                            if (_w[i] == '1' || _w[i] == '0')
                                goto case State.Exit;
                            else
                                goto default;
                        }
                    case State.Exit:
                        {
                            _state = State.Exit;
                            Console.WriteLine($"{_w[i]}\t{_state}"); i++;
                            if (_w.Length - 1 <= i)
                            {
                                Console.WriteLine("Длинна w больше 5 => w не допущен");
                                Console.ReadKey();
                                return;
                            }
                            if (_w[i] == '1' || _w[i] == '0')
                                goto case State.Exit;
                            else
                                goto default;
                        }
                    default:
                        {
                            Console.WriteLine("Ошибка");
                            Console.ReadKey();
                            return;
                        }
                }
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine($"w допущен");
                Console.ReadKey();
                return;
            }
        }
    }
}
