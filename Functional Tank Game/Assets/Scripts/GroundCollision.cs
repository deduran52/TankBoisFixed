using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCollision : MonoBehaviour
{
    public float startHealth = 100;
    private float currentHealth;
    private bool isDestroyed = false;
    public bool respawnTerrain = true;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = startHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(respawnTerrain == true)
        {
            if(isDestroyed == true)
            {
                // instantiate the new terrain
            }
        }
        
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            currentHealth = currentHealth - 25;
            if (currentHealth <= 0)
            {
                Destroy(gameObject);
                isDestroyed = true;
                
            } // end if
            Destroy(other.gameObject);
        } // end if

    } // end OnCollisionEnter2D
} // end class
