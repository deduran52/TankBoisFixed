using UnityEngine;


public class CameraPan : MonoBehaviour
{
    /* Variable to dectect whos turn it is */
    PlayerTank1 player1;
    PlayerTank2 player2;
    ProjectileCollision Bullet;
    MatchScript match;

    /* Camera variables */
    public Camera player1Camera;
    public Camera player2Camera;
    public Camera bulletCamera;

    /* Variables to get the position of the player objects */
    Transform tank1;
    Transform tank2;

    /* Variable to hold the position for the player objects and the bullet objects */
    float xPos;                // x position
    float yPos;                // y position
    float zPos;                // z position

    /* Check variables */
    public bool cameraCheck1 = false;
    public bool cameraCheck2 = false;

    /* Delay variable */
    public float baseTimer = 5;
    public float timer1;
    public float timer2;
    

    /*---------------------------------------------------------------*/

    void Start()
    {
        /* This is instantiating the tank objects as an accesable variable */
        player1 = GameObject.FindWithTag("PlayerTank1").GetComponent<PlayerTank1>();
        player2 = GameObject.FindWithTag("PlayerTank2").GetComponent<PlayerTank2>();

        /* this is instantiating the bullet object as an accesable variable */
        //Bullet = GameObject.FindWithTag("Bullet").GetComponent<ProjectileCollision>();            

        /* instantiating the match script as a variable */
        match = GameObject.FindWithTag("GameController").GetComponent<MatchScript>();

        /* Instatiating variables to access the postitions of the tanks */
        tank1 = GameObject.FindWithTag("PlayerTank1").transform;
        tank2 = GameObject.FindWithTag("PlayerTank2").transform;

        /* setting the projectile timers */
        timer1 = baseTimer;
        timer2 = baseTimer;

    } // end void start

    //-------------------------------------------------------------------------------------------------------------------------------

    void Update()
    {
        /* Need to up Date every scene since the bullet is not created until it is fired */
        Bullet = GameObject.FindWithTag("Bullet").GetComponent<ProjectileCollision>();         // Having a hard time determining wheather the object exist or not

        //---------------------------------------------------------------------------------------------------

        
        /* Changes camera to the projectile */
        if (Bullet.IsDestroyed == false)
        {
            bulletCamera.enabled = true;                             // Need to change the camera from enabled to something else that will determine
            player1Camera.enabled = false;                           // wheather the camera is on or not.
            player2Camera.enabled = false;                           // this line aslo needs to be changed.

            /* Getting the position for the bullet */
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
            /* setting the player camera to true */
            if(player1.turnCheck)
            {
                player1Camera.enabled = true;
                player2Camera.enabled = false;
                bulletCamera.enabled = false;
            }

            /* setting the player camera to true */
            else if(player2.turnCheck)
            {
                player1Camera.enabled = false;
                player2Camera.enabled = true;
                bulletCamera.enabled = false;
            }
        }
        
    } // end void update

} // end of CameraPan class
