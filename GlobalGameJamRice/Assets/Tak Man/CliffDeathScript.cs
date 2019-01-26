using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CliffDeathScript : MonoBehaviour {

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.GetComponent<Movement>())
        {
            collision.gameObject.transform.localPosition = new Vector3(-.25f, 5f, 0.5f);
        }
    }
}
