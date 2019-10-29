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
public class Student
{
	private String _lastName;
	private String _firstName;
	private int _age;
	private boolean _sex;
	private double[] _marks = new double[3];
	
	private final static String[] _subjects = new String[] { "Programming", "System Administration", "Design" };
	public final static int PROGRAMMING = 0;
	public final static int SYSTEM_ADMINISTRATION = 1;
	public final static int DESIGN = 2;
	
        private Student() {}
        
	public Student(String lastName, String firstName, int age, boolean sex)
	{
		_lastName = lastName;
		_firstName = firstName;
		_age = age;
		_sex = sex;
		for (int i = 0; i < 3; i++) _marks[i] = -1;
	}
	
	public void setLastName(String lastName)
	{
		_lastName = lastName;
	}
	
	public void setFirstName(String firstName)
	{
		_firstName = firstName;
	}
	
	public void setAge(int age)
	{
		_age = age;
	}
	
	public void setSex(boolean sex)
	{
		_sex = sex;
	}
	
	public void setMark(int subject, double value)
	{
		if (subject < 0 || subject > 2)
		{
			throw new ArrayIndexOutOfBoundsException("Unknown subject");
		}
		_marks[subject] = value;
	}
	
	public String getLastName()
	{
		return _lastName;
	}
	
	public String getFirstName()
	{
		return _firstName;
	}
	
	public int getAge()
	{
		return _age;
	}
	
	public boolean getSex()
	{
		return _sex;
	}
	
	public double getMark(int subject)
	{
		if (subject < 0 || subject > 2)
		{
			throw new ArrayIndexOutOfBoundsException("Unknown subject");
		}
		return _marks[subject];
	}
	
	public void printInfo()
	{
		ConsoleHelper.writeLine("LastName: " + _lastName);
		ConsoleHelper.writeLine("FirstName: " + _firstName);
		ConsoleHelper.writeLine("Age: " + _age);
		ConsoleHelper.writeLine("Sex: " + ((_sex) ? "Male" : "Female"));
		ConsoleHelper.writeLine("Marks:");
		for (int i = 0; i < 3; i++)
		{
			if (_marks[i] != -1)
			{
				ConsoleHelper.writeLine(_subjects[i] + ": " + _marks[i]);
			}
		}
	}
	
	public static Student create()
	{
		Student result = new Student();
		
		ConsoleHelper.write("Enter student's lastname: ");
		result.setLastName(ConsoleHelper.readLine());
		
		ConsoleHelper.write("Enter student's firstname: ");
		result.setFirstName(ConsoleHelper.readLine());
		
		int age = -1;
		do
		{
			ConsoleHelper.write("Enter student's age (>= 16): ");
			age = ConsoleHelper.getInt();
		} while (age < 16);
		result.setAge(age);
		
		String sex = "";
		do
		{
			ConsoleHelper.write("Enter student's sex (male or female): ");
			sex = ConsoleHelper.readLine();
		} while (!sex.contentEquals("male") && !sex.contentEquals("female"));
		result.setSex(sex.contentEquals("male"));
		
		ConsoleHelper.writeLine("Now let's enter student's marks:");
		for (int i = 0; i < 3; i++)
		{
			double mark = -1;
			do
			{
				ConsoleHelper.write(_subjects[i] + " mark (from 1 to 5): ");
				mark = ConsoleHelper.getDouble();
			} while (mark < 1 || mark > 5);
			result.setMark(i, mark);
		}
		return result;
	}
}
