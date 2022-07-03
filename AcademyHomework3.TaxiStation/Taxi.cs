namespace AcademyHomework3.TaxiStation
{
    public class Taxi: IComparable<Taxi>
    {
        
        public int Id { get; set; } 
        public double Consumption { get; set; } 
        public double Cost { get; set; } 
        public double Speed { get; set; } 

        public Taxi(int id, double consumption, double cost, double speed)
        {
            Id = id;
            Consumption = consumption;
            Cost = cost;
            Speed = speed;
        }
        public virtual string PrintInfo()
        {        
            return "Id: " +Id + " Consumption: " + Consumption + " Cost: " + Cost + " Speed: " + Speed;
        }
        public int CompareTo(Taxi? other)
        {
            if (this.Consumption > other.Consumption)
            {
                return 1;
            }
            else if (this.Consumption < other.Consumption)
            { 
                return -1;
            }
            return 0;
        }
    }
}
