using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        rotation();
    }
    void rotation()
    {
        transform.Rotate(new Vector3(0, 0, 100 * Time.deltaTime));
    }
}
