using System;

class GenericClass<T>
{
    private T data;

    public GenericClass(T value)
    {
        data = value;
    }
    public void Display()
    {
        Console.WriteLine("Value: " + data);
    }
}
class Program
{
    static void Main()
    {
        GenericClass<int> obj1 = new GenericClass<int>(100);
        obj1.Display();

        GenericClass<string> obj2 = new GenericClass<string>("GeeksForGeeks");
        obj2.Display();
    }
}