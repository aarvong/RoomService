namespace RoomService
{
    public class FADConfirmData
    {
        public readonly double steakQty;
        public readonly double wineQty;
        public readonly double total;
        const double steakPrice = 100;
        const double winePrice = 150;

        public FADConfirmData(double steak, double wine)
        {
            steakQty = steak;
            wineQty = wine;
            total = steakQty * steakPrice + wineQty * winePrice;
        }
    }
}
