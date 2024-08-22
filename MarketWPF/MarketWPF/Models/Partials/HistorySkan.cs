using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketWPF.Models
{
    public partial class HistorySkan
    {
        
        public SeriesCollection SeriesCollection
        {
            get
            {
                ChartValues<int> values = new ChartValues<int>();
                var listDate = App.DB.HistorySkan.ToList();

                var minValue = listDate.Min(x => x.DateTime.Date);
                var maxValue = listDate.Max(x => x.DateTime.Date);

                var difference = (maxValue.Date - minValue.Date).TotalDays;

                for (int i = 0; i <= difference; i++)
                {
                    if (listDate.FirstOrDefault(x => x.DateTime.Date == minValue.AddDays(i) && x.ProductId ==ProductId) != null)
                    {
                        var thisDateList = listDate.Where(x => x.DateTime.Date == minValue.AddDays(i) && x.ProductId == ProductId).ToList();
                        values.Add(thisDateList.Count);
                    }
                    else
                    {
                        values.Add(0);
                    }
                }


               

                return new SeriesCollection{
                    new LineSeries
                    {
                        Title = Product.Name,
                        Values = values
                    }
                };

            }
        }
    }
}
