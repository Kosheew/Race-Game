using UnityEngine;
using UnityEngine.Serialization;

public class CameraController : MonoBehaviour
{
    private Transform _target;
    private Vector3 _offset; 
    
    public void SetTarget(Transform target)
    {
        _target = target;
        _offset = transform.position - _target.position;
    }
    
    public void UpdateState()
    {
        if (_target == null) return;
        
        Vector3 desiredPosition = _target.position + _offset;

        transform.position = desiredPosition;
    }
}
