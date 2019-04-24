using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //NOTE: Start() runs even before anyone connects to a server
    }
    
    public float timeLeft = 180;
    // Update is called once per frame
    void Update()
    {

        //FOR NOW we just reset the map/players every 3 minutes
        timeLeft -= Time.deltaTime;
        if(timeLeft <= 0)
        {
            //restart the match
        }//end if
    }//end update
}
