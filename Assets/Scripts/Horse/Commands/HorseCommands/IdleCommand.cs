using Horse.StateManager;

public class IdleCommand : IHorseCommand
{
    private readonly StateHorseManager _stateEnemyManager;
    private readonly StateHorseFactory _stateEnemyFactory;
    public HorseContext HorseContext { get; set; }
        
    public IdleCommand(DependencyContainer container)
    {
        _stateEnemyManager = container.Resolve<StateHorseManager>();
        _stateEnemyFactory = container.Resolve<StateHorseFactory>();
    }

    public void Execute()
    {
        var characterState = _stateEnemyFactory.CreateState(HorseContext, TypeHorseState.Idle);
        _stateEnemyManager.SetState(characterState, HorseContext);
    }
}
