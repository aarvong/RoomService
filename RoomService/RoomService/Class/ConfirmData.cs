using System;

namespace RoomService
{
    public class ConfirmData
    {
        public readonly string shopName;
        public readonly DateTime chosenDate;
        public readonly TimeSpan chosenTime;
        public readonly double finalNumOfPpl;

        public ConfirmData(string name, DateTime dt, double d)
        {
            shopName = name;
            chosenDate = dt;
            chosenTime = new TimeSpan(dt.Hour, 0, 0);
            finalNumOfPpl = d;
        }
    }
}
