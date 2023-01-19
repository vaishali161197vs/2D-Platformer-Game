using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{   
    [SerializeField] TextMeshProUGUI levelText;
    int score = 0;
    int currentLevel = 0;
    private void Awake()
    {
        levelText = GetComponent<TextMeshProUGUI>();
    }
    // Start is called before the first frame update
    void Start()
    {
        if(levelText)
            levelText.text = $"Level: {SceneManager.GetActiveScene().buildIndex}";
    }

   

}
