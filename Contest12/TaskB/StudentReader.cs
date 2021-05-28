using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class StudentReader : IEnumerable<Student>,IDisposable
{
    private string _path;
    private  (string,List<int>) student ;
    private List<Student> _students = new List<Student>();
    public StudentReader(string path)
    {
        _path = path;
    }

    public IEnumerator<Student> GetEnumerator()
    {
        using (StreamReader streamReader = new StreamReader(_path))
        {
            while (streamReader.Peek() != -1)
            {
                student = Student.PreprocessStudentData(streamReader.ReadLine());
                _students.Add(new Student(student.Item1, student.Item2.
                    Select(x => int.Parse(x.ToString())).ToList()));
            }
        }

        return _students.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Dispose()
    {
    }

    public IEnumerable<Student> GetStudentsWithGreaterGpa(double gpa)
    {
        return _students.Where(x => x.Gpa > gpa).Select(x => x).ToList();;
    }
}