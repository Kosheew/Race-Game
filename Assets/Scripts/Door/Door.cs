using UnityEngine;

public class Door : MonoBehaviour
{
    private Animator _animator;
    
    private int _hashDoorOpen;

    public void Initialize()
    {
        _animator = GetComponent<Animator>();
        
        _hashDoorOpen = Animator.StringToHash("Open");
    }

    public void OpenDoor()
    {
        _animator.SetTrigger(_hashDoorOpen);
    }
}
