using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Draggable : MonoBehaviour
{
    private Rigidbody _rigidbody;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void OnPick()
    {
        _rigidbody.isKinematic = true;
    }

    public void OnDrop()
    {
        _rigidbody.isKinematic = false;
    }

}
