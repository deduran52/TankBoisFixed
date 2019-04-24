using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundBehavior : MonoBehaviour
{

    public Rigidbody2D Terrain1;
    public Rigidbody2D Terrain2;
    

    public float delay;
    public bool determineSpawn;
    
    // Use this for initialization
    void Start()
    {
        //StartCoroutine("DoCheck");
        Instantiate(Terrain1);
        Instantiate(Terrain2);

    }

    private void Update()
    {

    }

    IEnumerator DoCheck()
    {
        for (int x = 0; x < 20; x++)
        {
            determineSpawn = true;
            //determineSpawn = randomSpawn();
            if (determineSpawn == true)
            {
                //Rigidbody2D iP = Instantiate(Terrain, transform.position, transform.rotation) as Rigidbody2D;
            }
            yield return new WaitForSeconds(delay);
            determineSpawn = false;
            yield return new WaitForSeconds(delay);
        }
    }
    /*
    bool randomSpawn()
    {
        System.Random ran = new System.Random();
        int i = ran.Next(0, 3);
        bool temp = false;

        if (i == 0)
        {
            temp = true;
        }
        else if (i == 1)
        {
            temp = false;
        }
        else if (i == 2)
        {
            temp = true;
        }
        else if (i == 3)
        {
            temp = false;
        }

        return temp;
    }
    */


}