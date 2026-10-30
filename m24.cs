using System;
using System.Collections.Generic;

namespace Task24_Animals
{
    abstract class Animal
    {
        public string Name { get; set; }
        public Animal(string name)
        {
            Name = name;
        }
        public abstract void MakeSound();
        public override string ToString()
        {
            return "Животное: " + Name;
        }
    }
    class Dog : Animal
    {
        public Dog(string name) : base(name)
        {
        }
        public override void MakeSound()
        {
            Console.WriteLine(Name + " говорит: Гав-гав!");
        }
    }
    class Cat : Animal
    {
        public Cat(string name) : base(name)
        {
        }

        public override void MakeSound()
        {
            Console.WriteLine(Name + " говорит: Мяу!");
        }
    }
    class Bird : Animal
    {
        public Bird(string name) : base(name)
        {
        }

        public override void MakeSound()
        {
            Console.WriteLine(Name + " говорит: Чик-чирик!");
        }

        public void Fly()
        {
            Console.WriteLine(Name + " летит!");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>
            {
                new Dog("Бобик"),
                new Cat("Мурка"),
                new Bird("Кеша")
            };
            Console.WriteLine("Список животных:");
            foreach (Animal animal in animals)
            {
                Console.WriteLine(animal);
            }
            Console.WriteLine();
            Console.WriteLine("Звуки животных:");
            foreach (Animal animal in animals)
            {
                animal.MakeSound();
            }
            Console.WriteLine();
            Bird bird = new Bird("Кеша");
            bird.Fly();
            Console.ReadKey();
        }
    }
}
