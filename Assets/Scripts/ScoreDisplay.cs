using TMPro;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour {
    private TMP_Text _text;


    private void Awake() {
        _text = GetComponent<TMP_Text>();
        GameManager.OnScoreChange += OnScoreChange;
        OnScoreChange();
    }

    private void OnScoreChange() {
        _text.text = $"Score: {GameManager.Score}";
    }

    private void OnDestroy() => GameManager.OnScoreChange -= OnScoreChange;
}