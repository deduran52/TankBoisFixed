using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTank2 : MonoBehaviour
{
    /* Private Variables */
    //Transform target;
    //PlayerTank1 opponentScript;

    /* Player Healt */
    public float startHealth = 100;
    public float currentHealth;
    public Image healthBar;

    /* Turn Variable */
    public bool turnCheck;
    public bool movementComplete;
    public float turnTime = 10;

    /* Player Variables */
    public GameObject player;
    public float tankSpeed = 5.0f;

    /* Projectile Variable */
    public Rigidbody2D projectile;
    public GameObject projectileEmitter;
    public float projectileSpeed = 250;
    public float impactDelay;
    public float bulletDamage = 10;
    public float explosionDamage = 5;
    public bool firedProjectile;

    /* Turret Rotation */
    public GameObject turretRotation;
    public int turretAngle = 1;

    /* Destroyed Tank Flag */
    public bool isDestroyed;

    /* Reset Variables */
    Vector3 reset = new Vector3(0, 0, 1);

    // Start is called before the first frame update
    void Start()
    {
        //target = GameObject.FindWithTag("PlayerTank1").transform;
        //opponentScript = GameObject.FindWithTag("PlayerTank1").GetComponent<PlayerTank1>();

        /* Player Health */
        currentHealth = startHealth;

        isDestroyed = false;

    }

    // Update is called once per frame
    void Update()
    {

        /* Movement Controls */
        if (Input.GetKey(KeyCode.A) && turnCheck)
        {
            transform.position += Vector3.left * tankSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.D) && turnCheck)
        {
            transform.position += Vector3.right * tankSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.Joystick3Button0) && turnCheck)
        {
            transform.position += Vector3.left * tankSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.Joystick3Button2) && turnCheck)
        {
            transform.position += Vector3.right * tankSpeed * Time.deltaTime;
        }

        /* Reset Key control */
         if(Input.GetKey(KeyCode.R) && turnCheck)
         {
            transform.rotation = Quaternion.Euler(reset);
         }

        /* Turret Controls */
        else if (Input.GetKey(KeyCode.LeftArrow) && turnCheck)
        {
            if (turretAngle > 0)
            {
                turretRotation.transform.Rotate(0, 0, 1);
                --turretAngle;
            }
        }
        else if (Input.GetKey(KeyCode.RightArrow) && turnCheck)
        {
            if (turretAngle <= 180)
            {
                turretRotation.transform.Rotate(0, 0, -1);
                ++turretAngle;
            }
        }

        else if (Input.GetKey(KeyCode.Joystick3Button1) && turnCheck)
        {
            if (turretAngle > 0)
            {
                turretRotation.transform.Rotate(0, 0, 1);
                --turretAngle;
            }
        }
        else if (Input.GetKey(KeyCode.Joystick3Button3) && turnCheck)
        {
            if (turretAngle <= 180)
            {
                turretRotation.transform.Rotate(0, 0, -1);
                ++turretAngle;
            }
        }

        /* Cannon Controls */
        else if (Input.GetKeyDown(KeyCode.Space) && turnCheck)
        {
            Rigidbody2D iP = Instantiate(projectile, projectileEmitter.transform.position, projectileEmitter.transform.rotation) as Rigidbody2D;
            iP.AddForce(-projectileEmitter.transform.right * projectileSpeed);
            firedProjectile = true;
        }

        else if (Input.GetKeyDown(KeyCode.Joystick3Button7)) //&& turnCheck)
        {
            Rigidbody2D iP = Instantiate(projectile, projectileEmitter.transform.position, projectileEmitter.transform.rotation) as Rigidbody2D;
            iP.AddForce(-projectileEmitter.transform.right * projectileSpeed);
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

        else if (Input.GetKeyDown(KeyCode.Joystick3Button5) && turnCheck)
        {
            if (projectileSpeed < 1000)
                projectileSpeed += 25;
        }
        else if (Input.GetKeyDown(KeyCode.Joystick3Button4) && turnCheck)
        {
            if (projectileSpeed > 0)
                projectileSpeed -= 25;
        }

    }
    public GameObject explosion; // drag your explosion prefab here
    /* Damage Detection */
    void OnCollisionEnter2D(Collision2D coll)
    {
        /*
         * This may not be needed at the moment !! Do not delete yet !!
         * 
         * May need to work on this chunk so that it is the same as PlayerTank1
         * 
        if (coll.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        */
        if (coll.gameObject.CompareTag("Bullet"))
        {
            currentHealth = currentHealth - bulletDamage;
            healthBar.fillAmount = currentHealth / startHealth;
            if (currentHealth == 0)
                Destroy(gameObject);

        }
        else if (coll.gameObject.CompareTag("Explosion"))
        {
            currentHealth = currentHealth - explosionDamage;
            healthBar.fillAmount = currentHealth / startHealth;
            if (currentHealth == 0)
            {
                Destroy(gameObject);
                isDestroyed = true;
            }
        }
    }
}
