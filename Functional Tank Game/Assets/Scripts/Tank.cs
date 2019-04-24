using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour
{
    float speed = 5.0f;
    int zAngle = 1;
    float projectilespeed = 125;
    public GameObject TurretRotation;

    public Rigidbody2D projectile;
    public GameObject Emitter;

    private bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        /*
         * Next if statements are for tank sprite movement
         * 
         */
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
        }

        //
        // This code should make the Turret Rotate
        //
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (zAngle <= 180)
            {
                TurretRotation.transform.Rotate(0, 0, 1);
                ++zAngle;
            }
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            if(zAngle > 0)
            {
                TurretRotation.transform.Rotate(0, 0, -1);
                --zAngle;
            }
        }

        //
        // This code is for the tank to shoot
        //
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            Rigidbody2D iP = Instantiate(projectile, Emitter.transform.position, Emitter.transform.rotation) as Rigidbody2D;
            iP.AddForce(Emitter.transform.right * projectilespeed);
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (projectilespeed <= 250)
                projectilespeed += 25;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if(projectilespeed >= 0)
                projectilespeed -= 25;
        }
        //
        // The Below code is commented out due to the fact that it adds up and down movement to the tank,
        // which is not needed for this game.
        //

        /*
        if (Input.GetKey(KeyCode.DownArrow))
        {
          transform.position += Vector3.down * speed * Time.deltaTime;
        }
        */


    } // end void update
} // end class
