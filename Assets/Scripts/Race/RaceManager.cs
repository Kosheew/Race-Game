using Commands;
using UnityEngine;

public class RaceManager : MonoBehaviour
{
    private CommandInvoker _invoker;
    
    private ICommand _commandOpenDoors;
    private ICommand _commandRaceHorces;
    
    private CommandHorseFactory _commandHorseFactory;
    private RaceView _racerView;
    
    private int _countFinished;
    
    public void Inject(DependencyContainer container)
    {
        _invoker = container.Resolve<CommandInvoker>();
        _commandHorseFactory = container.Resolve<CommandHorseFactory>();
        _racerView = container.Resolve<RaceView>();
        
        _commandOpenDoors = new CommandOpenDoors(container);
        _commandRaceHorces = new CommandRaceHorses(container);
    }

    public void StartRace()
    {
        _commandOpenDoors.Execute();
        _commandRaceHorces.Execute();
        _invoker.ExecuteCommands();
    }

    public void StopRace()
    {
        if (_countFinished <= 1) _racerView.SetTextWin();
        else _racerView.SetTextLose(_countFinished);
    }

    public void AddFinishedHose()
    {
        _countFinished++;
    }
}