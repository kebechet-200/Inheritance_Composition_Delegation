// Uncomment only one approach to make this work. :)


/* FIRST (1) APPROACH using Inheritance 
 This approach works only the case when you have only one base class, for example engine here, 
 In this scenario only engine has started before the car start.
 If you have to call more than one classes method, this approach is useless.
 */

var car = new Car();
car.StartCar();

public class Engine
{
    private protected void Start() =>
        Console.WriteLine("Engine started!");

    private protected void Stop() =>
        Console.WriteLine("Engine stopped!");
}

public class Car : Engine
{
    public void StartCar()
    {
        base.Start();
        Console.WriteLine("Car started!");
    }

    public void StopCar()
    {
        base.Stop();
        Console.WriteLine("Car stopped");
    }
}

/* SECOND (2) APPROACH using Composition
 Unlike Inheritance this approach works for multiple base classses. you just need to create them in constructor. (use DI)
 I like this approach because you have almost full functionality, but there is 1 thing that I'm not happy for.
 If I want to use only one method from the class, when I create instance, I have access all over the class methods.
 Theres why delegation comes into play (3-rd approach)
 */

var car = new Car();
car.StartCar();

public class Engine
{
   internal void Start() =>
       Console.WriteLine("Engine started!");
   internal void Stop() =>
       Console.WriteLine("Engine stopped!");
}

public class Car
{
   private readonly Engine _engine;
   public Car()
   {
       _engine = new Engine();
   }
   public void StartCar()
   {
       _engine.Start();
       Console.WriteLine("Car started!");
   }

   public void StopCar()
   {
       _engine.Stop();
       Console.WriteLine("Car stopped");
   }
}

/* Third (3) APPROACH!! Using Delegation */


var car = new Car();
car.StartCar();
car.StopCar();

delegate void StartEngine();
delegate void StopEngine();

public class Engine
{
   internal void Start() =>
       Console.WriteLine("Engine started!");
   internal void Stop() =>
       Console.WriteLine("Engine stopped!");
}

public class Car
{
   private readonly StartEngine _startEngine;
   private readonly StopEngine _stopEngine; // you can comment it and second method StopCar() and the program will work well
   public Car()
   {
       _startEngine = new Engine().Start;
       _stopEngine = new Engine().Stop;
   }
   public void StartCar()
   {
       _startEngine();
       Console.WriteLine("Car started!");
   }

   public void StopCar()
   {
       _stopEngine();
       Console.WriteLine("Car stopped");
   }
}
