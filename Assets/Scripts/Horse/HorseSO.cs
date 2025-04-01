using UnityEngine;

[CreateAssetMenu(fileName = "HorseSO", menuName = "HorseSO")]
public class HorseSO : ScriptableObject
{
    [Header("Base Speed (Min - Max)")]
    [SerializeField] private Vector2 baseSpeedRange = new Vector2(10f, 12f); 
    
    [Header("Speed Variation (Min - Max)")]
    [SerializeField] private Vector2 speedChangeRange = new Vector2(-1.5f, 2f);
   
    [Header("Acceleration Time (Min - Max)")]
    [SerializeField] private Vector2 accelerationTimeRange = new Vector2(0.5f, 2f);

    [Header("Speed Limits (Min - Max)")]
    [SerializeField] private Vector2 speedLimitRange = new Vector2(3f, 10f);
  
    [Header("Visuals")]
    [SerializeField] private Sprite horseIcon;
    [SerializeField] private int horseNumber;
    
    public Vector2 BaseSpeedRange => baseSpeedRange;
    public Vector2 SpeedChangeRange => speedChangeRange;
    public Vector2 AccelerationTimeRange => accelerationTimeRange;
    public Vector2 SpeedLimitRange => speedLimitRange;
    public Sprite HorseIcon => horseIcon;
    public int HorseNumber => horseNumber;
}
