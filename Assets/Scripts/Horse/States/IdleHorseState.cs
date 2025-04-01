using UnityEngine;
using System.Collections;

namespace Horse.States
{
    public class IdleHorseState : IHorseState
    {
        private Rigidbody rb;
        
        public void EnterState(HorseContext horseContext)
        {
            horseContext.horseAnimation.RaceAnimation(false);
        }

        public void UpdateState(HorseContext horseContext)
        {
            
        }

        public void ExitState(HorseContext horseContext)
        {

        }
    }
}
