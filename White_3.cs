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
            protected string _name;
            protected string _surname;
            protected int[] _marks;
            protected int _skipped;

            public string Surname => _surname ?? default;
            public string Name => _name ?? default;

            public double AvgMark =>
                (_marks == null || _marks.Length == 0)
                ? 0
                : (double)_marks.Sum() / _marks.Length;

            public int Skipped => _skipped;

            public Student(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _marks = Array.Empty<int>();
                _skipped = 0;
            }

            protected Student(Student student)
            {
                _name = student._name;
                _surname = student._surname;
                _marks = student._marks.ToArray();
                _skipped = student._skipped;
            }

            public void Lesson(int mark)
            {
                if (mark == 0) _skipped++;
                else _marks = [.. _marks, mark];
            }

            public static void SortBySkipped(Student[] array)
            {
                if (array == null || array.Length == 0) return;

                for (int i = 0; i < array.Length - 1; i++)
                {
                    bool swapped = false;
                    for (int j = 0; j < array.Length - 1 - i; j++)
                    {
                        if (array[j].Skipped >= array[j + 1].Skipped) continue;

                        (array[j], array[j + 1]) = (array[j + 1], array[j]);
                        swapped = true;
                    }
                    if (!swapped) break;
                }
            }

            public virtual void Print()
            {
                Console.WriteLine(
                    $"Имя: {_name}, " +
                    $"Фамилия: {_surname}, " +
                    $"Средняя оценка: {AvgMark:F2}, " +
                    $"Пропуски: {Skipped}"
                );
            }
        }

        public class Undergraduate : Student
        {
            public Undergraduate(string name, string surname) : base(name, surname) { }

            public Undergraduate(Student student) : base(student) { }

            public void WorkOff(int mark)
            {
                if (_skipped > 0)
                {
                    _skipped--;
                    Lesson(mark);
                    return;
                }

                int index = Array.IndexOf(_marks, 2);
                if (index != -1) _marks[index] = mark;
            }

            public override void Print()
            {
                Console.WriteLine(
                    $"Студент: {Name} {Surname}, " +
                    $"Средняя оценка: {AvgMark:F2}, " +
                    $"Пропуски: {Skipped}"
                );
            }
        }
    }


}
