﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace RLCExamples01
{
    // Класс, представляющий клиента магазина.
    public class Customer
    {
        private int bonus;
        private string name;
        public Customer(string name, int bonus)
        {
            this.name = name;
            this.bonus = bonus;
        }
        public string getName()
        {
            return name;
        }
        public int getBonus()
        {
            return bonus;
        }
        public void receiveBonus(int bonus)
        {
            this.bonus = bonus;
        }
        public int useBonus(int needBonus)
        {
            int bonusTaken;
            if (needBonus > bonus)
            {
                bonusTaken = bonus;
                bonus = 0;
            }
            else
            {
                bonusTaken = needBonus;
                bonus = bonus - needBonus;
            }
            return bonusTaken;
        }
        public int getUsedBonus(double needBonus) {
            return useBonus((int)needBonus);
        }
    }
}
