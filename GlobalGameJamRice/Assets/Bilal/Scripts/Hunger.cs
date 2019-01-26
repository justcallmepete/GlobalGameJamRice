using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Hunger : MonoBehaviour {
    public float hungerBar = 100;
    private float currentHunger = 0;
    public List<HungerActions> actions = new List<HungerActions>();
        
    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        CheckForMovement();
        DrainHunger();
    }

    public void CheckForMovement()
    {
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            actions[1].isAction = true;
            if(Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            {   
                actions[2].isAction = true;
            }
            else
                
                actions[2].isAction = false;
        }

        else
        {
            actions[1].isAction = false;
            actions[2].isAction = false;
        }

    }


    public void DrainHunger()
    {
        
        foreach (HungerActions ha in actions)
        {
            if (ha.isAction)
                hungerBar -= (ha.drainHunger / 100);  
        }
    }

    [System.Serializable]

    public class HungerActions
    {
        public string name;
        public float drainHunger;
        public bool isAction = false;
    }
}
