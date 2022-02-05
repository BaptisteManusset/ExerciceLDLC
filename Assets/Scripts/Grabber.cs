using UnityEngine;

public class Grabber : MonoBehaviour {
    private const int MAXDistance = 10;
    [SerializeField] private Transform cam;
    [SerializeField] private Transform hand;
    [Space] [SerializeField] private Transform item;

    [SerializeField] private LayerMask layerMask;
    [Space] [SerializeField] private Material highlightMaterial;


    [Header("Highlight")] private Material _previousMaterial;
    private Renderer _selection;

    private void Update() {
        // Highlight
        if (_selection != null) {
            _selection.material = _previousMaterial;
            _selection = null;
        }

        if (Input.GetMouseButtonDown(0) && item != null) {
            DropItem();
            return;
        }


        if (Physics.Raycast(cam.position, cam.forward, out RaycastHit hit, MAXDistance, layerMask)) {
            if (!hit.collider.CompareTag("Item")) return;


            if (Input.GetMouseButtonDown(0)) {
                if (item == null) GrabItem(hit.collider.transform);
            }


            // Highlight
            Renderer selectedRenderer = hit.transform.GetComponent<Renderer>();
            if (selectedRenderer != null) {
                _previousMaterial = selectedRenderer.material;
                selectedRenderer.material = highlightMaterial;
            }

            _selection = selectedRenderer;
        }
    }


    /// <summary>
    ///     grab the item
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
    ///     drop the item
    /// </summary>
    private void DropItem() {
        Rigidbody rb = item.GetComponent<Rigidbody>();
        rb.isKinematic = false;
        item.parent = null;
        rb.AddForce(cam.transform.forward * 100);
        item = null;
    }
}