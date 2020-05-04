using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerRun : MonoBehaviour
{
    private string laneChange = "no";
    private string jumping = "no";
    public static Vector3 charPos;
    public static bool dead = false;
    void Start()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 3);
    }


    void Update()
    {
        charPos = transform.position;

        if (Input.GetKey("a") && laneChange == "no" && jumping == "no" && transform.position.x>-1.9)
        {
            GetComponent<Rigidbody>().velocity = new Vector3(-1, 0, 3);
            laneChange = "yes";
            StartCoroutine(stopLaneChange());
        }

        if (Input.GetKey("d") && laneChange == "no" && jumping == "no" && transform.position.x < 1.9)
        {
            GetComponent<Rigidbody>().velocity = new Vector3(1, 0, 3);
            laneChange = "yes";
            StartCoroutine(stopLaneChange());
        }

        if (Input.GetKey("space") && jumping == "no" && laneChange == "no")
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0, 2, 3);
            GameObject.Find("_cyborg_base").GetComponent<Animator>().Play("jump_complete");
            jumping = "yes";
            StartCoroutine(stopJump());
        }

        IEnumerator stopJump()
        {
            yield return new WaitForSeconds(.75f);
            GetComponent<Rigidbody>().velocity = new Vector3(0, -2, 3);
            yield return new WaitForSeconds(.75f);
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 3);
            jumping = "no";
        }
    }

    IEnumerator stopLaneChange()
    {
        yield return new WaitForSeconds(1);
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 3);
        laneChange = "no";
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Obstacle")
        {
            GameObject.Find("Main Camera").GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            GameObject.Find("_cyborg_base").GetComponent<Animator>().Play("death");
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            StartCoroutine(Death());
            


        }

        if (other.tag == "Ramp")
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0, 3, 3);
        }

        if (other.tag == "DropZone")
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0, -3, 3);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Ramp")
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 3);
        }

        if (other.tag == "DropZone")
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 3);
        }
    }

    IEnumerator Death()
    {
        yield return new WaitForSeconds(3);
        dead = true;
        SceneManager.LoadScene(2);

    }
}
