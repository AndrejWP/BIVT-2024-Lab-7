using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_7
{
    public class White_4
    {
        public class Human
        {
            protected string _name;
            protected string _surname;

            public string Surname => _surname;
            public string Name => _name;

            public Human(string name, string surname)
            {
                _name = name;
                _surname = surname;
            }

            public  void Print()
            {
                Console.WriteLine($"Имя: {_name}, Фамилия: {_surname}");
            }
        }

        public class Participant : Human
        {
            private static int _count;
            
            public static int Count => _count;
            
            private double[] _scores;
            
            static Participant()
            {
                _count = 0;
            }

            public Participant(string name, string surname) : base(name, surname)
            {
                _scores = new double[0];
                _count++;
            }
            public double[] Scores
            {
                get
                {
                    if (_scores == null)
                        return null;
                    double[] copyscores = new double[_scores.Length];
                    for (int i = 0; i < _scores.Length; i++)
                    {
                        copyscores[i] = _scores[i];
                    }
                    return copyscores;
                }
            }
            private double Average
            {
                get
                {
                    if (_scores == null || _scores.Length == 0)
                        return 0;
                    double sum = 0;
                    foreach (var score in _scores)
                    {
                        sum += score;
                    }
                    return sum / _scores.Length;
                }
            }
            public double TotalScore
            {
                get
                {
                    double sum = 0;
                    if (_scores == null || _scores.Length == 0)
                        return 0;
                    foreach (var score in _scores)
                    {
                        sum += score;
                    }
                    return sum;
                }
            }

            
            public void Print()
            {
                Console.WriteLine($"Имя: {Name}, Фамилия: {Surname}, Очки: {TotalScore:F1}");
            }
            public void PlayMatch(double result)
            {
                if (_scores == null) return;
                double[] newScores = new double[_scores.Length + 1];
                for (int i = 0; i < _scores.Length; i++)
                {
                    newScores[i] = _scores[i];
                }
                newScores[newScores.Length - 1] = result;
                _scores = newScores;
            }
            // метод сортировки
            public static void Sort(Participant[] array)
            {
                if (array == null || array.Length == 0) return;
                int n = array.Length;
                bool sw;
                for (int i = 0; i < n - 1; i++)
                {
                    sw = false;

                    for (int j = 0; j < n - 1 - i; j++)
                    {
                        if (array[j].TotalScore < array[j + 1].TotalScore)
                        {
                            (array[j], array[j + 1]) = (array[j + 1], array[j]);
                            sw = true;
                        }
                    }
                    if (!sw) break;
                }
            }
        }
    }
}
