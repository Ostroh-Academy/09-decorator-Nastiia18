using System;
using System.Collections.Generic;

// Клас товару
class Item
{
    public string Name { get; }
    public double Price { get; }

    public Item(string name, double price)
    {
        Name = name;
        Price = price;
    }
}

// Абстрактний клас замовлення
abstract class Order
{
    public abstract void AddItem(Item item);
    public abstract double CalculateTotal();
}

// Конкретний клас замовлення
class ConcreteOrder : Order
{
    private List<Item> items = new List<Item>();

    public override void AddItem(Item item)
    {
        items.Add(item);
    }

    public override double CalculateTotal()
    {
        double total = 0;
        foreach (var item in items)
        {
            total += item.Price;
        }
        return total;
    }
}

// Декоратор замовлення
abstract class OrderDecorator : Order
{
    protected Order order;

    public OrderDecorator(Order order)
    {
        this.order = order;
    }

    public override void AddItem(Item item)
    {
        order.AddItem(item);
    }

    public override double CalculateTotal()
    {
        return order.CalculateTotal();
    }
}

// Декоратор для додавання податку
class TaxDecorator : OrderDecorator
{
    public TaxDecorator(Order order) : base(order) { }

    public override double CalculateTotal()
    {
        return order.CalculateTotal() * 1.1; // Додаємо 10% податку
    }
}

// Декоратор для обробки знижок
class DiscountDecorator : OrderDecorator
{
    private double discount;

    public DiscountDecorator(Order order, double discount) : base(order)
    {
        this.discount = discount;
    }

    public override double CalculateTotal()
    {
        return order.CalculateTotal() * (1 - discount); // Знижка у відсотках
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Створюємо базове замовлення
        Order order = new ConcreteOrder();

        // Додаємо товари до замовлення
        order.AddItem(new Item("Піца", 12.99));
        order.AddItem(new Item("Напій", 2.49));

        // Додаємо декоратори
        Order orderWithTax = new TaxDecorator(order); // З додаванням податків
        Order orderWithDiscount = new DiscountDecorator(order, 0.1); // Зі знижкою 10%

        // Отримуємо загальну вартість
        Console.WriteLine("Ціна з податками: " + orderWithTax.CalculateTotal());
        Console.WriteLine("Ціна зі знижкою: " + orderWithDiscount.CalculateTotal());
    }
}
