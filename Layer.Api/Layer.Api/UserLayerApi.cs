using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

using Layer.Api.Contracts;
using Layer.Api.Models;
using Layer.Api.Operations;

namespace Layer.Api
{
    public class UserLayerApi : BaseLayerApi, IUserApi
    {
        public UserLayerApi(LayerConfiguration config)
            : base(config)
        {}

        public Task CreateIdentityAsync(string userId, IdentityObject context, CancellationToken ct)
        {
            var url = $"apps/{Config.ApplicationId}/users/{userId}/identity";
            return SendAsync(url, HttpMethod.Post, ct, context);
        }

        public Task UpdateIdentityAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public Task ReplaceIdentityAsync(string userId, IdentityObject context, CancellationToken ct)
        {
            var url = $"/apps/{Config.ApplicationId}/users/{userId}/identity";
            return SendAsync(url, HttpMethod.Put, ct, context);
        }

        public Task<IdentityObject> RetrieveIdentityAsync(string userId, CancellationToken ct)
        {
            var url = $"apps/{Config.ApplicationId}/users/{userId}/identity";
            return SendAsync<IdentityObject>(url, HttpMethod.Get, ct);
        }

        public Task DeleteIdentityAsync(string userId, CancellationToken ct)
        {
            var url = $"apps/{Config.ApplicationId}/users/{userId}/identity";
            return SendAsync(url, HttpMethod.Delete, ct);
        }

        public Task SetUserBangeAsync(string userId, UserBadge badge)
        {
            var url = $"apps/{Config.ApplicationId}/users/{userId}/badge";

            throw new NotImplementedException();
        }

        public Task<UserBadge> GetUserBadgeAsync(string userId, CancellationToken ct)
        {
            var url = $"apps/{Config.ApplicationId}/users/{userId}/badge";
            return SendAsync<UserBadge>(url, HttpMethod.Get, ct);
        }

        public async Task<IEnumerable<string>>  GetUserBlockListAsync(string ownerUserId, CancellationToken ct)
        {
            var url = $"apps/{Config.ApplicationId}/users/{ownerUserId}/blocks";
            var ids = await SendAsync<IEnumerable<UserId>>(url, HttpMethod.Get, ct);
            return ids.Select(x => x.Id);
        }

        public Task UnblockUserAsync(string ownerUserId, string userId, CancellationToken ct)
        {
            var url = $"apps/{Config.ApplicationId}/users/{ownerUserId}/blocks{userId}";
            return SendAsync(url, HttpMethod.Delete, ct);
        }

        public Task SuspendUserAsync(string userId, CancellationToken ct)
        {
            var url = $"apps/{Config.ApplicationId}/users/{userId}";
            var suspendOperation = new SuspendOperation(true);
            var context = new[] { suspendOperation };
            return SendAsync(url, new HttpMethod("PATCH"), ct, context);
        }

        public Task UnsuspendUserAsync(string userId, CancellationToken ct)
        {
            var url = $"apps/{Config.ApplicationId}/users/{userId}";
            var suspendOperation = new SuspendOperation(false);
            var context = new[] { suspendOperation };
            return SendAsync(url, new HttpMethod("PATCH"), ct, context);
        }

        public Task<LayerUser> GetSuspensionStatusAsync(string userId, CancellationToken ct)
        {
            var url = $"apps/{Config.ApplicationId}/users/{userId}";
            return SendAsync<LayerUser>(url, HttpMethod.Get, ct);
        }

        public Task SetSessionTimeToLiveAsync(int sessionTtl, CancellationToken ct)
        {
            if (sessionTtl < 30 || sessionTtl > 31536000)
            {
                throw new ArgumentOutOfRangeException(nameof(sessionTtl));
            }
            var url = $"apps/{Config.ApplicationId}";
            var setSessionTtlOperation = new SetSessionTtlOperation(sessionTtl);
            return SendAsync(url, new HttpMethod("PATCH"), ct, new[] { setSessionTtlOperation });
        }

        public Task DeleteUserSessionAsync(string userId, CancellationToken ct)
        {
            var url = $"apps/{Config.ApplicationId}/users/{userId}/sessions";
            return SendAsync(url, HttpMethod.Delete, ct);
        }
    }
}