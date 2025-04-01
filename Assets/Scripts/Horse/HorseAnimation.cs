using UnityEngine;

public class HorseAnimation : MonoBehaviour
{
    private Animator _animator;

    private int _hashRace;
    
    public void Initialize()
    {
        _animator = GetComponent<Animator>();
        _hashRace = Animator.StringToHash("Race");
    }

    public void RaceAnimation(bool isRacing)
    {
        _animator.SetBool(_hashRace, isRacing);
    }
}
