using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandOpenDoors : ICommand
{
    private readonly Door[] doors;

    public CommandOpenDoors(DependencyContainer container)
    {
        doors = container.Resolve<Door[]>();
    }

    public void Execute()
    {
        foreach (var door in doors)
        {
            door.OpenDoor();
        }
    }
}
