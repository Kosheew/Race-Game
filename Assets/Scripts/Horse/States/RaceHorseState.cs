using UnityEngine;
using System.Collections;

namespace Horse.States
{
    public class RaceHorseState : IHorseState
    {
        private float _baseSpeed;
        private float _currentSpeed;
        private float _targetSpeed;
        private bool _isRunning;
        private Rigidbody _rb;
        private HorseSO _horseSO;
        private float _time;

        public void EnterState(HorseContext horseContext)
        {
            horseContext.horseAnimation.RaceAnimation(true);
            _rb = horseContext.horseRigidBody;
            _horseSO = horseContext.horseSO;

            _isRunning = true;
            _baseSpeed = Random.Range(_horseSO.BaseSpeedRange.x, _horseSO.BaseSpeedRange.y); 
            _currentSpeed = _baseSpeed;

            horseContext.StartCoroutine(AdjustSpeedOverTime());
        }

        public void UpdateState(HorseContext horseContext)
        {
            if (!_isRunning) return;

            _time += Time.deltaTime * 2f;
            float speedFluctuation = Mathf.Sin(_time) * 1.5f;

            _currentSpeed = Mathf.Lerp(_currentSpeed, _targetSpeed + speedFluctuation, 0.1f);
            _rb.velocity = horseContext.transform.forward * _currentSpeed;
        }

        public void ExitState(HorseContext horseContext)
        {
            _isRunning = false;
        }

        private IEnumerator AdjustSpeedOverTime()
        {
            while (_isRunning)
            {
                float speedChange = Random.Range(_horseSO.SpeedChangeRange.x, _horseSO.SpeedChangeRange.y);
                float duration = Random.Range(_horseSO.AccelerationTimeRange.x, _horseSO.AccelerationTimeRange.y);
                float targetSpeed = Mathf.Clamp(_baseSpeed + speedChange, _horseSO.SpeedLimitRange.x, _horseSO.SpeedLimitRange.y);

                _targetSpeed = targetSpeed;
                yield return new WaitForSeconds(duration);
            }
        }
    }
}
