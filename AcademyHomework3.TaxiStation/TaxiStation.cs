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

        public void LoadFromFile(string filePath)
        {
            using (var br = new BinaryReader(File.Open(filePath, FileMode.Open, FileAccess.Read)))
            {
                while (br.PeekChar() > -1)
                { 
                    int id= br.ReadInt32();
                    var consumption = br.ReadInt32();
                    var cost = br.ReadInt32();
                    var speed = br.ReadInt32();
                    _collection.Add(new Taxi(id, consumption, cost, speed));
                }
                Console.WriteLine("File was loaded");
            }

        }

        public void SaveToFile(string filePath)
        {
            using (var bw = new BinaryWriter(File.Open(filePath, FileMode.OpenOrCreate, FileAccess.Write)))
            {
                foreach (var item in _collection)
                {
                    bw.Write(item.Id);
                    bw.Write(item.Consumption);
                    bw.Write(item.Cost);
                    bw.Write(item.Speed);
                    //bw.Write(item.)
                }
                Console.WriteLine("File was saved");
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

