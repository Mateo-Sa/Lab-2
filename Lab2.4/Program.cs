// Подсистема 1: Доступ к базе данных пользователей
public class UserDatabase
{
    public User GetUserById(int userId)
    {
        Console.WriteLine($"Выполняется запрос пользователя с ID: {userId} из UserDatabase");
        return new User { Id = userId, Name = "Matvey" };
    }
}
// Подсистема 2: Доступ к базе данных продуктов
public class ProductDatabase
{
    public Product GetProductById(int productId)
    {
        Console.WriteLine($"Выполняется запрос продукта с ID: {productId} из ProductDatabase");
        return new Product { Id = productId, Name = "Product" };
    }
}
// Вспомогательные классы для данных
public class User { public int Id { get; set; } public string Name { get; set; } }
public class Product { public int Id { get; set; } public string Name { get; set; } }

// Фасад
public class DatabaseFacade
{
    private readonly UserDatabase _userDatabase;
    private readonly ProductDatabase _productDatabase;

    public DatabaseFacade()
    {
        _userDatabase = new UserDatabase();
        _productDatabase = new ProductDatabase();
    }
    public User GetUser(int userId)
    {
        return _userDatabase.GetUserById(userId);
    }
    public Product GetProduct(int productId)
    {
        return _productDatabase.GetProductById(productId);
    }
}
public class Proga
{
    public static void Main(string[] args)
    {
        // Используем Facade для доступа к данным
        DatabaseFacade facade = new DatabaseFacade();

        User user = facade.GetUser(1111);
        Product product = facade.GetProduct(9999);

        Console.WriteLine($"Имя пользователя: {user.Name}");
        Console.WriteLine($"Название продукта: {product.Name}");
    }
}