using UnityEngine;

public class HardLock : MonoBehaviour {
    [SerializeField] private Transform target;

    [SerializeField] private bool captureOffsetOnStart = true;
    [SerializeField] private bool followPosition = true;
    [SerializeField] private bool followRotation = true;

    private Vector3 offset;

    private void Start() {
        if (target != null && captureOffsetOnStart) {
            offset = target.position - transform.position;
        }
    }
    public void SetTarget(Transform newTarget) {
        target = newTarget;
        if (captureOffsetOnStart) {
            offset = target.position - transform.position;
        }
    }

    private void LateUpdate() {
        if (target == null)
            return;

        if (followPosition) {
            transform.position = target.position - offset;
        }

        if (followRotation) {
            transform.rotation = target.rotation;
        }
    }
}