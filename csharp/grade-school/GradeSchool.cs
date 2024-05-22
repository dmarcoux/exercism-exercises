using System;
using System.Collections.Generic;
using System.Linq;

public class GradeSchool
{
    private readonly SortedDictionary<int, SortedSet<string>> _students = new SortedDictionary<int, SortedSet<string>>();

    public bool Add(string studentName, int grade)
    {
        // The school is in a small town, kids always have a unique name, so there can only be one kid with that name.
        if (_students.Values.Any(s => s.Contains(studentName)))
            return false;

        // Try to add both grade and student. If grade is already present, it will fail and add the student only
        return _students.TryAdd(grade, [studentName]) || _students[grade].Add(studentName);
    }

    public IEnumerable<string> Roster() => _students.Values.SelectMany(s => s);

    public IEnumerable<string> Grade(int grade) => _students.GetValueOrDefault(grade, []);
}