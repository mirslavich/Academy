using System.Collections;
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
        public void LoadFromFile(string path)
        {

        }
        public List<Taxi> GetTaxiBySpeed(double speedMin, double speedMax)
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
           // ITaxiFactory factory = new TaxiUsualFactory(15, 48, 175,100,false,true);
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



    }
        
    

}

