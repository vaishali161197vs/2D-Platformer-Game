using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] float enemySpeed = 10f;
    private void Start()
    {
        
    }
    private void Update()
    {
        Patrol();
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
            playerController.KillPlayer();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        transform.Rotate(0, 180, 0);
    }
    void Patrol()
    {
        transform.Translate(Vector3.right * enemySpeed * Time.deltaTime);
        
    }
}
