using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class Managers : MonoBehaviour
{
    public CharacterController player;
    public GarageManager garage;
    public GrabManager grab;

    private List<IManager> _managers;

    void Awake()
    {
        _managers = new List<IManager>
        {
            garage, grab,
        };
        StartCoroutine(StartupManagers());
    }

    IEnumerator StartupManagers()
    {
        foreach (var manager in _managers)
        {
            StartCoroutine(manager.Startup(player));
        }

        yield return null;

        int numModules = _managers.Count;
        int numReady = 0;

        while (numReady < numModules)
        {
            int lastReady = numReady;
            numReady = 0;

            foreach (var manager in _managers)
            {
                if (manager.Status == ManagerStatus.Started) numReady++;
            }
            yield return null;
        }

        print("All managers started");
    }
}
