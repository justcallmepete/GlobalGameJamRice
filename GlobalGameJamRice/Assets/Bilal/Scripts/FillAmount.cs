using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillAmount : MonoBehaviour {
  
    public Image cooldown;
    public GameObject player;
    private void Start()
    {
        player.GetComponent<Hunger>();       
    }
    // Update is called once per frame
    void Update()
    {
        Debug.Log(cooldown.fillAmount);
        
            //Reduce fill amount over 30 seconds
            cooldown.fillAmount = player.GetComponent<Hunger>().hungerBar/100;
        
    }
}