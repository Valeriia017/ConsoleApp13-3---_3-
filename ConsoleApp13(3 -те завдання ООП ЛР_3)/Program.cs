using System;

class Parent
{
    protected string Pole1; // ім'я
    protected int Pole2; // рік прийняття на роботу
    protected double Pole3; // зарплата
    protected double Pole4; // премія

    public Parent()
    {
    }

    public Parent(string name, int hireYear, double salary)
    {
        Pole1 = name;
        Pole2 = hireYear;
        Pole3 = salary;
    }

    public virtual void Print()
    {
        Console.WriteLine($"\nСпівробітник {Pole1} працює з {Pole2}, зарплата {Pole3}");
        Console.WriteLine($"Премія {Pole4}");
    }

    public void Metod1(int currentYear)
    {
        int experience = currentYear - Pole2;

        if (experience < 5)
        {
            Pole4 = 0.1 * Pole3;
        }
        else if (experience >= 5 && experience <= 10)
        {
            Pole4 = 0.15 * Pole3;
        }
        else if (experience > 10)
        {
            Pole4 = 0.2 * Pole3;
        }
    }
}

class Child : Parent
{
    private int Pole5; // категорія (1, 2, 3)
    private double additionalBonus; // додаткова премія

    public Child(string name, int hireYear, double salary, int category) : base(name, hireYear, salary)
    {
        Pole5 = category;
        additionalBonus = 0.0;
    }

    public override void Print()
    {
        base.Print();
        Console.WriteLine($"Категорія {Pole5}");
        Console.WriteLine($"додаткова премія {additionalBonus}");
    }

    public void Metod2()
    {
        switch (Pole5)
        {
            case 1:
                additionalBonus = 0.5 * Pole4; // Додаткова премія 50% від звичайної премії
                break;
            case 2:
                additionalBonus = 0.3 * Pole4; // Додаткова премія 30% від звичайної премії
                break;
            case 3:
                additionalBonus = 0.2 * Pole4; // Додаткова премія 20% від звичайної премії
                break;
            default:
                Console.WriteLine("Невірна категорія працівника.");
                break;
        }
    }
}

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        // Создание массива работников
        Parent[] employees = new Parent[]
        {
            new Parent("Іван", 2020, 15000),
            new Parent("Петро", 2016, 20000),
            new Parent("Тетяна", 2000, 30000),
            new Child("ВІП1", 2000, 30000, 1),
            new Child("ВІП2", 2005, 35000, 2),
            new Child("ВІП3", 2004, 32000, 3)
        };

        foreach (var employee in employees)
        {
            employee.Metod1(2023);
            if (employee is Child)
            {
                ((Child)employee).Metod2();
            }
            employee.Print();
        }

        Console.ReadKey();
    }
}