using TMPro;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    [SerializeField] private TextMeshProUGUI _textMeshPro;

    private int score = 0;

    private void Awake() {
        instance = this;
    }
    void Start() {
        _textMeshPro.text = score.ToString();
    }

    public void AddPoint() {
        Debug.Log("add point work");
        if (_textMeshPro != null) {
            score += 10;
            _textMeshPro.text = score.ToString();
        }
        else {
            Debug.LogError("TextMeshProUGUI reference is missing. Cannot update score.");
        }
    }
}
