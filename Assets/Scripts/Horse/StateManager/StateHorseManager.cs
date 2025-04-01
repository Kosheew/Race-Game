using System.Collections.Generic;
using Horse.States;
using UnityEngine;

namespace Horse.StateManager
{
    public class StateHorseManager
    {
        private Dictionary<HorseContext, IHorseState> _states = new Dictionary<HorseContext, IHorseState>();

        public void SetState(IHorseState newState, HorseContext horse)
        {
            if (_states.ContainsKey(horse))
            {
                _states[horse].ExitState(horse);
            }

            _states[horse] = newState;
            newState.EnterState(horse);
        }

        public void UpdateState(HorseContext horse)
        {
            if (_states.TryGetValue(horse, out var state))
            {
                state.UpdateState(horse);
            }
        }
    }
}