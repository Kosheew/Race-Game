using System;
using System.Collections.Generic;
using Horse.States;

namespace Horse.StateManager
{
    public class StateHorseFactory
    {
        private readonly Dictionary<HorseContext, Dictionary<TypeHorseState, IHorseState>> _statePools;
        
        public StateHorseFactory(HorseContext[] horses)
        {
            _statePools = new(horses.Length);
        
            foreach (var horseContext in horses)
            {
                if (!_statePools.ContainsKey(horseContext))
                {
                    _statePools[horseContext] = new Dictionary<TypeHorseState, IHorseState>
                    {
                        { TypeHorseState.Idle, new IdleHorseState() },
                        { TypeHorseState.Race, new RaceHorseState() }
                    };
                }
            }
        }
    
        public IHorseState CreateState(HorseContext horse, TypeHorseState stateName)
        {
            if (_statePools.ContainsKey(horse))
            {
                return _statePools[horse][stateName];
            }

            throw new ArgumentException($"Unknown state: {stateName}");
        }
    }
}