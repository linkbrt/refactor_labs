using NUnit.Framework;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using LR1;


namespace RLCExamples01.Tests
{
    [TestFixture]
    public class BillTests
    {
        static Goods cola;
        static Goods pepsi;
        static Item item1, item2, item3, item4;
        static IView view;
        [SetUp] 
        public void SetUp() 
        {
            cola = GoodsFactory.Create("REG", "Cola");
            pepsi = GoodsFactory.Create("SAL", "Pepsi");
            item1 = new Item(cola, 6, 65);
            item2 = new Item(cola, 1, 200);
            item3 = new Item(pepsi, 10, 30);
            item4 = new Item(pepsi, 15, 100);
            view = new TxtView();
        }
        [Test]
        public void statementTest1()
        {
            Bill b1 = new Bill(new Customer("test", 10), view);
            b1.addGoods(item1);
            BillGenerator billGenerator = new(new Customer("test", 10), view, b1);
            billGenerator.statement();
            Assert.AreEqual(19, billGenerator.totalBonus);
            Assert.AreEqual(363,3, billGenerator.totalAmount);
        }
        [Test]
        public void statementTest2()
        {
            Bill b1 = new Bill(new Customer("test", 20), view);
            b1.addGoods(item2);
            BillGenerator billGenerator = new(new Customer("test", 10), view, b1);
            billGenerator.statement();
            Assert.AreEqual(10, billGenerator.totalBonus);
            Assert.AreEqual(3, 3, billGenerator.totalAmount);
        }
        [Test]
        public void statementTest3()
        {
            Bill b1 = new Bill(new Customer("test", 30), view);
            b1.addGoods(item3);
            BillGenerator billGenerator = new(new Customer("test", 10), view, b1);
            billGenerator.statement();
            Assert.AreEqual(3, billGenerator.totalBonus);
            Assert.AreEqual(270, 3, billGenerator.totalAmount);
        }
        [Test]
        public void statementTest4()
        {
            Bill b1 = new Bill(new Customer("test", 5), view);
            b1.addGoods(item4);
            BillGenerator billGenerator = new(new Customer("test", 10), view, b1);
            billGenerator.statement();
            Assert.AreEqual(15, billGenerator.totalBonus);
            Assert.AreEqual(863, 3, billGenerator.totalAmount);
        }
        [Test]
        public void statementTest5()
        {
            Bill b1 = new Bill(new Customer("test", 15), view);
            b1.addGoods(item4);
            b1.addGoods(item1);
            BillGenerator billGenerator = new(new Customer("test", 10), view, b1);
            billGenerator.statement();
            Assert.AreEqual(34, billGenerator.totalBonus);
            Assert.AreEqual(863, 3, billGenerator.totalAmount);
        }
        [Test]
        public void statementTest6()
        {
            Bill b1 = new Bill(new Customer("test", 100), view);
            b1.addGoods(item1);
            b1.addGoods(item2);
            BillGenerator billGenerator = new(new Customer("test", 10), view, b1);
            billGenerator.statement();
            Assert.AreEqual(29, billGenerator.totalBonus);
            Assert.AreEqual(478.3, 3, billGenerator.totalAmount);
        }
        [Test]
        public void statementTest7()
        {
            Bill b1 = new Bill(new Customer("test", 1000), view);
            b1.addGoods(item1);
            b1.addGoods(item3);
            BillGenerator billGenerator = new(new Customer("test", 10), view, b1);
            billGenerator.statement();
            Assert.AreEqual(22, billGenerator.totalBonus);
            Assert.AreEqual(79, 3, billGenerator.totalAmount);
        }
        [Test]
        public void statementTest8()
        {
            Bill b1 = new Bill(new Customer("test", 40), view);
            b1.addGoods(item1);
            b1.addGoods(item4);
            b1.addGoods(item2);
            BillGenerator billGenerator = new(new Customer("test", 10), view, b1);
            billGenerator.statement();
            Assert.AreEqual(44, billGenerator.totalBonus);
            Assert.AreEqual(863, 3, billGenerator.totalAmount);
        }
        [Test]
        public void statementTest9()
        {
            Bill b1 = new Bill(new Customer("test", 60), view);
            b1.addGoods(item1);
            b1.addGoods(item3);
            b1.addGoods(item2);
            BillGenerator billGenerator = new(new Customer("test", 10), view, b1);
            billGenerator.statement();
            Assert.AreEqual(32, billGenerator.totalBonus);
            Assert.AreEqual(815.3, 3, billGenerator.totalAmount);
        }
        [Test]
        public void statementTest10()
        {
            Bill b1 = new Bill(new Customer("test", 77), view);
            b1.addGoods(item1);
            b1.addGoods(item2);
            b1.addGoods(item4);
            BillGenerator billGenerator = new(new Customer("test", 10), view, b1);
            billGenerator.statement();
            Assert.AreEqual(44, billGenerator.totalBonus);
            Assert.AreEqual(863, 3, billGenerator.totalAmount);
        }
        [Test]
        public void statementTest11()
        {
            Bill b1 = new Bill(new Customer("test", 85), view);
            b1.addGoods(item1);
            b1.addGoods(item2);
            b1.addGoods(item3);
            b1.addGoods(item4);
            BillGenerator billGenerator = new(new Customer("test", 10), view, b1);
            billGenerator.statement();
            Assert.AreEqual(47, billGenerator.totalBonus);
            Assert.AreEqual(863, 3, billGenerator.totalAmount);
        }

