using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingArrows : MonoBehaviour
{

    public Rigidbody arrow;
    AudioSource arrowShot;
    public float speed = 2f;
    public int stock = 1;

    private void Start()
    {
        arrowShot = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && stock == 1) {
            Shoot();
        }
        if (stock == 0 && Input.GetKeyDown(KeyCode.R)) {
            StartCoroutine("Reload");
            stock = 1;
        }
}
    

    void Shoot()
    {
        Rigidbody clone;
        clone = Instantiate(arrow, transform.position + new Vector3(0,0.2f,0), transform.rotation);
        clone.velocity = transform.TransformDirection(Vector3.forward * 50);
        arrowShot.Play();
        stock--;
    }
    IEnumerator Reload()
    {
        yield return new WaitForSeconds(2);
       
        yield return null;
    }
}
