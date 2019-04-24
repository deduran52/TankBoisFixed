using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPan : MonoBehaviour
{
    /* Variable to dectect whos turn it is */
    PlayerTank1 player1;
    PlayerTank2 player2;
    ProjectileCollision Bullet;

    /* Variables to get the position of the player objects */
    Transform tank1;
    Transform tank2;

    /* Variable to hold the position for the player objects and the bullet objects */
    float xPos;                // x position
    float yPos;                // y position
    float zPos;                // z position

    /* Vector variable so to store the above three position vairable into */
    Vector3 center;

    /* Check variables */
    public bool cameraCheck1 = false;
    public bool cameraCheck2 = false;

    /* Delay variable */
    float currentTime = Time.deltaTime;
    public float delayTime = 2;





    /* These variables bellow may not be need to but I am not sure at the moment */
    float margin = 0.001f;

    float z0 = 0f;
    float zCam;
    float wScene;
    float xL;
    float xR;
    /*---------------------------------------------------------------*/



    // Start is called before the first frame update
    /*
    void calcScreen(Transform p1, Transform p2)
    {
        // Calculates the xL and xR screen coordinates 
        if (p1.position.x < p2.position.x)
        {
            xL = p1.position.x - margin;
            xR = p2.position.x + margin;
        }
        else
        {
            xL = p2.position.x - margin;
            xR = p1.position.x + margin;
        }
    }
    */
    //---------------------------------------------------------------------------------------------------------------------

    void Start()
    {
        /* This is instantiating the tank objects as an accesable variable */
        player1 = GameObject.FindWithTag("PlayerTank1").GetComponent<PlayerTank1>();
        player2 = GameObject.FindWithTag("PlayerTank2").GetComponent<PlayerTank2>();

        /* this is instantiating the bullet object as an accesable variable */
        Bullet = GameObject.FindWithTag("Bullet").GetComponent<ProjectileCollision>();

        /* Instatiating variables to access the postitions of the tanks */
        tank1 = GameObject.FindWithTag("PlayerTank1").transform;
        tank2 = GameObject.FindWithTag("PlayerTank2").transform;


        /* setting the position of tank 1 as the start point for the camera */
        // Setting the current position of the tank
        xPos = player1.transform.position.x + 5;
        yPos = 3;
        zPos = transform.position.z;

        // inputing the variables into a vector for quick input
        center = new Vector3(xPos, yPos, zPos);

        // setting the postition markers for the camera
        gameObject.transform.position = center;

        /* possibly not neccesary */
        //calcScreen(tank1, tank2);
        //wScene = xR - xL;
        //zCam = transform.position.z - z0;

    } // end void start

    //-------------------------------------------------------------------------------------------------------------------------------

    void Update()
    {
        /* Need to up Date every scene since the bullet is not created until it is fired */
        Bullet = GameObject.FindWithTag("Bullet").GetComponent<ProjectileCollision>();

        //---------------------------------------------------------------------------------------------------

        /* Changes camera to the Player1 */
        if (player1.turnCheck == true && Bullet.IsDestroyed == true)
        {
            // updating the cameraChecks to make sure they are in the appropriet position
            cameraCheck1 = true;
            cameraCheck2 = false;

            // Setting the current position of the tank
            xPos = player1.transform.position.x + 5;
            yPos = 3;
            zPos = transform.position.z;

            // inputing the variables into a vector for quick input
            center = new Vector3(xPos, yPos, zPos);

            // setting the postition markers for the camera
            gameObject.transform.position = center;
        }

        //--------------------------------------------------------------------------------------------------------

        /* Changes the camera to Player2 */
        else if (player2.turnCheck == true && Bullet.IsDestroyed == true)
        {
            // updating camera checks to be in the appropriet position
            cameraCheck1 = false;
            cameraCheck2 = true;

            // setting the current position of the tank
            xPos = player2.transform.position.x + 5;
            yPos = 3;
            zPos = transform.position.z;

            // inputing the position variable into a vector for quick input

            // setting the postion of the camera with the vector
            center = new Vector3(xPos, yPos, zPos);
            gameObject.transform.position = center;
            // Need to add a varialbe to change the size of the camera to 4
        }

        //-----------------------------------------------------------------------------------------------------

        /* Changes camera to the projectile */
        else if (Bullet.IsDestroyed == false && player1.turnCheck == false && player2.turnCheck == false)
        {
            // setting both camera checks as false so the bullet is the object being followed 
            cameraCheck1 = false;
            cameraCheck2 = false;

            // updating the position of the bullet
            xPos = Bullet.transform.position.x;
            yPos = Bullet.transform.position.y;
            zPos = transform.position.z;

            // creating a vector for the position markers
            center = new Vector3(xPos, yPos, zPos);
            
            // setting the camera to the vector location
            gameObject.transform.position = center;
        }

        /*
        //calcScreen(tank1, tank2);
        float width = xR - xL;
        if (width > wScene)
        {
            Vector3 change = new Vector3(transform.position.x, transform.position.y, zCam * width / wScene + z0);
            transform.position = change;
        }

        Vector3 center = new Vector3((xR + xL) / 2, transform.position.y, transform.position.z);
        transform.position = center;
        */

    } // end void update

} // end of CameraPan class
