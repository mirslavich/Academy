using AcademyHomework3.TaxiStation.Factories;
namespace AcademyHomework3.TaxiStation
{
    public class TaxiStation
    {
        public Taxi _previewTaxi { get;private set; }
        private List<Taxi> _collection;

        public TaxiStation()
        {
           _collection = new List<Taxi>();
        }
        public void LoadFromFile()
        {
            var filePath = @"TaxiStation.txt";
            var taxiStringRepresentation= File.ReadAllText(filePath);
            _collection= new List<Taxi>();
            foreach (string item in taxiStringRepresentation)
            {
                var data = item.Split('-');
                var taxi = new Taxi(int.Parse(data[0]), int.Parse(data[1]), int.Parse(data[2]),int.Parse(data[3]));
                _collection.Add(taxi);
            }
            foreach (var item in _collection)
            {
                Console.WriteLine($"Id: {item.Id} - Consumption: {item.Consumption}- Cost: {item.Cost}- Speed: {item.Speed}");
            }
        }
        public List<Taxi> GetTaxiBySpeed(int speedMin, int speedMax)
        { 
            List<Taxi> result = new List<Taxi>();
            foreach (var item in _collection)
            {
                if (item.Speed >= speedMin && item.Speed <= speedMax)
                { 
                    result.Add(item);   
                }
            }
            return result;
        }

        public void SortList()
        {
            _collection.Sort();
        }

        public void GenerateTaxi()
        {
           
           ITaxiFactory ranFactory = TaxiRandomFactory.GetRandomTaxiFactory();
           _previewTaxi = ranFactory.GenerateTaxi();
        }

        public List<Taxi> GetTaxiList()
        {
            return _collection;
        }

        public void SavePreviewTaxi()
        {
            _collection.Add(_previewTaxi);
        }

        public string CalculateCostCarPark()
        {
            double result = 0;
            foreach (var item in _collection)
            {
                result += item.Cost;
            }
            
            return "Full cost is: " + result;
        }



    }
        
    

}

