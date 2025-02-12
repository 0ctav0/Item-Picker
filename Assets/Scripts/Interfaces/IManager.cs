using System.Collections;
using UnityEngine;

public interface IManager
{
    ManagerStatus Status { get; }
    IEnumerator Startup(CharacterController player);
}

public enum ManagerStatus
{
    Shutdown,
    Initializing,
    Started,
}