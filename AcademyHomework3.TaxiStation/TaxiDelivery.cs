namespace AcademyHomework3.TaxiStation
{
    public class TaxiDelivery:Taxi
    {
        private int _usefulWeight { get; set; }

        public TaxiDelivery(int id, int consumption, int cost, int speed,int usefulWeight) : base (id,consumption,cost,speed)
        {
            _usefulWeight = usefulWeight;
        }

        public override string PrintInfo()
        {
            return "Taxi delivery: " + base.PrintInfo() + " Useful weight: " + _usefulWeight;
        }

        public override string GetSaveData()
        {
            return "TaxiDelivery " + base.GetSaveData() + " " + _usefulWeight;
        }
    }
}
