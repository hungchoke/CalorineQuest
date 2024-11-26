using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public float speed;
    public float lifeTime;
    public Transform playerTransform; 

    private void Start()
    {
        
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        transform.position += transform.up * speed * Time.deltaTime;
        Destroy(gameObject, lifeTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            AudioManager.instance.PlaySFX("Eat");
            playerTransform.localScale *= 1.1f;
            Player playerScript = collision.gameObject.GetComponent<Player>();
            if (playerScript != null)
            {
                playerScript.health += 1;
            }
            Destroy(gameObject);
        }
    }
}
