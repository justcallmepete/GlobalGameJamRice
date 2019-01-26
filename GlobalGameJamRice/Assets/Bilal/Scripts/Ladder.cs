using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("MainCamera"))
        {
            other.GetComponent<Movement>().onLadder = true;
        }

    }
    private void OnTriggerExit(Collider other)
    {
        other.GetComponent<Movement>().onLadder = false;
    }
}