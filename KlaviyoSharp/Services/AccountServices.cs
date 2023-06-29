using System.Collections.Generic;
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
        var resp = await _klaviyoService.GET<ResponseBody<List<KlaviyoObject<Account>>>>("accounts/", _revision, query, null, cancellationToken);
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
        var resp = await _klaviyoService.GET<ResponseBody<KlaviyoObject<Account>>>($"accounts/{accountId}/", _revision, query, null, cancellationToken);
        return resp.Data;
    }
}
