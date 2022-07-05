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
            using (StreamReader br = new StreamReader(filePath))
            {
                string line;
                string[] arguments;
                while ((line = br.ReadLine()) != null)
                {
                    arguments = line.Split(" ");
                    if (arguments[0] == "TaxiUsual")
                    {
                        TaxiUsualFactory factory = new TaxiUsualFactory(ArrayReduction(arguments));
                        _collection.Add(factory.GenerateTaxi());
                    }
                    else if (arguments[0] == "TaxiBus")
                    {
                        TaxiBusFactory factory = new TaxiBusFactory(ArrayReduction(arguments));
                        _collection.Add(factory.GenerateTaxi());
                    }
                    else if (arguments[0] == "TaxiDelivery")
                    {
                        TaxiDeliveryFactory factory = new TaxiDeliveryFactory(ArrayReduction(arguments));
                        _collection.Add(factory.GenerateTaxi());
                    }
                    else if (arguments[0] == "TaxiHelicopter")
                    {
                        TaxiHelicopterFactory factory = new TaxiHelicopterFactory(ArrayReduction(arguments));
                        _collection.Add(factory.GenerateTaxi());
                    }
                }
                Console.WriteLine("File was loaded");
            }
        }

        private string[] ArrayReduction(string[] arg)
        {
            string[] result=new string[arg.Length-1];
            Array.Copy(arg,1, result,0, arg.Length - 1);
            return result;
        }

        public void SaveToFile(string filePath)
        {
            using (StreamWriter bw = new StreamWriter(filePath, true, System.Text.Encoding.UTF8))
            {
                foreach (var item in _collection)
                {
                    bw.WriteLine(item.GetSaveData());
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

