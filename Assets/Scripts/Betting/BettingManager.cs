using UnityEngine;

public class BettingManager : MonoBehaviour
{
    private RaceManager _raceManager;
    private CameraController _cameraController;
    private HorseContext[] _horses;
    
    public HorseContext BettingHorse;
    
    public void Inject(DependencyContainer container)
    {   
        _raceManager = container.Resolve<RaceManager>();
        _cameraController = container.Resolve<CameraController>();
        _horses = container.Resolve<HorseContext[]>();
    }
    
    public void PlaceBet(int racerIndex)
    {
        BettingHorse = _horses[racerIndex];
        _cameraController.SetTarget(BettingHorse.transform);
        _raceManager.StartRace();
    }
}
