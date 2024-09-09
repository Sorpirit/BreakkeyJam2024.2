using UnityEngine;

public class HardLock : MonoBehaviour
{
    [SerializeField] private Transform target;

    [SerializeField] private bool captureOffsetOnStart = true;
    [SerializeField] private bool followPosition = true;
    [SerializeField] private bool followRotation = true;

    private Vector3 offset;

    private void Start()
    {
        if (captureOffsetOnStart)
        {
            offset = target.position - transform.position;
        }
    }

    private void LateUpdate()
    {
        if (followPosition)
        {
            transform.position = target.position - offset;
        }

        if (followRotation)
        {
            transform.rotation = target.rotation;
        }
    }
}
