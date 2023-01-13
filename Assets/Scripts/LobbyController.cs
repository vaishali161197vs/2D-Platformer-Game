using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LobbyController : MonoBehaviour
{
    public Button PlayButton;
    public Button ContinueButton;
    public Button QuitButton;
    public GameObject LevelSelectionPopup;
    private void Awake()
    {
        PlayButton.onClick.AddListener(PlayGame);
        ContinueButton.onClick.AddListener(ContinueLevel);
        QuitButton.onClick.AddListener(QuitGame);
    }
    public void PlayGame()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        LevelSelectionPopup.SetActive(true);
    }
    public void ContinueLevel()
    {
        SceneManager.LoadScene(PlayerPrefs.GetString("LastLevel"));
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
