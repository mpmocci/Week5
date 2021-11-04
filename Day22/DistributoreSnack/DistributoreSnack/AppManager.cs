using System;
using System.Collections.Generic;
using System.Text;

namespace DistributoreSnack
{
    public static class AppManager
    {

        public static Dictionary<int, Snack> SnacksList = new Dictionary<int, Snack>();


        public static void AddSnacksToAList(Dictionary<int, Snack> SnacksList)
        {
            Snack snack1 = new Snack { Id = 1, Name = "Mars", Price = 2.99 };
            Snack snack2 = new Snack { Id = 2, Name = "Twix", Price = 1.99 };
            Snack snack3 = new Snack { Id = 3, Name = "Duplo", Price = 2.89 };
            Snack snack4 = new Snack { Id = 4, Name = "Crackers", Price = 1.54 };
            Snack snack5 = new Snack { Id = 5, Name = "Bounty", Price = 2.54 };
            Snack snack6 = new Snack { Id = 6, Name = "Fiesta", Price = 3.54 };

            SnacksList.Add(1, snack1);
            SnacksList.Add(2, snack2);
            SnacksList.Add(3, snack3);
            SnacksList.Add(4, snack4);
            SnacksList.Add(5, snack5);
            SnacksList.Add(6, snack6);

        }


        public static void AddSnacks()
        {
            AddSnacksToAList(SnacksList);
        }

        public static Snack GetByKey(int value)
        {

            foreach (var item in SnacksList)
            {

                if (item.Key == value)
                {
                    return item.Value;
                }

            }

            return null;


        }

    }
}
