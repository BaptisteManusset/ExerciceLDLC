using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    private static int _score = 0;

    [SerializeField] private int scoreMinToWin = 5;


    public static UnityAction OnScoreChange;
    public static UnityAction OnLoose;
    public static UnityAction OnWin;

    public static int Score {
        get => _score;
        set {
            _score = value;
            OnScoreChange?.Invoke();
        }
    }

    private void Awake() {
        _score = 0;
        Timer.CountDownIsFinish += OnCountDownIsFinish;
    }

    private void OnCountDownIsFinish() {
        if (Score >= scoreMinToWin) {
            OnWin?.Invoke();
            return;
        }

        OnLoose?.Invoke();
    }
}