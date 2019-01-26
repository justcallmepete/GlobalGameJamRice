using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Simba : MonoBehaviour {
    public GameObject player;
    float health = 10;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(player.transform);
        transform.position = new Vector3(transform.position.x,-0.003662109f,transform.position.z);
        if (health <= 5)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, .1f);
        }
        if (health <= 0)
        {
            
            //Destroy(gameObject);
        }
	}
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Bolt")
        {
            health -= 5;
            Debug.Log(health);
        }
    }
}
