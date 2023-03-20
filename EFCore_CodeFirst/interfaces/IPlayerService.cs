using EFCore_CodeFirst.Dto.Players;

namespace EFCore_CodeFirst.interfaces
{
    public interface IPlayerService
    {
        Task CreatePlayerAsync(CreatePlayerRequest playerRequest);
    }
}
