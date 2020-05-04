using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFlow : MonoBehaviour
{
    public Transform tileObj;
    private Vector3 nextTileSpawn;
    public Transform barrierCubeObj;
    private Vector3 nextBarrierCubeSpawn;
    private int randX;
    private int randObj;
    private int randRamp;
    public static int totalCoins = 0;

    public Transform barrierCylinderObj;
    private Vector3 nextBarrierCylinderSpawn;

    public Transform barrierHedraObj;
    private Vector3 nextBarrierHedraSpawn;

    public Transform barrierTetraObj;
    private Vector3 nextBarrierTetraSpawn;

    public Transform rockSpawnObj;
    private Vector3 nextRockSpawn;

    public Transform coinObj;
    private Vector3 nextCoinSpawn;
    
    public Transform rampObj;
    private Vector3 nextRampSpawn;

    void Start()
    {
        if (PlayerRun.dead == false)
        {
            nextTileSpawn.z = 21;
            StartCoroutine(spawnTile());
        }
        else
        {
            nextTileSpawn.z = 18;
            Instantiate(GameObject.Find("Tile"), new Vector3(0, 0, 12), Quaternion.Euler(0, 0, 0));
            Instantiate(GameObject.Find("Tile (6)"), new Vector3(0, 0, 15), Quaternion.Euler(0, 0, 0));
            Instantiate(GameObject.Find("Tile"), new Vector3(0, 0, 9), Quaternion.Euler(0, 0, 0));
            Instantiate(GameObject.Find("Tile (6)"), new Vector3(0, 0, 6), Quaternion.Euler(0, 0, 0));
            Instantiate(GameObject.Find("Tile"), new Vector3(0, 0, 3), Quaternion.Euler(0, 0, 0));
            Instantiate(GameObject.Find("Tile"), new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0));
            StartCoroutine(spawnTile());
            GameObject.Find("Main Camera").GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 3);
        }

    }

    
    void Update()
    {
        
    }

    IEnumerator spawnTile()
    {
        yield return new WaitForSeconds(1);
        randX = Random.Range(-2, 3);
        randRamp = Random.Range(0, 11);

        if (randRamp != 10)
        {
            nextBarrierCubeSpawn = nextTileSpawn;
            nextBarrierCubeSpawn.x = randX;
            nextBarrierCubeSpawn.y = 0.506f;
            Instantiate(tileObj, nextTileSpawn, tileObj.rotation);
            Instantiate(barrierCubeObj, nextBarrierCubeSpawn, barrierCubeObj.rotation);
        }

        if (randRamp == 10)
        {
            nextRampSpawn = nextTileSpawn;
            nextRampSpawn.x = Random.Range(-2, 2);
            nextRampSpawn.y = 0;
            Instantiate(tileObj, nextTileSpawn, tileObj.rotation);
            Instantiate(rampObj, nextRampSpawn, rampObj.rotation);
        }

        else if (randX == -2)
        {
            randX = 2;
        }
        else if (randX == -1)
        {
            randX = -2;
        }
        else if (randX == 0)
        {
            randX = 1;
        }
        else if (randX == 1)
        {
            randX = -1;
        }
        else if (randX == 2)
        {
            randX = 0;
        }

        randObj = Random.Range(0,8);

        if (randObj == 0 && randRamp != 10)
        {
            nextBarrierHedraSpawn.z = nextTileSpawn.z;
            nextBarrierHedraSpawn.y = 0.52171f;
            nextBarrierHedraSpawn.x = randX;
            Instantiate(barrierHedraObj, nextBarrierHedraSpawn, barrierHedraObj.rotation);
        }
        else if (randObj == 1)
        {
            nextBarrierCubeSpawn.z = nextTileSpawn.z;
            nextBarrierCubeSpawn.y = 0.506f;
            nextBarrierCubeSpawn.x = randX;
            Instantiate(barrierCubeObj, nextBarrierCubeSpawn, barrierCubeObj.rotation);
        }
        else if (randObj == 2)
        {
            nextBarrierCylinderSpawn.z = nextTileSpawn.z;
            nextBarrierCylinderSpawn.y = 0.52664f;
            nextBarrierCylinderSpawn.x = randX;
            Instantiate(barrierCylinderObj, nextBarrierCylinderSpawn, barrierCylinderObj.rotation);
        }
        else if (randObj == 3)
        {
            nextBarrierTetraSpawn.z = nextTileSpawn.z;
            nextBarrierTetraSpawn.y = 0.5f;
            nextBarrierTetraSpawn.x = randX;
            Instantiate(barrierTetraObj, nextBarrierTetraSpawn, barrierTetraObj.rotation);
        }
        else if (randObj == 4)
        {
            nextRockSpawn.z = nextTileSpawn.z;
            nextRockSpawn.y = 0.795f;
            nextRockSpawn.x = randX;
            Instantiate(rockSpawnObj, nextRockSpawn, rockSpawnObj.rotation);
        }
        else if (randObj == 5 || randObj == 6 || randObj == 7)
        {
            nextCoinSpawn.z = nextTileSpawn.z;
            nextCoinSpawn.y = 1.1f;
            nextCoinSpawn.x = randX;
            Instantiate(coinObj, nextCoinSpawn, coinObj.rotation);
        }

        nextTileSpawn.z += 3;
        StartCoroutine(spawnTile());
    }
}