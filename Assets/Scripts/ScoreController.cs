using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class ScoreController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    int score = 0;
    int currentLevel = 0;
    private void Awake()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
    }
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = $"Score: {score}";
    }

    public void IncreaseScore(int increment)
    {
        score += increment;
        scoreText.text = $"Score: {score}";
    }
}
