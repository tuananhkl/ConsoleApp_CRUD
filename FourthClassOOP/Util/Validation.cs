using System;
using System.Collections.Generic;

namespace FourthClassOOP.Util
{
    public static class Validation
    {
        public static bool CheckId(int id, List<Animal> pets)
        {
            var check = true;
            foreach (var pet in pets)
            {
                if (pet.Id == id)
                {
                    check = false;
                }
            }
            
            return check;
        }
    }
}