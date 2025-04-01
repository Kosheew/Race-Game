public interface IHorseCommand : ICommand
{
    public HorseContext HorseContext { get; set; }
}
