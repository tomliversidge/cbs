using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Read.InvalidCaseReports
{
    public interface IInvalidCaseReportsFromUnknownDataCollectors
    {
        Task Save(InvalidCaseReportFromUnknownDataCollector caseReport);
        Task<IEnumerable<InvalidCaseReportFromUnknownDataCollector>> GetAllAsync();
        Task<IEnumerable<InvalidCaseReportFromUnknownDataCollector>> GetByPhoneNumber(string phoneNumber);
        Task Remove(Guid id);
    }
}
