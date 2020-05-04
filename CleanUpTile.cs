using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanUpTile : MonoBehaviour
{
    
    void Start()
    {
        
    }

    
    void Update()
    {
        if (transform.position.z < PlayerRun.charPos.z - 6)
        {
            Destroy(gameObject);
        }
    }
}
