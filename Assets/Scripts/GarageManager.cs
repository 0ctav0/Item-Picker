using UnityEngine;
using System.Collections;

public class GarageManager : MonoBehaviour, IManager
{
    public ManagerStatus Status { get; private set; }

    [SerializeField] private Door _door;

    public IEnumerator Startup(CharacterController player)
    {
        yield return new WaitForSeconds(1);
        _door.Open();
        Status = ManagerStatus.Started;
    }
}
