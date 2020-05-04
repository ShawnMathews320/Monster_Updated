using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinControl : MonoBehaviour
{
    
    void Start()
    {
        
    }

    
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Character")
        {
            GameFlow.totalCoins += 1;
            Destroy(gameObject);
            Debug.Log(GameFlow.totalCoins);
        }
    }
    
}
