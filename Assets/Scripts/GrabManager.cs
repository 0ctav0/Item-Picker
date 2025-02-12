using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GrabManager : MonoBehaviour, IManager
{
    public ManagerStatus Status { get; private set; }
    [SerializeField] private Transform grabOrigin;
    [SerializeField] private Button dropBtn;

    [SerializeField] private float dropForce = 15;

    private Draggable _draggable;
    private CharacterController _player;

    public IEnumerator Startup(CharacterController player)
    {
        _player = player;
        dropBtn.onClick.AddListener(Drop);
        Status = ManagerStatus.Started;
        yield return null;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            var hits = Physics.RaycastAll(Camera.main.ScreenPointToRay(Input.mousePosition));
            foreach (var hit in hits)
            {
                var item = hit.collider.gameObject.GetComponent<Draggable>();
                if (item && _draggable == null) Pick(item);
            }
        }
        if (_draggable)
            _draggable.transform.position = grabOrigin.position;
    }

    void Pick(Draggable item)
    {
        _draggable = item;
        _draggable.OnPick();
        dropBtn.gameObject.SetActive(true);
    }

    void Drop()
    {
        _draggable.OnDrop();
        _draggable.GetComponent<Rigidbody>().velocity = Camera.main.transform.forward * dropForce;
        _draggable = null;
        dropBtn.gameObject.SetActive(false);
    }
}
