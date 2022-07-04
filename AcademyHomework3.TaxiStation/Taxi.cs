namespace AcademyHomework3.TaxiStation
{
    public class Taxi: IComparable<Taxi>
    {
        public int Id { get; set; } 
        public int Consumption { get; set; } 
        public int Cost { get; set; } 
        public int Speed { get; set; } 

        public Taxi(int id, int consumption, int cost, int speed)
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
