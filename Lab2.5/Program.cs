// Компонент: Абстрактная система доставки
public abstract class DeliverySystem
{
    public abstract string GetDeliveryType();
    public abstract decimal CalculateCost(decimal packageWeight);
}
// Конкретные компоненты: Стандартные способы доставки
public class CourierDelivery : DeliverySystem
{
    public override string GetDeliveryType() => "Курьерская доставка";
    public override decimal CalculateCost(decimal packageWeight) => 50 + packageWeight * 10;
}
public class PostalDelivery : DeliverySystem
{
    public override string GetDeliveryType() => "Доставка почтой";
    public override decimal CalculateCost(decimal packageWeight) => 30 + packageWeight * 5;
}
public class PickupDelivery : DeliverySystem
{
    public override string GetDeliveryType() => "Самовывоз";
    public override decimal CalculateCost(decimal packageWeight) => 0; // Бесплатно
}
// Декоратор: Абстрактный класс, добавляющий функциональность
public abstract class DeliveryDecorator : DeliverySystem
{
    protected DeliverySystem _deliverySystem; // Ссылка на оборачиваемый объект

    protected DeliveryDecorator(DeliverySystem deliverySystem)
    {
        _deliverySystem = deliverySystem;
    }
}
// Конкретный декоратор: Экспресс-доставка
public class ExpressDeliveryDecorator : DeliveryDecorator
{
    public ExpressDeliveryDecorator(DeliverySystem deliverySystem) : base(deliverySystem) { }

    public override string GetDeliveryType() => $"{_deliverySystem.GetDeliveryType()} + Экспресс";

    public override decimal CalculateCost(decimal packageWeight) => _deliverySystem.CalculateCost(packageWeight) + 75;

    public string TrackDeliveryStatus()
    {
        return "Заказ в пути, ориентировочное время доставки - завтра.";
    }
}
public class Proga
{
    public static void Main(string[] args)
    {
        DeliverySystem courier = new CourierDelivery();
        Console.WriteLine($"{courier.GetDeliveryType()}: {courier.CalculateCost(2)}"); // Курьерская доставка: 70

        DeliverySystem expressCourier = new ExpressDeliveryDecorator(new CourierDelivery());
        Console.WriteLine($"{expressCourier.GetDeliveryType()}: {expressCourier.CalculateCost(2)}"); //Курьерская доставка + Экспресс: 145
        Console.WriteLine(((ExpressDeliveryDecorator)expressCourier).TrackDeliveryStatus()); // Заказ в пути, ориентировочное время доставки - завтра.

        DeliverySystem expressPickup = new ExpressDeliveryDecorator(new PickupDelivery());
        Console.WriteLine($"{expressPickup.GetDeliveryType()}: {expressPickup.CalculateCost(2)}");// Самовывоз + Экспресс: 75

        DeliverySystem Posta = new PostalDelivery();
        Console.WriteLine($"{Posta.GetDeliveryType()}: {Posta.CalculateCost(2)}"); // Доставка Почтой: 40

        DeliverySystem expressPosta = new ExpressDeliveryDecorator(new PostalDelivery());
        Console.WriteLine($"{expressPosta.GetDeliveryType()}: {expressPosta.CalculateCost(2)}");// Доставка Почтой + Экспресс: 115
    }
}