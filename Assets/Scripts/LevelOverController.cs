using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelOverController : MonoBehaviour
{
    [SerializeField] GameObject GameOverPanel;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerController>() != null)
        {
            SoundManager.Instance.Play(Sounds.LevelComplete);
            Debug.Log("Level finished by Player.");
            LevelManager.Instance.MarkCurrentLevelComplete();
            if(LevelManager.Instance.showGameOverPanel)
            {
                GameOverPanel.SetActive(true);
            }
        }
    }
}
