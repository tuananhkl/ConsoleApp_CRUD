using System;
using System.Collections.Generic;
using System.Text;
using FourthClassOOP.Services;
using FourthClassOOP.Util;

namespace FourthClassOOP
{
    // - Viết chương trình console-app quản lý thú cưng
    //     - Có chức năng thêm/sửa/xóa/xem danh sách thú cưng
    //     - Các loại thú có thể thêm bao gồm: chó, mèo, lợn, gà
    //     - Các thuộc tính cơ bản:
    // + Chiều cao
    //     + Cân nặng
    //     + Màu sắc
    //     - Áp dụng tính chất của OOP 
    //     + Các loại thú kế thừa từ "động vật"
    //     + Mỗi loại thú có hàm thể hiện "tiếng kêu" riêng, có thể áp dụng interface

    class Program
    {
        private static List<Animal> pets = new List<Animal>
        {
            new Cat
            {
                Id = 1,
                Height = 50,
                Weight = 5,
                Color = "Yellow"
            },
            new Dog
            {
                Id = 2,
                Height = 70,
                Weight = 20,
                Color = "Black"
            },
            new Chicken
            {
                Id = 3,
                Height = 61,
                Weight = 3,
                Color = "White"
            },
            new Pig
            {
                Id = 4,
                Height = 65,
                Color = "Pink",
                Weight = 40
            }
        };
        private static readonly PetRepository petRepository = new PetRepository();
        
        static void Main(string[] args)
        {
            //menu
            Console.OutputEncoding = Encoding.UTF8;

            while (true)
            {
                Console.WriteLine("===MENU===");
                Console.WriteLine("1. Show list of Pets");
                Console.WriteLine("2. Add a pet");
                Console.WriteLine("3. Update a pet's information");
                Console.WriteLine("4. Delete a pet (warning)");
                Console.WriteLine("5. Exit");
                var choice = UserInput.GetInt("Enter your choice here: ");

                switch (choice)
                {
                    case 1:
                        ShowAllPets(pets);
                        break;
                    case 2:
                        AddPet();
                        break;
                    case 3:
                        UpdatePet();
                        break;
                    case 4:
                        Delete();
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("You have to enter 1 of these options: 1, 2, 3, 4, 5");
                        break;
                }   
            }
        }

        private static void ShowAllPets(List<Animal> pets)
        {
            petRepository.GetAll(pets);
        }

        private static void AddPet()
        {
            petRepository.Add(pets);
        }

        private static void UpdatePet()
        {
            //Update
            var id = UserInput.GetInt("Nhap pet's id can update: ");
            
            var height = UserInput.GetDouble("Nhap height moi (cm): ");
            var weight = UserInput.GetDouble("Nhap weight moi (kg): ");
            var color = UserInput.GetString("Nhap color moi: ");
            
            petRepository.UpdateById(pets, id, height, weight, color);
        }

        private static void Delete()
        {
            var id = UserInput.GetInt("Nhap pet's id can delete: ");
            petRepository.Delete(pets, id);
        }

        #region Old CRUD repo

        // private static void ShowAllPets(List<Animal> pets)
        // {
        //     foreach (var pet in pets)
        //     {
        //         Console.WriteLine($"Kind: {pet.Kind}");
        //         Console.WriteLine($"Height: {pet.Height}");
        //         Console.WriteLine($"Weight: {pet.Weight}");
        //         Console.WriteLine($"Color: {pet.Color}");
        //         pet.Park();
        //         
        //         Console.WriteLine("========");
        //     }
        // }
        //
        // private static Animal GetById(int id, List<Animal> pets)
        // {
        //     var output = new Animal();
        //     foreach (var pet in pets)
        //     {
        //         if (pet.Id == id)
        //         {
        //             output.Height = pet.Height;
        //             output.Weight = pet.Weight;
        //             output.Color = pet.Color;
        //             output.Kind = pet.Kind;
        //         }
        //     }
        //     
        //     return output;
        // }
        //
        // private static void AddPet(List<Animal> pets, Animal pet)
        // {
        //     pets.Add(pet);
        // }
        //
        // private static void RemovePet(List<Animal> pets, Animal pet)
        // {
        //     pets.Remove(pet);
        // }
        //
        // private static void UpdatePet(Animal oldPet, Animal newPet)
        // {
        //     oldPet.Color = newPet.Color;
        //     oldPet.Weight = newPet.Weight;
        //     oldPet.Height = newPet.Height;
        // }

        #endregion
    }
}