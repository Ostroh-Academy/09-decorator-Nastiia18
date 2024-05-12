using System;

// Абстрактний клас заводу
abstract class Factory
{
    public abstract void Produce();
}

// Конкретний клас заводу
class ConcreteFactory : Factory
{
    public override void Produce()
    {
        Console.WriteLine("Виробництво цивільного обладнання...");
    }
}

// Декоратор для виробництва військового обладнання
class MilitaryEquipmentDecorator : Factory
{
    private Factory factory;

    public MilitaryEquipmentDecorator(Factory factory)
    {
        this.factory = factory;
    }

    public override void Produce()
    {
        factory.Produce(); // Викликаємо метод виробництва базового заводу
        Console.WriteLine("Додаємо виробництво військового обладнання...");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Створюємо базовий завод
        Factory factory = new ConcreteFactory();

        // Додаємо декоратор для виробництва військового обладнання
        Factory militaryFactory = new MilitaryEquipmentDecorator(factory);

        // Запускаємо виробництво
        militaryFactory.Produce();
    }
}

