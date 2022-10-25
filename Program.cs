
using System;
using System.Text.Json;
Shop S = new Shop();
S.VvodVeg();
S.VvodMeat();
S.VvodFruit();
S.CreateSettings();
S.LoadSettings();
class Shop
{
    public Vegetables[] vegetabl;
    public Meat[] meat;
    public Fruit[] fruit;
    public Shop()
    {
        vegetabl = new Vegetables[1-1];
        meat = new Meat[1-1];
        fruit = new Fruit[1-1];
    }
    public void VvodVeg()
    {
        Console.WriteLine("Заполните массив");
        Array.Resize(ref vegetabl, vegetabl.Length+1);
      
            Console.WriteLine("Зополняем" + "[" + (vegetabl.Length - 1 + 1) + "]");
            vegetabl[vegetabl.Length-1] = new();
            Console.WriteLine("Имя овоща");
            vegetabl[vegetabl.Length - 1].Name = Console.ReadLine();
            Console.WriteLine("Цена");
            vegetabl[vegetabl.Length - 1].Price = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Вес");
            vegetabl[vegetabl.Length - 1].Weight = Convert.ToDouble(Console.ReadLine());
    }
    public  void VvodMeat()
    {
        Console.WriteLine("Заполните массив");
        Array.Resize(ref meat, meat.Length + 1);
       
            Console.WriteLine("Зополняем" + "[" + (meat.Length-1 + 1) + "]");
            meat[meat.Length - 1] = new();
            Console.WriteLine("Имя мяса");
            meat[meat.Length - 1].Name = Console.ReadLine();
            Console.WriteLine("Цена");
            meat[meat.Length - 1].Price = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Вес");
            meat[meat.Length - 1].Weight = Convert.ToDouble(Console.ReadLine());
    }
    public void VvodFruit()
    {
        Console.WriteLine("Заполните массив");
        Array.Resize(ref fruit, fruit.Length + 1);
        
            Console.WriteLine("Зополняем" + "[" + (fruit.Length-1 + 1) + "]");
            fruit[fruit.Length - 1] = new();
            Console.WriteLine("Имя фрукта");
            fruit[fruit.Length - 1].Name = Console.ReadLine();
            Console.WriteLine("Цена");
            fruit[fruit.Length - 1].Price = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Вес");
            fruit[fruit.Length - 1].Weight = Convert.ToDouble(Console.ReadLine());
    }
    public async void CreateSettings()
    {
        try
        {
            using (FileStream f = new("Vegetable.json", FileMode.Create))
            {
                foreach(var ve in vegetabl)
                {
                    Vegetables folder = new(ve.Name, ve.Price,ve.Weight);
                    await JsonSerializer.SerializeAsync<Vegetables>(f, folder);
                }
            }
        }
        catch (Exception e) { Console.WriteLine(e.Message); }
        try
        {
            using (FileStream f2 = new("Meat.json", FileMode.Create))
            {
                foreach (var ve2 in meat)
                {
                    Meat folder2 = new(ve2.Name, ve2.Price, ve2.Weight);
                    await JsonSerializer.SerializeAsync<Meat>(f2, folder2);
                }
            }
        }
        catch (Exception e) { Console.WriteLine(e.Message); }
        try
        {
            using (FileStream f = new("Fruit.json", FileMode.Create))
            {
                foreach (var ve3 in fruit)
                {
                    Fruit folder3 = new(ve3.Name, ve3.Price, ve3.Weight);
                    await JsonSerializer.SerializeAsync<Fruit>(f, folder3);
                }
            }
        }
        catch (Exception e) { Console.WriteLine(e.Message); }
    }
    public void LoadSettings()
    {
        try
        {
            using (FileStream f2 = new("Fruit.json", FileMode.Open))
            {
                string json = null;
                var i = new JsonSerializerOptions { WriteIndented = true };
                foreach (Fruit p in fruit)
                    json += JsonSerializer.Serialize<Fruit>(p/*, i*/) + "\n";
                Console.WriteLine(json);
                Console.WriteLine();
            }
        }
        catch (Exception e) { Console.WriteLine(e.Message); }
        try
        {
            using (FileStream f2 = new("Meat.json", FileMode.Open))
            {
                string json = null;
                var i = new JsonSerializerOptions { WriteIndented = true };
                foreach (Meat p in meat)
                    json += JsonSerializer.Serialize<Meat>(p/*, i*/) + "\n";
                Console.WriteLine(json);
                Console.WriteLine();
            }
        }
        catch (Exception e) { Console.WriteLine(e.Message); }
        try
        {
            using (FileStream f2 = new("Vegetable.json", FileMode.Open))
            {
                string json = null;
                var i = new JsonSerializerOptions { WriteIndented = true };
                foreach (Vegetables p in vegetabl)
                    json += JsonSerializer.Serialize<Vegetables>(p/*, i*/) + "\n";
                Console.WriteLine(json);
                Console.WriteLine();
            }
        }
        catch (Exception e) { Console.WriteLine(e.Message); }
    }
}
abstract class Product
{
    public string Name { get; set; }
    public double Price { get; set; }
    public double Weight { get; set; }
  

}
class Vegetables:Product
{
    public Vegetables() {}
    public Vegetables(string name, double price, double weight)
    {
        Name = name;
        Price = price;
        Weight = weight;
    }
}
class Meat : Product
{
    public Meat() { }
    public Meat(string name, double price, double weight)
    {
        Name = name;
        Price = price;
        Weight = weight;
    }
}
class Fruit : Product
{
    public Fruit(){}
    public Fruit(string name, double price, double weight)
    {
        Name = name;
        Price = price;
        Weight = weight;
    }
}