using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform bar;
    void Start()
    {
        Transform bar = transform.Find("Bar");
        //bar.localScale = new Vector3(.4f, 1f);

    }
   public void setSize (float sizeNormalized)
    {
        bar.localScale = new Vector3(sizeNormalized, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
