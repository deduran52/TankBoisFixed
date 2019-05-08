using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ProjectileCollision : MonoBehaviour
{
    /* Bullet Variables */
    public float Impactdelay = .1f;
    public float cameraDelay = 5f;
    public bool IsDestroyed;

    /* Player Objects */
    PlayerTank1 player1;
    PlayerTank2 player2;
    //public Camera camera1;
    //public GameObject emitter1;
    //public GameObject emitter2;

    /* Delay timer */
    public float delayTimer;


    public GameObject explosion; // drag your explosion prefab here

    public GameObject tilemapGameObject;

    Tilemap tilemap;


    public void Start()
    {
        player1 = GameObject.FindWithTag("PlayerTank1").GetComponent<PlayerTank1>();
        player2 = GameObject.FindWithTag("PlayerTank2").GetComponent<PlayerTank2>();
        //camera1 = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        tilemap = GameObject.FindWithTag("Ground").GetComponent<Tilemap>();

        IsDestroyed = true;

       
        tilemap = tilemapGameObject.GetComponent<Tilemap>();

    }

    private void Update()
    {
        /* setting the timer for the delay */
        //delayTimer = camera1.delayTime;

        /* Checking the Player1 object to see if it fired a bullet */
        if (player1.firedProjectile == true)
        {
            IsDestroyed = false;
            //Instantiate(camera1, emitter1.transform.position, emitter1.transform.rotation);
            //player1.turnCheck = false;
            //player2.turnCheck = false;
            //delayTimer -= Time.deltaTime;
            //player2.turnCheck = true;
        }

        /* Checking the Player2 object to see if it fired a bullet */
        if (player2.firedProjectile == true)
        {
            IsDestroyed = false;
            //Instantiate(camera1, emitter2.transform.position, emitter2.transform.rotation);
            //player1.turnCheck = false;
            //player2.turnCheck = false;
            //delayTimer -= Time.deltaTime;
            //player1.turnCheck = true;
        }
        
    }
    
    void OnCollisionEnter2D(Collision2D other)
    {
        Vector2 hitPosition = Vector2.zero;
        if (other.gameObject.CompareTag("Ground"))
        {
            GameObject expl = Instantiate(explosion, transform.position, Quaternion.identity) as GameObject;
            Destroy(expl, 1); // delete the explosion after 1 seconds
            Destroy(gameObject, Impactdelay);
            //Destroy(camera1, cameraDelay);
            IsDestroyed = true;
            foreach (ContactPoint2D hit in other.contacts)
            {
                hitPosition.x = hit.point.x;
                hitPosition.y = hit.point.y;
                tilemap.SetTile(tilemap.WorldToCell(hitPosition), null);
                //TileDestructionLoop(hitPosition);
            }
        }

        else if (other.gameObject.CompareTag("Terrain"))
        {

            GameObject expl = Instantiate(explosion, transform.position, Quaternion.identity) as GameObject;
            Destroy(expl, 1); // delete the explosion after 1 seconds
            Destroy(gameObject, Impactdelay);
            //Destroy(camera1, cameraDelay);
            IsDestroyed = true;
        }

        else if(other.gameObject.CompareTag("Wall"))
        {

            GameObject expl = Instantiate(explosion, transform.position, Quaternion.identity) as GameObject;
            Destroy(expl, 1); // delete the explosion after 1 seconds
            Destroy(gameObject, Impactdelay);
            //Destroy(camera1, cameraDelay);
            IsDestroyed = true;
        }

        else if(other.gameObject.CompareTag("PlayerTank1"))
        {
            GameObject expl = Instantiate(explosion, transform.position, Quaternion.identity) as GameObject;
            Destroy(expl, 1); // delete the explosion after 1 seconds
            Destroy(gameObject, Impactdelay);
            //Destroy(camera1, cameraDelay);
            IsDestroyed = true;
        }

        else if (other.gameObject.CompareTag("PlayerTank2"))
        {

            GameObject expl = Instantiate(explosion, transform.position, Quaternion.identity) as GameObject;
            Destroy(expl, 1); // delete the explosion after 1 seconds
            Destroy(gameObject, Impactdelay);
            //Destroy(camera1, cameraDelay);
            IsDestroyed = true;

            
        }

    }


    void TileDestructionLoop (Vector3 impactLocation)
    {
            impactLocation.y = impactLocation.y + (float).5;
            float StartVAR = impactLocation.x = impactLocation.x - (float).5;
            tilemap.SetTile(tilemap.WorldToCell(impactLocation), null);
        for (int i = 0; i < 6; i++)
        {
            for (int n = 0; n < 6; n++)
            {
                impactLocation.x = impactLocation.x + (float).25;
                tilemap.SetTile(tilemap.WorldToCell(impactLocation), null);
            }

            impactLocation.y = impactLocation.y - (float).25;
            impactLocation.x = StartVAR;
            tilemap.SetTile(tilemap.WorldToCell(impactLocation), null);
        }
    }
            
            



    
}

    


