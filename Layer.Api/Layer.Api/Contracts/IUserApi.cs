using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using Layer.Api.Models;

namespace Layer.Api.Contracts
{
    public interface IUserApi
    {
        Task CreateIdentityAsync(string userId, IdentityObject context, CancellationToken ct);

        Task UpdateIdentityAsync(string userId);

        Task ReplaceIdentityAsync(string userId, IdentityObject context, CancellationToken ct);

        Task<IdentityObject> RetrieveIdentityAsync(string userId, CancellationToken ct);

        Task DeleteIdentityAsync(string userId, CancellationToken ct);

        Task SetUserBangeAsync(string userId, UserBadge badge);

        Task<UserBadge> GetUserBadgeAsync(string userId, CancellationToken ct);

        Task<IEnumerable<string>> GetUserBlockListAsync(string ownerUserId, CancellationToken ct);

        Task UnblockUserAsync(string ownerUserId, string userId, CancellationToken ct);

        Task SuspendUserAsync(string userId, CancellationToken ct);

        Task UnsuspendUserAsync(string userId, CancellationToken ct);

        Task<LayerUser> GetSuspensionStatusAsync(string userId, CancellationToken ct);

        Task SetSessionTimeToLiveAsync(int sessionTtl, CancellationToken ct);

        Task DeleteUserSessionAsync(string userId, CancellationToken ct);
    }
}