using UnityEngine;

public class ItemDestination : MonoBehaviour {
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Item")) {
            GameManager.Score++;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Item")) {
            GameManager.Score--;
        }
    }
}