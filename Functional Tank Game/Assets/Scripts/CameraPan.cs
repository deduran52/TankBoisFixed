using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraPan : MonoBehaviour
{
    /* Variable to dectect whos turn it is */
    public ProjectileCollision Bullet;
    public PlayerTank1 player1;
    public PlayerTank2 player2;

    /* Camera variables */
    public Camera player1Camera;
    public Camera player2Camera;
    public Camera bulletCamera;

    /* Variables to get the position of the player objects */
    //public Transform tank1;
    //public Transform tank2;

    /* Variable to hold the position for the player objects and the bullet objects */
    float xPos;                // x position
    float yPos;                // y position
    float zPos;                // z position

    float xPos1;                // x position
    float yPos1;                // y position
    float zPos1;                // z position

    float xPos2;                // x position
    float yPos2;                // y position
    float zPos2;                // z position

    /* Vector3 variables */
    Vector3 bulletCenter;
    Vector3 tank1Center;
    Vector3 tank2Center;

    /* Check variables */
    //public bool cameraCheck1 = false;
    //public bool cameraCheck2 = false;

    /* Delay variable */
    public float baseTimer = 5;
    float timer1;
    float timer2;
    

    /*---------------------------------------------------------------*/

    void Start()
    {
        /* PlayerTank objects */
        player1 = GameObject.FindWithTag("PlayerTank1").GetComponent<PlayerTank1>();
        player2 = GameObject.FindWithTag("PlayerTank2").GetComponent<PlayerTank2>();

        /* Instatiating variables to access the postitions of the tanks */
        //tank1 = GameObject.FindWithTag("PlayerTank1").transform;
        //tank2 = GameObject.FindWithTag("PlayerTank2").transform;

        /* setting the projectile timers */
        timer1 = baseTimer;
        timer2 = baseTimer;

    } // end void start

    //-------------------------------------------------------------------------------------------------------------------------------

    void Update()
    {

        if(player1.turnCheck)
        {
            player1Camera.enabled = true;
            player2Camera.enabled = false;
            bulletCamera = false;
            if(player)
        }


























        /* bullet location 
        xPosB = Bullet.transform.position.x;
        yPosB = Bullet.transform.position.y;
        zPosB = transform.position.z;

        /* tank1 location 
        xPos1 = tank1.transform.position.x + 5;
        yPos1 = 3;
        zPos1 = transform.position.z;

        /* tank2 location 
        xPos2 = tank2.transform.position.x + 5;
        yPos2 = 3;
        zPos2 = transform.position.z;

        /* setting the cameras to the appropriate locations
        bulletCenter = new Vector3(xPosB, yPosB, zPosB);
        bulletCamera.transform.position = bulletCenter;

        tank1Center = new Vector3(xPos1, yPos1, zPos1);
        player1Camera.transform.position = tank1Center;

        tank2Center = new Vector3(xPos2, yPos2, zPos2);
        player2Camera.transform.position = tank2Center;
        */


        /* Need to up Date every scene since the bullet is not created until it is fired */
        //Bullet = GameObject.FindWithTag("Bullet").GetComponent<ProjectileCollision>();         // Having a hard time determining wheather the object exist or not

        //---------------------------------------------------------------------------------------------------


        /* Changes camera to the projectile 
        
        if (Bullet.IsDestroyed == false)
        {
            bulletCamera.enabled = true;                             // Need to change the camera from enabled to something else that will determine
            player1Camera.enabled = false;                           // wheather the camera is on or not.
            player2Camera.enabled = false;                           // this line aslo needs to be changed.

            /* Getting the position for the bulletsd 
            xPos = Bullet.transform.position.x;
            yPos = Bullet.transform.position.y;
            zPos = transform.position.z;

            // setting the postion of the camera with the vector
            Vector3 center = new Vector3(xPos, yPos, zPos);

            // setting the position marker for the camera
            bulletCamera.transform.position = center;

            if (player1.firedProjectile)
            {
                player1.turnCheck = false;
                player2.turnCheck = false;
                timer1 -= Time.deltaTime;
                if(timer1 <= 0)
                {
                    player1.turnCheck = false;
                    player2.turnCheck = true;
                    player1Camera.enabled = false;
                    player2Camera.enabled = true;
                    bulletCamera.enabled = false;
                    timer1 = baseTimer;
                }
            }

            if(player2.firedProjectile)
            {
                player1.turnCheck = false;
                player2.turnCheck = false;
                timer2 -= Time.deltaTime;
                if(timer2 <= 0)
                {
                    player1.turnCheck = true;
                    player2.turnCheck = false;
                    player1Camera.enabled = true;
                    player2Camera.enabled = false;
                    bulletCamera.enabled = false;
                    timer2 = baseTimer;
                }
            }

        }

        else
        {
            /* setting the player camera to true 
            if(player1.turnCheck)
            {
                player1Camera.enabled = true;
                player2Camera.enabled = false;
                bulletCamera.enabled = false;
            }

            /* setting the player camera to true 
            else if(player2.turnCheck)
            {
                player1Camera.enabled = false;
                player2Camera.enabled = true;
                bulletCamera.enabled = false;
            }
        }
        */
    } // end void update

} // end of CameraPan class
