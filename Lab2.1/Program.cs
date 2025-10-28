// Абстрактный компонент
public abstract class Component
{
    public abstract decimal GetPrice();
}
// Продукт
public class Product : Component
{
    private decimal price;

    public Product(decimal price)
    {
        this.price = price;
    }
    public override decimal GetPrice()
    {
        return price;
    }
}
// Коробки
public class Box : Component
{
    private List<Component> components = new List<Component>();
    public void Add(Component component)
    {
        components.Add(component);
    }
    public override decimal GetPrice()
    {
        decimal total = 0;
        foreach (Component component in components)
        {
            total += component.GetPrice();
        }
        return total;
    }
}
// Класс заказа
public class Order
{
    private List<Component> items = new List<Component>();
    public void Add(Component component)
    {
        items.Add(component);
    }
    public decimal GetTotalPrice()
    {
        decimal total = 0;
        foreach (Component item in items)
        {
            total += item.GetPrice();
        }
        return total;
    }
}
public class Proga
{
    public static void Main(string[] args)
    {
           //Создаем продукты с ценами
        Product product1 = new Product(10);
        Product product2 = new Product(20);
        Product product3 = new Product(30);
                              // Создаем коробки и добавляем в них продукты
        Box box1 = new Box();
        box1.Add(product1);
        box1.Add(product2);
                               // Вторая коробка
        Box box2 = new Box();
        box2.Add(product3);
        box2.Add(box1);
                            // Создаем заказ и добавляем в него продукты и коробки
        Order order = new Order();
        order.Add(product1);
        order.Add(box2);
        // Считаем цену всего заказа
        decimal Summa = order.GetTotalPrice();
        Console.WriteLine($"Общая цена заказа: {Summa}");
    }
}