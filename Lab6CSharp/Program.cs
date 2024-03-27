using System;
using System.Collections;

// Task1

interface IEngine
{
    void Show();
    int GetPrice();
}

class Engine : IEngine
{
    protected string Name { get; set; }
    protected int GuaranteePeriod { get; set; }
    protected int Price { get; set; }

    public Engine(string name, int guaranteePeriod, int price)
    {
        Name = name;
        GuaranteePeriod = guaranteePeriod;
        Price = price;
        Console.WriteLine("Engine constructor called.");
    }

    public virtual void Show()
    {
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Guarantee Period: {GuaranteePeriod}");
        Console.WriteLine($"Price: {Price}");
    }

    public int GetPrice()
    {
        return Price;
    }
}

class InternalCombustionEngine : Engine
{
    protected int Count { get; set; }

    public InternalCombustionEngine(string name, int guaranteePeriod, int price, int count)
        : base(name, guaranteePeriod, price)
    {
        Count = count;
        Console.WriteLine("InternalCombustionEngine constructor called.");
    }

    public override void Show()
    {
        base.Show();
        Console.WriteLine($"Count: {Count}");
    }
}

class DieselEngine : InternalCombustionEngine
{
    protected string Weight { get; set; }

    public DieselEngine(string name, int guaranteePeriod, int price, int count, string weight)
        : base(name, guaranteePeriod, price, count)
    {
        Weight = weight;
        Console.WriteLine("DieselEngine constructor called.");
    }

    public override void Show()
    {
        base.Show();
        Console.WriteLine($"Weight: {Weight}");
    }
}

class JetEngine : Engine
{
    protected string Model { get; set; }

    public JetEngine(string name, int guaranteePeriod, int price, string model)
        : base(name, guaranteePeriod, price)
    {
        Model = model;
        Console.WriteLine("JetEngine constructor called.");
    }

    public override void Show()
    {
        base.Show();
        Console.WriteLine($"Model: {Model}");
    }
}

// Task1
// Task2

public interface IDotNet
{
    DateTime CreatedAt { get; }
}

public interface IFunction : IDotNet
{
    double Calculate(double x);
}

public abstract class FunctionBase : IFunction
{
    public DateTime CreatedAt { get; } = DateTime.Now;

    public abstract double Calculate(double x);
}

public class Line : FunctionBase
{
    private double a;
    private double b;

    public Line(double a, double b)
    {
        this.a = a;
        this.b = b;
    }

    public override double Calculate(double x)
    {
        return a * x + b;
    }
}

public class Kub : FunctionBase
{
    private double a;
    private double b;
    private double c;

    public Kub(double a, double b, double c)
    {
        this.a = a;
        this.b = b;
        this.c = c;
    }

    public override double Calculate(double x)
    {
        return a * x * x + b * x + c;
    }
}
public class Hyperbola : FunctionBase
{
    public override double Calculate(double x)
    {
        return 1.0 / x;
    }
}

// Task2
// Task3

public class Triangle : IEnumerable
{
    private int a, b, c;
    private string color;

    public Triangle(int f, int s, int t)
    {
        a = f;
        b = s;
        c = t;
        color = "none";
    }

    public Triangle(int f, int s, int t, string col)
    {
        a = f;
        b = s;
        c = t;
        color = col;
    }

    public void Print()
    {
        Console.WriteLine($"Triangle lines: a = {a}, b = {b}, c = {c}, color = {color}");
    }

    public int First
    {
        get { return a; }
        set { a = value; }
    }

    public int Second
    {
        get { return b; }
        set { b = value; }
    }

    public int Third
    {
        get { return c; }
        set { c = value; }
    }

    public string Color
    {
        get { return color; }
    }

    public int Perimeter()
    {
        return a + b + c;
    }

    public double Area()
    {
        float halfperimeter = (a + b + c) / 2;
        return Math.Sqrt(halfperimeter * (halfperimeter - a) * (halfperimeter - b) * (halfperimeter - c));
    }

