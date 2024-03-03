using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;


namespace RLCExamples01.Tests
{
    [TestFixture]
    public class BillTests
    {
        static Goods cola;
        static Goods pepsi;
        static Item item1, item2, item3, item4;
        [SetUp] 
        public void SetUp() 
        {
            cola = new RegularGoods("Cola");
            pepsi = new SaleGoods("Pepsi");
            item1 = new Item(cola, 6, 65);
            item2 = new Item(cola, 1, 200);
            item3 = new Item(pepsi, 10, 30);
            item4 = new Item(pepsi, 15, 100);
        }
        [Test]
        public void statementTest1()
        {
            Bill b1 = new Bill(new Customer("test", 10));
            b1.addGoods(item1);
            string bill = b1.statement();
            Assert.AreEqual(19, b1.totalBonus);
            Assert.AreEqual(363,3, b1.totalAmount);
        }
        [Test]
        public void statementTest2()
        {
            Bill b1 = new Bill(new Customer("test", 20));
            b1.addGoods(item2);
            string bill = b1.statement();
            Assert.AreEqual(10, b1.totalBonus);
            Assert.AreEqual(3, 3, b1.totalAmount);
        }
        [Test]
        public void statementTest3()
        {
            Bill b1 = new Bill(new Customer("test", 30));
            b1.addGoods(item3);
            string bill = b1.statement();
            Assert.AreEqual(3, b1.totalBonus);
            Assert.AreEqual(270, 3, b1.totalAmount);
        }
        [Test]
        public void statementTest4()
        {
            Bill b1 = new Bill(new Customer("test", 5));
            b1.addGoods(item4);
            string bill = b1.statement();
            Assert.AreEqual(15, b1.totalBonus);
            Assert.AreEqual(863, 3, b1.totalAmount);
        }
        [Test]
        public void statementTest5()
        {
            Bill b1 = new Bill(new Customer("test", 15));
            b1.addGoods(item4);
            b1.addGoods(item1);
            string bill = b1.statement();
            Assert.AreEqual(34, b1.totalBonus);
            Assert.AreEqual(863, 3, b1.totalAmount);
        }
        [Test]
        public void statementTest6()
        {
            Bill b1 = new Bill(new Customer("test", 100));
            b1.addGoods(item1);
            b1.addGoods(item2);
            string bill = b1.statement();
            Assert.AreEqual(29, b1.totalBonus);
            Assert.AreEqual(478.3, 3, b1.totalAmount);
        }
        [Test]
        public void statementTest7()
        {
            Bill b1 = new Bill(new Customer("test", 1000));
            b1.addGoods(item1);
            b1.addGoods(item3);
            string bill = b1.statement();
            Assert.AreEqual(22, b1.totalBonus);
            Assert.AreEqual(79, 3, b1.totalAmount);
        }
        [Test]
        public void statementTest8()
        {
            Bill b1 = new Bill(new Customer("test", 40));
            b1.addGoods(item1);
            b1.addGoods(item4);
            b1.addGoods(item2);
            string bill = b1.statement();
            Assert.AreEqual(44, b1.totalBonus);
            Assert.AreEqual(863, 3, b1.totalAmount);
        }
        [Test]
        public void statementTest9()
        {
            Bill b1 = new Bill(new Customer("test", 60));
            b1.addGoods(item1);
            b1.addGoods(item3);
            b1.addGoods(item2);
            string bill = b1.statement();
            Assert.AreEqual(32, b1.totalBonus);
            Assert.AreEqual(815.3, 3, b1.totalAmount);
        }
        [Test]
        public void statementTest10()
        {
            Bill b1 = new Bill(new Customer("test", 77));
            b1.addGoods(item1);
            b1.addGoods(item2);
            b1.addGoods(item4);
            string bill = b1.statement();
            Assert.AreEqual(44, b1.totalBonus);
            Assert.AreEqual(863, 3, b1.totalAmount);
        }
        [Test]
        public void statementTest11()
        {
            Bill b1 = new Bill(new Customer("test", 85));
            b1.addGoods(item1);
            b1.addGoods(item2);
            b1.addGoods(item3);
            b1.addGoods(item4);
            string bill = b1.statement();
            Assert.AreEqual(47, b1.totalBonus);
            Assert.AreEqual(863, 3, b1.totalAmount);
        }
    }
}