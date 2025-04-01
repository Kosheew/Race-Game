using Commands;
using UnityEngine;
using UnityEngine.UI;

public class HorseContext : MonoBehaviour
{
    public HorseSO horseSO;
    [SerializeField] private Text textNumber;
    public HorseAnimation horseAnimation { get; private set; }
    public Rigidbody horseRigidBody { get; private set; }

    private CommandHorseFactory _commandHorseFactory;

    public void Inject(DependencyContainer container)
    {
        _commandHorseFactory = container.Resolve<CommandHorseFactory>();
        
        horseAnimation = GetComponent<HorseAnimation>();
        horseRigidBody = GetComponent<Rigidbody>();
        
        horseAnimation.Initialize();
        textNumber.text = horseSO.HorseNumber.ToString();
        
        _commandHorseFactory.CreateIdleCommand(this);
    }
}
