using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour {
    
    public GameObject ladder;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float dis = Vector3.Distance(transform.position, ladder.transform.position);
        if (dis < 3 && transform.position.y < 1)
        {
            transform.position = ladder.transform.position;
        }
        
	}
}
