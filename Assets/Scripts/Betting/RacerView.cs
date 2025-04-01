using UnityEngine;
using UnityEngine.UI;

public class RacerView : MonoBehaviour
{
    [SerializeField] private Button buttonRacer;
    [SerializeField] private Text textNumberRacer;
    [SerializeField] private Image imageRacer;

    private BettingPresenter bettingPresenter;
    
    public void Initialize(HorseContext horseContext, BettingPresenter presenter)
    {
        textNumberRacer.text = horseContext.horseSO.HorseNumber.ToString();
        imageRacer.sprite = horseContext.horseSO.HorseIcon;
        
        bettingPresenter = presenter;
        
        buttonRacer.onClick.AddListener(() => OnRacerSelected(horseContext));
    }
    
    private void OnRacerSelected(HorseContext horseContext)
    {
        bettingPresenter.SelectRacer(horseContext.horseSO.HorseNumber - 1);
    }
}