        // Тесты метода CreateBill
        [Test]
        public void createBillTest() {
            StringReader reader = new StringReader("CustomerName: Test\r\nCustomerBonus: 10\r\nGoodsTotalCount: 3\r\n# ID: NAME TYPE(REG/SAL/SPO)\r\n1: Cola REG\r\n2: Pepsi SAL\r\n3: Fanta SPO\r\nItemsTotalCount: 3\r\n# ID: GID PRICE QTY\r\n1: 1 65 6\r\n2: 2 50 3\r\n3: 3 35 1");
;
            string expected = "Счет для Test\n\tНазвание\tЦена\tКол-воСтоимость\tСкидка\tСумма\tБонус\n\tCola\t\t65\t6\t390\t11,7\t368,3\t19\n\tPepsi\t\t50\t3\t150\t0\t150\t1\n\tFanta\t\t35\t1\t35\t0\t35\t0\nСумма счета составляет 553,3\nВы заработали 20 бонусных баллов";
            BillFactory billFactory = new BillFactory(FileSourceFactory.Create(" .yaml"));
            string bill = billFactory.CreateBill(reader);
            Assert.AreEqual(expected, bill);
        }
        
        [Test]
        public void createBillTest1() {
            StringReader reader = new StringReader("CustomerName: Test\r\nCustomerBonus: 20\r\nGoodsTotalCount: 3\r\n# ID: NAME TYPE(REG/SAL/SPO)\r\n1: Cola REG\r\n2: Pepsi SAL\r\n3: Fanta SPO\r\nItemsTotalCount: 3\r\n# ID: GID PRICE QTY\r\n1: 1 65 6\r\n2: 2 50 10\r\n3: 3 35 1");
            string expected = "Счет для Test\n\tНазвание\tЦена\tКол-воСтоимость\tСкидка\tСумма\tБонус\n\tCola\t\t65\t6\t390\t11,7\t358,3\t19\n\tPepsi\t\t50\t10\t500\t5\t495\t5\n\tFanta\t\t35\t1\t35\t0\t35\t0\nСумма счета составляет 888,3\nВы заработали 24 бонусных баллов";
            BillFactory billFactory = new BillFactory(FileSourceFactory.Create(" .yaml"));
            string bill = billFactory.CreateBill(reader); ;
            Assert.AreEqual(expected, bill);
        }
        // Тесты для расширения csv
        [Test]
        public void createBillTest2()
        {
            StringReader reader = new StringReader("CustomerName,Test\r\nCustomerBonus,10\r\nGoodsTotalCount,3\r\n# ID,NAME,TYPE(REG/SAL/SPO)\r\n1,Cola,REG\r\n2,Pepsi,SAL\r\n3,Fanta,SPO\r\nItemsTotalCount,3\r\n# ID,GID,PRICE,QTY\r\n1,1,65,6\r\n2,2,50,3\r\n3,3,35,1");
            string expected = "Счет для Test\n\tНазвание\tЦена\tКол-воСтоимость\tСкидка\tСумма\tБонус\n\tCola\t\t65\t6\t390\t11,7\t368,3\t19\n\tPepsi\t\t50\t3\t150\t0\t150\t1\n\tFanta\t\t35\t1\t35\t0\t35\t0\nСумма счета составляет 553,3\nВы заработали 20 бонусных баллов";
            BillFactory billFactory = new BillFactory(FileSourceFactory.Create(" .csv"));
            string bill = billFactory.CreateBill(reader); ;
            Assert.AreEqual(expected, bill);
        }
        [Test]
        public void createBillTest3()
        {
            StringReader reader = new StringReader("CustomerName,Test\r\nCustomerBonus,10\r\nGoodsTotalCount,3\r\n# ID,NAME,TYPE(REG/SAL/SPO)\r\n1,Cola,REG\r\n2,Pepsi,SAL\r\n3,Fanta,SPO\r\nItemsTotalCount,3\r\n# ID,GID,PRICE,QTY\r\n1,1,65,6\r\n2,2,50,3\r\n3,3,35,5");
            string expected = "Счет для Test\n\tНазвание\tЦена\tКол-воСтоимость\tСкидка\tСумма\tБонус\n\tCola\t\t65\t6\t390\t11,7\t368,3\t19\n\tPepsi\t\t50\t3\t150\t0\t150\t1\n\tFanta\t\t35\t5\t175\t0\t175\t0\nСумма счета составляет 693,3\nВы заработали 20 бонусных баллов";
            BillFactory billFactory = new BillFactory(FileSourceFactory.Create(" .csv"));
            string bill = billFactory.CreateBill(reader); ;
            Assert.AreEqual(expected, bill);
        }
    }
}