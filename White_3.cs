
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lab_7
{
    public class White_3
    {
        public class Student
        {
            private string _name;
            private string _surname;
            private int[] _marks;
            private int _skipped;
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
            public double AvgMark
            {
                get
                {
                    if (_marks == null || _marks.Length == 0)
                    {
                        return 0;
                    }
                    return (double)_marks.Sum() / _marks.Length;
                }
            }
            public int Skipped => _skipped;
            public Student(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _marks = new int[0];
                _skipped = 0;
            }

            protected Student(Student student)
            {
                _name = student._name;
                _surname = student._surname;
                _marks = student._marks.ToArray();
                _skipped = student._skipped;
            }


            public class Undergraduate : Student
            {
                
                public Undergraduate(string name, string surname) : base(name, surname)
                {
                }

                
                public Undergraduate(Student student) : base(student)
                {
                }

                
                public void WorkOff(int mark)
                {
                    if (_skipped > 0)
                    {
                        _skipped--;
                        Lesson(mark);
                    }
                    else
                    {
                        
                        int index = Array.IndexOf(_marks, 2);
                        if (index != -1)
                        {
                            _marks[index] = mark;
                        }
                    }
                }


                public new void Print()
                {
                    Console.WriteLine($"Студент: {Name} {Surname}, Средняя оценка: {AvgMark:F2}, Пропуски: {Skipped}");
                }
            }
            public void Lesson(int mark)
            {
                if (mark == 0)
                {
                    _skipped++;
                }
                else
                {
                    if (_marks == null) return;
                    int[] new_marks = new int[_marks.Length + 1];
                    for (int i = 0; i < _marks.Length; i++)
                    {
                        new_marks[i] = _marks[i];
                    }

                    new_marks[new_marks.Length - 1] = mark;
                    _marks = new_marks;
                }
            }
            public static void SortBySkipped(Student[] array)
            {
                if (array == null || array.Length == 0) return;
                int n = array.Length;
                bool y;
                for (int i = 0; i < n - 1; i++)
                {
                    y = false;
                    for (int j = 0; j < n - 1 - i; j++)
                    {
                        if (array[j].Skipped < array[j + 1].Skipped)
                        {
                            (array[j], array[j + 1]) = (array[j + 1], array[j]);
                            y = true;
                        }
                    }
                    if (!y) break;
                }

            }
            public void Print()
            {
                Console.WriteLine($"Имя: {_name}, Фамилия: {_surname}, Средняя оценка: {AvgMark:F2}, Пропуски: {_skipped}");
            }

        }
    }
}
