using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{
    [SerializeField] float fadeSpeed = 10;
    bool fadeOutKey = false;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerController>() != null)
        {
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
            playerController.PickUpKey();
            fadeOutKey = true;
        }
    }

    private void FadeOutKey()
    {
       
      
        Color color = gameObject.GetComponent<SpriteRenderer>().color;

        float fadeAmount = color.a - (fadeSpeed * Time.deltaTime);

        color = new Color(color.r, color.g, color.b, fadeAmount);
        gameObject.GetComponent<SpriteRenderer>().color = color;

        if (color.a <= 0)
        {
            Debug.Log("Key Destroyed.");
            Destroy(gameObject);
            fadeOutKey = false;
        }
      
    }

    private void Update()
    {
        if(fadeOutKey)
        {
            FadeOutKey();
        }
    }
}
