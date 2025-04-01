using Commands;
using Horse.StateManager;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private int targetFPS = 60;
    
    [Header("Views")]
    [SerializeField] private BettingView bettingView;
    [SerializeField] private RaceView raceView;
    
    [Header("Managers")]
    [SerializeField] private RaceManager raceManager;
    [SerializeField] private BettingManager bettingManager;
    
    [Header("Controllers")]
    [SerializeField] private CameraController cameraController;
    [SerializeField] private Finish finish;
    
    [SerializeField] private HorseContext[] horses;
    [SerializeField] private Door[] doors;
    
    private DependencyContainer _dependencyContainer;
    
    private CommandInvoker _commandInvoker;
    private CommandHorseFactory _commandHorseFactory;
    
    private StateHorseManager _stateHorseManager;
    private StateHorseFactory _stateHorseFactory;
    
    private void Awake()
    {
        Application.targetFrameRate = targetFPS;
        
        CreateObject();
        Register();
        Injection();
        Initialize();
    }
    
    private void Update()
    {
        foreach (var horse in horses)
        {
            _stateHorseManager?.UpdateState(horse);
        }
    }

    private void LateUpdate()
    {
        cameraController.UpdateState();
    }
    
    private void CreateObject()
    {
        _dependencyContainer = new DependencyContainer();
        _commandInvoker = new CommandInvoker();
        _commandHorseFactory = new CommandHorseFactory();
        _stateHorseManager = new StateHorseManager();
        _stateHorseFactory = new StateHorseFactory(horses);
    }
    
    private void Register()
    {
        _dependencyContainer.Register(_commandInvoker);
        _dependencyContainer.Register(_commandHorseFactory);
        _dependencyContainer.Register(horses);
        _dependencyContainer.Register(doors);
        _dependencyContainer.Register(_stateHorseManager);
        _dependencyContainer.Register(_stateHorseFactory);
        _dependencyContainer.Register(finish);
        _dependencyContainer.Register(bettingManager);
        _dependencyContainer.Register(raceManager);
        _dependencyContainer.Register(bettingView);
        _dependencyContainer.Register(cameraController);
        _dependencyContainer.Register(raceView);
    }

    private void Injection()
    {
        _commandHorseFactory.Inject(_dependencyContainer);
        bettingManager.Inject(_dependencyContainer);
        bettingView.Inject(_dependencyContainer);
        raceManager.Inject(_dependencyContainer);
        finish.Inject(_dependencyContainer);
        
        foreach (var horse in horses)
        {
            horse.Inject(_dependencyContainer);
        }
    }

    private void Initialize()
    {
        foreach (var door in doors)
        {
            door.Initialize();
        }
        
        raceView.Initialize();
    }
}