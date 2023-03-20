namespace EFCore_CodeFirst.Dto.PlayerInstruments
{
    public class CreatePlayerInstrumentRequest
    {
        public int InstrumentTypeId { get; set; }
        public string ModelName { get; set; }
        public string Level { get; set; }
    }
}
