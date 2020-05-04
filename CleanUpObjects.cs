using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanUpObjects : MonoBehaviour
{
    
    void Start()
    {
        
    }

    
    void Update()
    {
        if (transform.position.z < PlayerRun.charPos.z - 15)
        {
            Destroy(gameObject);
        }
    }
}
