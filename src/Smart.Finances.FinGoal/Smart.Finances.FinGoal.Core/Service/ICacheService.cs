using Microsoft.Extensions.Caching.Distributed;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Transactions;

namespace Smart.Finances.FinGoal.Core.Service;

public interface ICacheService
{
    Task Set<T>(string key, T value);

    Task<T?> Get<T>(string key);
}