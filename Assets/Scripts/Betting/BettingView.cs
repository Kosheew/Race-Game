using UnityEngine;

public class BettingView : MonoBehaviour
{
    [SerializeField] private RacerView[] racerViews;
    private BettingPresenter bettingPresenter;
    private HorseContext[] horses;
    
    public void Inject(DependencyContainer container)
    {
        horses = container.Resolve<HorseContext[]>();
        
        bettingPresenter = new BettingPresenter(container);
        
        for (int i = 0; i < horses.Length; i++)
        {
            racerViews[i].Initialize(horses[i], bettingPresenter); 
        }
    }
}
