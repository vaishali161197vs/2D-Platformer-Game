using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
[RequireComponent(typeof(Button))]
public class LevelLoader : MonoBehaviour
{
    private Button button;
    public string LevelName;
    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(onClick);
    }
    
    private void onClick()
    {
        LevelStatus levelStatus = LevelManager.Instance.GetLevelStatus(LevelName);
        switch(levelStatus)
        {
            case LevelStatus.Locked:
                Debug.Log("Can't Play this level till you unlock it.");
                break;

            case LevelStatus.Unlocked:
                SceneManager.LoadScene(LevelName);
                PlayerPrefs.SetString("LastLevel", LevelName);
                break;

            case LevelStatus.Completed:
                SceneManager.LoadScene(LevelName);
                PlayerPrefs.SetString("LastLevel", LevelName);
                break;
        }
        
        
    }

    
}
