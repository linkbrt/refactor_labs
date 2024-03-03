namespace RLCExamples01 {
    public interface IView {
        string getHeader(string name);
        string getFooter(double totalAmount, int totalBonus);
        string getItemString(Item item, double discount,
                             double thisAmount, int bonus);
    }
    public class TxtView : IView {
        public string getHeader(string name) {
            return "Счет для " + name + "\n" +
                   "\t" + "Название" + "\t" + "Цена" +
                   "\t" + "Кол-во" + "Стоимость" + "\t" + "Скидка" +
                   "\t" + "Сумма" + "\t" + "Бонус" + "\n";
        }
        public string getFooter(double totalAmount, int totalBonus) {
            return "Сумма счета составляет " + totalAmount.ToString() + "\n" +
                    "Вы заработали " + totalBonus.ToString() +
                    " бонусных баллов";
        }
        public string getItemString(Item item, double discount,
                             double thisAmount, int bonus) {
            return "\t" + item.getGoods().getTitle() + "\t" +
                   "\t" + item.getPrice() + "\t" + item.getQuantity() +
                   "\t" + (item.getQuantity() * item.getPrice()).ToString() +
                   "\t" + discount.ToString() + "\t" + thisAmount.ToString() +
                   "\t" + bonus.ToString() + "\n";
        }
    }
    public class HtmlView : IView {
        public string getHeader(string name) {
            return "";
        }
        public string getFooter(double totalAmount, int totalBonus) {
            return "";
        }
        public string getItemString(Item item, double discount,
                             double thisAmount, int bonus) {
            return "";
        }
    }
}
