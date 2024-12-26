using System;
using Toolbox.Dto.Cheatsheet;

namespace Toolbox.Repo.Interfaces;

public interface ICheatsheetRepo
{
    Task<List<GetCheatsheet>> GetAllCheatsheet();
    Task<List<GetCheatsheet>> GetAllCheatsheetByUser(string userId);
    Task<GetCheatsheet> GetCheatsheetById(Guid cheatheetId);
    Task<GetCheatsheet> CreateCheatsheet(CreateCheatsheet payload);
    Task<GetCheatsheet> UpdateCheatsheet(Guid drawingId, UpdateCheatsheet payload);
}
