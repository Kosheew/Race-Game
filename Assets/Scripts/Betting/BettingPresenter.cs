public class BettingPresenter 
{
    private BettingManager _bettingManager;
    
    public BettingPresenter(DependencyContainer container)
    {
        _bettingManager = container.Resolve<BettingManager>();
    }
    
    public void SelectRacer(int index)
    {
        _bettingManager.PlaceBet(index);
    }
}
