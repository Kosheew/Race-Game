using System;
using System.Collections;
using System.Collections.Generic;
using Commands;
using UnityEngine;

public class Finish : MonoBehaviour
{
   private BettingManager _bettingManager;
   private RaceManager _raceManager;
   private CommandHorseFactory _commandHorseFactory;
   
   public void Inject(DependencyContainer container)
   {
      _bettingManager = container.Resolve<BettingManager>();
      _raceManager = container.Resolve<RaceManager>();
      _commandHorseFactory = container.Resolve<CommandHorseFactory>();
   }

   private void OnTriggerEnter(Collider other)
   {
      if (other.TryGetComponent(out HorseContext horse))
      {
         _raceManager.AddFinishedHose();
         
         _commandHorseFactory?.CreateIdleCommand(horse);
         
         if (horse.Equals(_bettingManager.BettingHorse))
         {
            _raceManager.StopRace();
         }
      }
   }
}
