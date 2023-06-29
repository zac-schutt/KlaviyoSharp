using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using KlaviyoSharp.Infrastructure;
using KlaviyoSharp.Models;

namespace KlaviyoSharp.Services;

public class AccountServices : KlaviyoServiceBase, IAccountServices
{
    public AccountServices(KlaviyoApiBase klaviyoService) : base("2023-06-15", klaviyoService) { }
    /// <inheritdoc />
    public async Task<List<KlaviyoObject<Account>>> GetAccounts(List<string> accountFields = null, CancellationToken cancellationToken = default)
    {
        Dictionary<string, string> query = null;
        if (accountFields != null)
        {
            query ??= new Dictionary<string, string>();
            query.Add("fields[account]", string.Join(",", accountFields));
        }
        var resp = await _klaviyoService.HTTP<ResponseBody<List<KlaviyoObject<Account>>>>(HttpMethod.Get, "accounts/", _revision, query, null, null, cancellationToken);
        return resp.Data;
    }
    ///<inheritdoc />
    public async Task<KlaviyoObject<Account>> GetAccount(string accountId, List<string> accountFields = null, CancellationToken cancellationToken = default)
    {
        Dictionary<string, string> query = null;
        if (accountFields != null)
        {
            query ??= new Dictionary<string, string>();
            query.Add("fields[account]", string.Join(",", accountFields));
        }
        var resp = await _klaviyoService.HTTP<ResponseBody<KlaviyoObject<Account>>>(HttpMethod.Get, $"accounts/{accountId}/", _revision, query, null, null, cancellationToken);
        return resp.Data;
    }
}
