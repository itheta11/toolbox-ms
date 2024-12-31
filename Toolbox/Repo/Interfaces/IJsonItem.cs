using System;
using Toolbox.Dto.JsonItem;

namespace Toolbox.Repo.Interfaces;

public interface IJsonItem
{
    Task<List<GetJsonItem>> GetJsonItems();
    Task<List<GetJsonItem>> GetJsonItemsByUser(string userId);

    Task<GetJsonItem> GetJsonItemById(Guid schemaId);
    Task<GetJsonItem> CreateJsonItem(CreateJsonItem payload);
    Task<GetJsonItem> UpdateJsonItem(Guid schemaId, UpdateJsonItem payload);
}
