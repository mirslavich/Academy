using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyHomework5.BillingSystem
{
    public class FileHandler
    {
        public async Task WriteHistoriesCallsToFileAsync(string path, List<Call> callsList)
        {
            var orderedSentences = callsList
                .OrderBy(c => c.StartDateTime)
                .ToList();

            using (var sw = new StreamWriter(File.OpenWrite(path)))
            {
                foreach (var call in callsList)
                {
                    var sb = new StringBuilder();
                    sb.Append(call.FromClient.Agreement + " " + call.FromClient.Tariff.TariffPlans + " " + call.ToPhoneNumber + " " + call.StartDateTime + " " + call.EndDateTime + " " + call.CallDuration);
                    await sw.WriteLineAsync(sb.ToString());
                }
            }
        }
    }
}
