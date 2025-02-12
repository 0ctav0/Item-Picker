using System.Collections;
using UnityEngine;

public class GrabManager : MonoBehaviour, IManager
{
    public ManagerStatus Status { get; private set; }
    [SerializeField] private Transform grabOrigin;

    private Draggable _draggable;
    private CharacterController _player;

    public IEnumerator Startup(CharacterController player)
    {
        _player = player;
        Status = ManagerStatus.Started;
        yield return null;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var hits = Physics.RaycastAll(Camera.main.ScreenPointToRay(Input.mousePosition));
            foreach (var hit in hits)
            {
                var item = hit.collider.gameObject.GetComponent<Draggable>();
                if (item != null && item == _draggable) Drop();
                else if (item) Pick(item);
            }
        }
        if (_draggable)
            _draggable.transform.position = grabOrigin.position;
    }

    void Pick(Draggable item)
    {
        _draggable = item;
        _draggable.OnPick();
    }

    void Drop()
    {
        _draggable.OnDrop();
        _draggable = null;
    }
}
