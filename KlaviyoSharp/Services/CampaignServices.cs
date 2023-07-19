using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using KlaviyoSharp.Infrastructure;
using KlaviyoSharp.Models;
using KlaviyoSharp.Models.Filters;

namespace KlaviyoSharp.Services;

public class CampaignServices : KlaviyoServiceBase, ICampaignServices
{
    public CampaignServices(KlaviyoApiBase klaviyoService) : base("2023-06-15", klaviyoService) { }

    public async Task<DataListObjectWithIncluded<Campaign>> GetCampaigns(List<string> campaignFields = null, List<string> tagFields = null, IFilter filter = null, List<string> includedRecords = null, string sort = null, CancellationToken cancellationToken = default)
    {
        QueryParams query = new();
        query.AddFieldset("campaign", campaignFields);
        query.AddFieldset("tag", tagFields);
        query.AddFilter(filter);
        query.AddIncludes(includedRecords);
        query.AddSort(sort);
        return await _klaviyoService.HTTP<DataListObjectWithIncluded<Campaign>>(HttpMethod.Get, "campaigns/", _revision, query, null, null, cancellationToken);
    }
}

internal interface ICampaignServices
{

}