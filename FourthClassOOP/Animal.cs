using System;

namespace FourthClassOOP
{
    public interface IAnimal
    {
        void Park();
    }
    
    
    public class Animal : IAnimal
    {
        public int Id { get; set; }
        public virtual string Kind { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public string Color { get; set; }
        public virtual void Park()
        {
            
        }
    }

    public class Dog : Animal
    {
        public override string Kind { get; set; } = "Dog";
        public override void Park()
        {
            Console.WriteLine("Gau gau");
        }
    }
    
    public class Cat : Animal
    {
        public override string Kind { get; set; } = "Cat";
        public override void Park()
        {
            Console.WriteLine("Meo meo");
        }
    }
    
    public class Pig : Animal
    {
        public override string Kind { get; set; } = "Pig";
        public override void Park()
        {
            Console.WriteLine("Un in");
        }
    }

    public class Chicken : Animal
    {
        public override string Kind { get; set; } = "Chicken";
        public override void Park()
        {
            Console.WriteLine("Quac quac");
        }
    }
}