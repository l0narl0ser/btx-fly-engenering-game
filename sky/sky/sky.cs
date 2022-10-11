using sky;
using System;
using System.Linq;



public class Ex
{
    public static void Main()
    {
        

        Gear[] gears = new Gear[5];
        for (int i = 0; i < 5; i++)
        {
            gears[i] = new Gear(); //создали шестеренку
            gears[i].SetId(i.ToString());
        }
        Random random = new Random();

        foreach (Gear gear in gears)
        {
            gear.SetEdge(random.Next()%100);
        }
        Engine engine = new Engine(gears);
        int summerGear = engine.SearchGear(50);
        Console.WriteLine(summerGear);
        Console.ReadLine();
   }

}

