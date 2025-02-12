using UnityEngine;
using DG.Tweening;


public class Door : MonoBehaviour
{
    [SerializeField] private float doorOpeningDuration = 3;
    [SerializeField] private Vector3 rotation = Vector3.forward * 70;
    [SerializeField] private Vector3 offset = Vector3.up * 5;
    public void Open()
    {
        transform.DORotate(rotation, doorOpeningDuration);
        transform.DOMove(transform.position + offset, doorOpeningDuration);
    }
}
