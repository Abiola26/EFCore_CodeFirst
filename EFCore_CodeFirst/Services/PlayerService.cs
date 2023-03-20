using EFCore_CodeFirst.Db.Models;
using EFCore_CodeFirst.Dto.Players;
using EFCore_CodeFirst.interfaces;

namespace EFCore_CodeFirst.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly CodeFirstDemoContext _dbContext;
        public PlayerService(CodeFirstDemoContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreatePlayerAsync(CreatePlayerRequest playerRequest)
        {
            using var transaction = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                var player = new Player
                {
                    NickName = playerRequest.NickName,
                    JoinedDate = DateTime.Now
                };
                await _dbContext.Players.AddAsync(player);
                await _dbContext.SaveChangesAsync();
                var playerId = player.PlayerId;

                var playerInstruments = new List<PlayerInstrument>();
                foreach (var instrument in playerRequest.PlayerInstruments)
                {
                    playerInstruments.Add(new PlayerInstrument
                    {
                        PlayerId = playerId,
                        InstrumentTypeId = instrument.InstrumentTypeId,
                        ModelName = instrument.ModelName,
                        Level = instrument.Level
                    });
                }

                _dbContext.PlayerInstruments.AddRange(playerInstruments);
                await _dbContext.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }


    }
}
