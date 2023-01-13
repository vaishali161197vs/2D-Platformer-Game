using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    
    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayerDied()
    {
        gameObject.SetActive(true);
    }
    public void reloadLevel()
    {
        StartCoroutine(ReloadLevel());
    }
    public IEnumerator ReloadLevel()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
