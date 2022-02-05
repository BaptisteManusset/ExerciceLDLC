using UnityEngine;

public class UiManager : MonoBehaviour {
    [SerializeField] private GameObject sucessUi;
    [SerializeField] private GameObject loosUi;

    private void Awake() {
        GameManager.OnWin += OnWin;
        GameManager.OnLoose += OnLoose;

        //Reset Ui at startup
        sucessUi.SetActive(false);
        loosUi.SetActive(false);
    }

    private void OnWin() {
        FpsController.UnlockCursor();

        sucessUi.SetActive(true);
    }

    private void OnLoose() {
        FpsController.UnlockCursor();

        loosUi.SetActive(true);
    }
}