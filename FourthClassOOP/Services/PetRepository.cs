using System;
using System.Collections.Generic;
using System.Linq;
using FourthClassOOP.Util;

namespace FourthClassOOP.Services
{
    public class PetRepository
    {
        public void GetAll(List<Animal> pets)
        {
            foreach (var pet in pets)
            {
                Console.WriteLine($"Kind: {pet.Kind}");
                Console.WriteLine($"Id: {pet.Id}");
                Console.WriteLine($"Height: {pet.Height}");
                Console.WriteLine($"Weight: {pet.Weight}");
                Console.WriteLine($"Color: {pet.Color}");
                pet.Park();
                
                Console.WriteLine("========");
            }
        }

        public Animal GetById(int id, List<Animal> pets)
        {
            var check = false;
            var output = new Animal();
            foreach (var pet in pets)
            {
                if (pet.Id == id)
                {
                    output.Height = pet.Height;
                    output.Weight = pet.Weight;
                    output.Color = pet.Color;
                    output.Kind = pet.Kind;
                    check = true;
                }
            }

            if (check == false)
            {

                    Console.WriteLine($"Pet with id: {id} is not found");
                    return null;
            }
            
            return output;
        }

        public void UpdateById(List<Animal> pets, int id, double height, double weight, string color)
        {
            var check = false;

            // var newAnimal = new Animal();
            //
            // newAnimal.Height = UserInput.GetDouble("Nhap height moi: ");
            // newAnimal.Weight = UserInput.GetDouble("Nhap weight moi: ");
            // newAnimal.Color = UserInput.GetString("Nhap color moi: ");
            
            foreach (var pet in pets)
            {
                if (pet.Id == id)
                {
                    // pet.Color = newAnimal.Color;
                    // pet.Weight = newAnimal.Weight;
                    // pet.Height = newAnimal.Height;
                    
                    pet.Color = color;
                    pet.Height = height;
                    pet.Weight = weight;
                    check = true;
                }
            }

            if (check == false)
            {

                Console.WriteLine($"Pet with id: {id} is not found");
            }
        }

        public void AddPet(List<Animal> pets)
        {
            var pet = new Animal();

            #region pet Id

            var idCheck = false;
            while (idCheck == false)
            {
                var petId = UserInput.GetInt("Nhap pet's id: ");
                if (Validation.CheckId(petId, pets))
                {
                    pet.Id = petId;
                    idCheck = true;
                }
                else
                {
                    Console.WriteLine("Pet Id already exists");
                    petId = UserInput.GetInt("Nhap pet's id: ");
                    if (Validation.CheckId(petId, pets))
                    {
                        pet.Id = petId;
                        idCheck = true;
                    }
                    else
                    {
                        Console.WriteLine("Pet Id already exists");
                    }
                }
            }

            #endregion

            #region pet Kind

            var kindCheck = false;
            while (kindCheck == false)
            {
                var petKind = UserInput.GetString("Nhap pet's kind: ");
                if (petKind.ToLower().Equals("dog") 
                    || petKind.ToLower().Equals("cat") 
                    || petKind.ToLower().Equals("pig") 
                    || petKind.ToLower().Equals("chicken"))
                {
                    pet.Kind = petKind;
                    kindCheck = true;
                }
                else
                {
                    Console.WriteLine("Pet's kind is not valid. Please try again.");
                    petKind = UserInput.GetString("Nhap pet's kind: ");
                    if (petKind.ToLower().Equals("dog") 
                        || petKind.ToLower().Equals("cat") 
                        || petKind.ToLower().Equals("pig") 
                        || petKind.ToLower().Equals("chicken"))
                    {
                        pet.Kind = petKind;
                        kindCheck = true;
                    }
                }
            }
            
            #endregion

            #region pet Height

            pet.Height = UserInput.GetDouble("Nhap pet's height: ");

            #endregion

            #region pet Weight

            pet.Weight = UserInput.GetDouble("Nhap pet's weight: ");

            #endregion

            #region pet Color

            pet.Color = UserInput.GetString("Nhap pet's color: ");

            #endregion

            pets.Add(pet);
        }

        public void Delete(List<Animal> pets, int id)
        {
            //pets.Remove(pet);

            var check = false;

            foreach (var pet in pets.ToList())
            {
                if (pet.Id == id)
                {
                    pets.Remove(pet);
                    Console.WriteLine($"Da xoa thanh cong pet co Id: {pet.Id}");
                    check = true;
                }
            }

            if (check == false)
            {

                Console.WriteLine($"Pet with id: {id} is not found");
            }
        }

        public void Update(Animal oldPet, Animal newPet)
        {
            oldPet.Color = newPet.Color;
            oldPet.Weight = newPet.Weight;
            oldPet.Height = newPet.Height;
        }
    }
}