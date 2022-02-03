using UnityEngine;

public class Grabber : MonoBehaviour {
    private const int MAXDistance = 10;
    [SerializeField] private Transform cam;
    [SerializeField] private Transform hand;
    [Space] [SerializeField] private Transform item;

    [SerializeField] private LayerMask layerMask;


    private RaycastHit _hit;

    private void Update() {
        if (Input.GetMouseButtonDown(0)) {
            if (item != null) {
                DropItem();
                return;
            }

            if (Physics.Raycast(cam.position, cam.TransformDirection(Vector3.forward), out _hit, MAXDistance, layerMask)) {
                if (!_hit.collider.CompareTag("Item")) return;
                GrabItem(_hit.collider.transform);
            }
        }
    }

    private void OnDrawGizmos() {
        if (_hit.collider != null)
            Gizmos.DrawSphere(_hit.point, .1f);
    }

    /// <summary>
    /// grab the item
    /// </summary>
    /// <param name="target">transform of the item to select</param>
    private void GrabItem(Transform target) {
        item = target;

        Rigidbody rb = item.GetComponent<Rigidbody>();
        rb.isKinematic = true;
        item.parent = hand;
        item.localPosition = Vector3.zero;
        item.localRotation = Quaternion.identity;
    }

    /// <summary>
    /// drop the item
    /// </summary>
    private void DropItem() {
        Rigidbody rb = item.GetComponent<Rigidbody>();
        rb.isKinematic = false;
        item.parent = null;
        rb.AddForce(cam.transform.forward * 100);
        item = null;
    }
}