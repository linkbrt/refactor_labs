namespace RLCExamples01 {
    public interface IView {
        string getHeader(string name);
        string getFooter(double totalAmount, int totalBonus);
        string getItemString(ItemSummary item);
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
        public string getItemString(ItemSummary item) {
            return "\t" + item.name + "\t" +
                   "\t" + item.price + "\t" + item.qty +
                   "\t" + item.sum.ToString() +
                   "\t" + item.discount.ToString() + "\t" + item.amount.ToString() +
                   "\t" + item.bonus.ToString() + "\n";
        }
    }
    public class HtmlView : IView {
        public string getHeader(string name) {
            return "";
        }
        public string getFooter(double totalAmount, int totalBonus) {
            return "";
        }
        public string getItemString(ItemSummary item) {
            return "";
        }
    }
}
