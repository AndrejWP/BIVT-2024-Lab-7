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
            private string _name;
            private string _surname;
            

            public string Surname
            {
                get
                {
                    if (_surname == null) return default;
                    return _surname;
                }
            }
            public string Name
            {
                get
                {
                    if (_name == null) return default;
                    return _name;
                }
            }
            public Human(string name, string surname)
            {
                _name = name;
                _surname = surname;
            }
            public virtual void Print()
            {
                Console.WriteLine($"Имя: {_name}, Фамилия: {_surname}");
            }
        }
        public class Participant : Human
        {
            // Поле для хранения очков
            private double[] _scores;

            // Статическое поле для подсчёта общего количества участников
            private static int _count = 0;

            // Статическое свойство Count для чтения общего количества участников
            public static int Count => _count;

            // Статический конструктор для инициализации общего количества участников
            static Participant()
            {
                _count = 0;
            }

            // Свойство для получения копии массива очков
            public double[] Scores
            {
                get
                {
                    if (_scores == null)
                    {
                        return default(double[]);
                    }

                    var newArray = new double[_scores.Length];
                    Array.Copy(_scores, newArray, _scores.Length);
                    return newArray;
                }
            }

            // Свойство для получения суммы очков
            public double TotalScore => (_scores != null) ? _scores.Sum() : 0;

            // Конструктор
            public Participant(string name, string surname) : base(name, surname)
            {
                _scores = new double[0];
                _count++; // Увеличиваем счётчик участников
            }

            // Метод для добавления результата матча
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

            // Метод для сортировки участников по сумме очков
            public static void Sort(Participant[] array)
            {
                if (array == null || array.Length == 0) return;
                int n = array.Length;
                bool y;
                for (int i = 0; i < n - 1; i++)
                {
                    y = false;
                    for (int j = 0; j < n - 1 - i; j++)
                    {
                        if (array[j].TotalScore < array[j + 1].TotalScore)
                        {
                            (array[j], array[j + 1]) = (array[j + 1], array[j]);
                            y = true;
                        }
                    }
                    if (!y) break;
                }
            }

            
            public override void Print()
            {
                base.Print();
                Console.WriteLine($"Очки: {TotalScore:F1}");
            }
        }
    }
    
}