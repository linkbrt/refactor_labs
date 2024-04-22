using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RLCExamples01
{
    public interface IDiscountStrategy
    {
        public (double, double) Algorithm(Customer customer, int qty, double price);
    }
    class NewYearRegularDiscountStrategy: IDiscountStrategy
    {
        public (double, double) Algorithm(Customer customer, int qty, double price)
        {
            double sum = qty * price;
            if (sum > 5000)
            {
                double discount = sum * 0.07;
                double usedBonus = customer.getUsedBonus((qty * price) - discount);
                return (discount, usedBonus);
            } else
            {
                return new RegularDiscountStrategy().Algorithm(customer, qty, price);
            }
        }
    }
    class RegularDiscountStrategy : IDiscountStrategy
    {
        public (double, double) Algorithm(Customer customer, int qty, double price)
        {
            double discount = 0;
            double usedBonus = 0;
            if (qty > 2)
            {
                discount = qty * price * 0.03;
            }
            if (qty > 5)
            {
                usedBonus = customer.getUsedBonus((qty * price) - discount);
            }
            return (discount, usedBonus);
        }
    }
    class SaleDiscountStrategy : IDiscountStrategy
    {
        public (double, double) Algorithm(Customer customer, int qty, double price)
        {
            double discount = 0;
            double usedBonus = 0;
            if (qty > 3)
            {
                discount = qty * price * 0.01;
            }
            return (discount, usedBonus);
        }
    }
    class SpecialDiscountStrategy : IDiscountStrategy
    {
        public (double, double) Algorithm(Customer customer, int qty, double price)
        {
            double discount = 0;
            double usedBonus = 0;
            if (qty > 10)
            {
                discount = qty * price * 0.005;
            }
            if (qty > 1)
            {
                usedBonus = customer.getUsedBonus((qty * price) - discount);
            }
            return (discount, usedBonus);
        }
    }
    class DiscountContext
    {
        private IDiscountStrategy _strategy { get; set; }
        public DiscountContext(IDiscountStrategy strategy)
        {
            _strategy = strategy;
        }
        public (double, double) ExecuteOperation(Customer customer, int qty, double price)
        {
            return _strategy.Algorithm(customer, qty, price);
        }
    }
}
