/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package studentsandgroups;

/**
 *
 * @author PC
 */
public class Group
{
	private final static int MAX_STUDENTS_COUNT = 10;
	private Student[] _students = new Student[MAX_STUDENTS_COUNT];
	private int _currentCount = 0;
	
	public void addStudent(Student student)
	{
            if (_currentCount < MAX_STUDENTS_COUNT)
            {
                _students[_currentCount++] = student;
            }
	}
	
	public void removeStudent(Student student)
	{
		for (int i = 0; i < MAX_STUDENTS_COUNT; i++)
		{
			if (_students[i] == student)
			{
				_students[i] = null;
				for (int j = i + 1; i < MAX_STUDENTS_COUNT; i++)
				{
					if (_students[j] == null) break;
					_students[j - 1] = _students[j];
				}
				_currentCount--;
				break;
			}
		}
	}
	
	public Student getStudentByLastName(String lastName)
	{
		for (int i = 0; i < _currentCount; i++)
		{
			if (_students[i].getLastName().contentEquals(lastName))
			{
				return _students[i];
			}
		}
		return null;
	}
	
	public void printInfo()
	{
		for (int i = 0; i < _currentCount; i++)
		{
			_students[i].printInfo();
			ConsoleHelper.writeLine("");
		}
	}
	
	public void editStudent(Student oldStudent, Student newStudent)
	{
		for (int i = 0; i < MAX_STUDENTS_COUNT; i++)
		{
			if (_students[i] == oldStudent)
			{
				_students[i] = newStudent;
				break;
			}
		}
	}
}
