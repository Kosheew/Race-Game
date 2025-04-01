using Horse.StateManager;

public class RaceCommand : IHorseCommand
{
    private readonly StateHorseManager _stateEnemyManager;
    private readonly StateHorseFactory _stateEnemyFactory;
    public HorseContext HorseContext { get; set; }
        
    public RaceCommand(DependencyContainer container)
    {
        _stateEnemyManager = container.Resolve<StateHorseManager>();
        _stateEnemyFactory = container.Resolve<StateHorseFactory>();
    }

    public void Execute()
    {
        var characterState = _stateEnemyFactory.CreateState(HorseContext, TypeHorseState.Race);
        _stateEnemyManager.SetState(characterState, HorseContext);
    }
}
