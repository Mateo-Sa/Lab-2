// Интерфейс Дороги
public interface IRoad
{
    string GetRoadType();
}
// Класс дороги
public class Road : IRoad
{
    public string GetRoadType()
    {
        return "Обычной дороге";
    }
}
// Абстрактный класс Транспорта
public abstract class Transport
{
    public abstract string Ride(IRoad road);
}
// Класс Машины
public class Car : Transport
{
    public override string Ride(IRoad road)
    {
        return $"Машина едет по {road.GetRoadType()}";
    }
}
// Класс Осла (не является транспортом)
public class Donkey
{
    public string Eat()
    {
        return "Осел кушает";
    }
}
// Класс Седла, адаптирующий осла под транспорт
public class SaddleAdapter : Transport
{
    private Donkey donkey;
    public SaddleAdapter(Donkey donkey)
    {
        this.donkey = donkey;
    }
    public override string Ride(IRoad road)
    {
        return $"Осел с седлом едет по {road.GetRoadType()}";
    }
}
public class Proga
{
    public static void Main(string[] args)
    {
        IRoad road = new Road();
        Car car = new Car();
        Donkey donkey = new Donkey();

        Console.WriteLine(car.Ride(road)); // Машина едет

        SaddleAdapter adaptedDonkey = new SaddleAdapter(donkey);
        Console.WriteLine(adaptedDonkey.Ride(road)); // Осел с седлом едет

        Console.WriteLine(donkey.Eat()); // Осел кушает 
    }
}