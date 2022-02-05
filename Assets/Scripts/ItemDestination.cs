using UnityEngine;

public class ItemDestination : MonoBehaviour {
    private const string TagToDetect = "Item";

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag(TagToDetect)) {
            GameManager.Score++;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.CompareTag(TagToDetect)) {
            GameManager.Score--;
        }
    }
}