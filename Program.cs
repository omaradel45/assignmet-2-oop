using System;

public enum SecurityLevel
{
    Guest,
    Developer,
    Secretary,
    DBA
}

public class HiringDate
{
    private int _day;
    private int _month;
    private int _year;

    public int Day
    {
        get { return _day; }
        set { _day = (value > 0 && value <= 31) ? value : 1; }
    }
    public int Month
    {
        get { return _month; }
        set { _month = (value > 0 && value <= 12) ? value : 1; }
    }
    public int Year
    {
        get { return _year; }
        set { _year = value; }
    }

    public HiringDate(int day, int month, int year)
    {
        Day = day;
        Month = month;
        Year = year;
    }
}

public class Employee
{
    private int _id;
    private string _name;
    private SecurityLevel _securityLevel;
    private decimal _salary;
    private HiringDate _hireDate;
    private char _gender;

    public int ID
    {
        get { return _id; }
        set { _id = value; }
    }
    public string Name
    {
        get { return _name; }
        set { _name = string.IsNullOrEmpty(value) ? "Unknown" : value; }
    }
    public SecurityLevel SecurityLevel
    {
        get { return _securityLevel; }
        set { _securityLevel = value; }
    }
    public decimal Salary
    {
        get { return _salary; }
        set { _salary = value >= 0 ? value : 0; }
    }
    public HiringDate HireDate
    {
        get { return _hireDate; }
        set { _hireDate = value; }
    }
    public char Gender
    {
        get { return _gender; }
        set { _gender = char.ToUpper(value) == 'M' || char.ToUpper(value) == 'F' ? char.ToUpper(value) : 'U'; }
    }

    public Employee(int id, string name, SecurityLevel securityLevel, decimal salary, HiringDate hireDate, char gender)
    {
        ID = id;
        Name = name;
        SecurityLevel = securityLevel;
        Salary = salary;
        HireDate = hireDate;
        Gender = gender;
    }

    public override string ToString()
    {
        return $"ID: {ID}, Name: {Name}, Security Level: {SecurityLevel}, Salary: {Salary:C}, Hire Date: {HireDate.Month}/{HireDate.Day}/{HireDate.Year}, Gender: {Gender}";
    }
}

public class Example
{
    public static void Main(string[] args)
    {
        Employee[] empArr = new Employee[3];

        empArr[0] = new Employee(1, "John Doe", SecurityLevel.DBA, 5000, new HiringDate(1, 1, 2020), 'M');
        empArr[1] = new Employee(2, "Jane Smith", SecurityLevel.Guest, 2000, new HiringDate(5, 7, 2022), 'F');
        empArr[2] = new Employee(3, "Admin User", SecurityLevel.DBA, 8000, new HiringDate(10, 12, 2021), 'U'); // Full permissions (DBA)

        foreach (var emp in empArr)
        {
            Console.WriteLine(emp);
        }

        Console.ReadLine();
    }
}