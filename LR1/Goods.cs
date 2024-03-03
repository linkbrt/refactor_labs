﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace RLCExamples01
{
    // Класс, который представляет данные о товаре
    public class Goods
    {
        public const int REGULAR = 0;
        public const int SALE = 1;
        public const int SPECIAL_OFFER = 2;
        private string _title;
        private int _priceCode;
        public Goods(string title, int priceCode)
        {
            _title = title;
            _priceCode = priceCode;
        }
        public int getPriceCode()
        {
            return _priceCode;
        }
        public void setPriceCode(int arg)
        {
            _priceCode = arg;
        }
        public string getTitle()
        {
            return _title;
        }
    }
}
