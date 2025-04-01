using Commands;

public class CommandRaceHorses : ICommand
{
    private readonly HorseContext[] horses;
    private CommandHorseFactory _commandHorseFactory;
    
    public CommandRaceHorses(DependencyContainer container)
    {
        horses = container.Resolve<HorseContext[]>();
        _commandHorseFactory = container.Resolve<CommandHorseFactory>();
    }
    
    public void Execute()
    {
        foreach (var horse in horses)
        {
            _commandHorseFactory.CreateRaceCommand(horse);
        }
    }
}
