using EFCore_CodeFirst.Dto.PlayerInstruments;
using System.ComponentModel.DataAnnotations;

namespace EFCore_CodeFirst.Dto.Players
{
    public class CreatePlayerRequest
    {
        [Required]
        public string NickName { get; set; }
        [Required]
        public List<CreatePlayerInstrumentRequest>
        PlayerInstruments { get; set; }
    }
}