    public int this[int index]
    {
        get
        {
            switch (index)
            {
                case 0: return a;
                case 1: return b;
                case 2: return c;
                default: throw new IndexOutOfRangeException("Index out of range.");
            }
        }
        set
        {
            switch (index)
            {
                case 0: a = value; break;
                case 1: b = value; break;
                case 2: c = value; break;
                case 3: color = value.ToString(); break;
                default: throw new IndexOutOfRangeException("Index out of range.");
            }
        }
    }

    public static Triangle operator ++(Triangle triangle)
    {
        triangle.a++;
        triangle.b++;
        triangle.c++;
        return triangle;
    }

    public static Triangle operator --(Triangle triangle)
    {
        triangle.a--;
        triangle.b--;
        triangle.c--;
        return triangle;
    }

    public static bool operator true(Triangle triangle)
    {
        return triangle.a + triangle.b > triangle.c && triangle.a + triangle.c > triangle.b && triangle.b + triangle.c > triangle.a;
    }

    public static bool operator false(Triangle triangle)
    {
        return triangle.a + triangle.b <= triangle.c || triangle.a + triangle.c <= triangle.b || triangle.b + triangle.c <= triangle.a;
    }

    public static Triangle operator *(Triangle triangle, int scalar)
    {
        triangle.a *= scalar;
        triangle.b *= scalar;
        triangle.c *= scalar;
        return triangle;
    }

    public static implicit operator string(Triangle triangle)
    {
        return $"Triangle lines: a = {triangle.a}, b = {triangle.b}, c = {triangle.c}, color = {triangle.color}";
    }
    public IEnumerator GetEnumerator()
    {
        return new TriangleEnumerator(this);
    }

    private class TriangleEnumerator : IEnumerator
    {
        private int position = -1;
        private Triangle triangle;

        public TriangleEnumerator(Triangle triangle)
        {
            this.triangle = triangle;
        }

        public bool MoveNext()
        {
            position++;
            return position < 3;
        }

        public void Reset()
        {
            position = -1;
        }

        public object Current
        {
            get
            {
                switch (position)
                {
                    case 0: return triangle.First;
                    case 1: return triangle.Second;
                    case 2: return triangle.Third;
                    default: throw new InvalidOperationException();
                }
            }
        }
    }
}
// Task3

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter the task(3): ");
        string? str = Console.ReadLine();
        int n = 0;
        if (str != null) n = int.Parse(str);

        // Task1

        if (n == 1)
        {
            IEngine engine = new Engine("Generic Engine", 24, 1000);
            engine.Show();
            Console.WriteLine();

            InternalCombustionEngine internalCombustionEngine = new InternalCombustionEngine("Internal Combustion Engine", 36, 2000, 6);
            internalCombustionEngine.Show();
            Console.WriteLine();

            DieselEngine dieselEngine = new DieselEngine("Diesel Engine", 48, 3000, 8, "Heavy");
            dieselEngine.Show();
            Console.WriteLine();

            JetEngine jetEngine = new JetEngine("Jet Engine", 60, 5000, "Turbo");
            jetEngine.Show();
        }

        // Task1
        // Task2

        else if (n == 2)
        {
            IFunction[] functions = new IFunction[]
            {
            new Line(2, 3),
            new Kub(1, -2, 1),
            new Hyperbola()
            };

            double x = 2.5;

            foreach (var function in functions)
            {
                Console.WriteLine($"Function : {function}");
                Console.WriteLine($"Value of the function at x = {x}: {function.Calculate(x)}");
                Console.WriteLine();
            }
        }

        // Task2
        // Task3

        else if (n == 3)
        {
            Triangle triangle = new Triangle(3, 4, 5, "Red");

            foreach (var item in triangle)
            {
                if (item is int)
                {
                    Console.WriteLine($"Length of side: {item}");
                }
                else if (item is string)
                {
                    Console.WriteLine($"Color: {item}");
                }
            }
        }

        // Task3
    }
}
