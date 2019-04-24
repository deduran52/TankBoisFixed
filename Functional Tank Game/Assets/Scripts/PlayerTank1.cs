using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTank1 : MonoBehaviour
{
    /* Private Variables */
    Transform target;
    PlayerTank2 opponentScript;

    /* Turn Variable */
    public bool turnCheck;
    public bool movementComplete;
    public float turnTime = 10;

    /* Player Variables */
    public GameObject player;
    public float tankSpeed = 5.0f;
    public float startHealth = 100;
    public float currentHealth;
    public Image healthBar;

    /* Projectile Variable */
    public Rigidbody2D projectile;
    public GameObject projectileEmitter;
    public float projectileSpeed = 250;
    public float impactDelay = 1;
    public float bulletDamage = 10;
    public bool firedProjectile;

    /* Turret Rotation */
    public GameObject turretRotation;
    public int turretAngle = 1;

    /* Destroyed Tank Flag */
    public bool isDestroyed;
    
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("PlayerTank2").transform;
        opponentScript = GameObject.FindWithTag("PlayerTank2").GetComponent<PlayerTank2>();

        currentHealth = startHealth;

        isDestroyed = false;

    }

    // Update is called once per frame
    void Update()
    {
        /* Movement Complete */
        /*
        if (turnCheck == true && (Input.GetKey(KeyCode.A) == true || Input.GetKey(KeyCode.D) == true || Input.GetKey(KeyCode.LeftArrow) == true || Input.GetKey(KeyCode.RightArrow) == true))
        {
            turnTime -= Time.deltaTime;
            if (turnTime == 0)
                movementComplete = true;
        }
        */

        /* Movement Controls */
        if (Input.GetKey(KeyCode.A) && turnCheck)
        {
            transform.position += Vector3.left * tankSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.D) && turnCheck)
        {
            transform.position += Vector3.right * tankSpeed * Time.deltaTime;
        }

        /* Turret Controls */
        else if (Input.GetKey(KeyCode.LeftArrow) && turnCheck)
        {
            if (turretAngle <= 180)
            {
                turretRotation.transform.Rotate(0, 0, 1);
                ++turretAngle;
            }
        }
        else if (Input.GetKey(KeyCode.RightArrow) && turnCheck)
        {
            if (turretAngle > 0)
            {
                turretRotation.transform.Rotate(0, 0, -1);
                --turretAngle;
            }
        }

        /* Cannon Controls */
        else if (Input.GetKeyDown(KeyCode.Space) && turnCheck)
        {
            Rigidbody2D iP = Instantiate(projectile, projectileEmitter.transform.position, projectileEmitter.transform.rotation) as Rigidbody2D;
            iP.AddForce(projectileEmitter.transform.right * projectileSpeed);
            firedProjectile = true;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) && turnCheck)
        {
            if (projectileSpeed < 1000)
                projectileSpeed += 25;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && turnCheck)
        {
            if (projectileSpeed > 0)
                projectileSpeed -= 25;
        }
        
        
    }

    /* Damage Detection */
    void OnCollisionEnter2D(Collision2D coll)
    {
        /*
         * This may not be needed at the moment !! Do not delete yet !!
         * 
        if (coll.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        */
        if (coll.gameObject.CompareTag("Bullet"))
        {
            currentHealth = currentHealth - bulletDamage;
            //healthBar.setSize(currentHealth / 10);
            if (currentHealth == 0)
            {
                Destroy(gameObject);
                isDestroyed = true;
            }
        }

    }
}
