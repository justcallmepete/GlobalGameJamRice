using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickuppable : MonoBehaviour {

	// raycast op die bitches
    // outline on/off
    // e to pickup
    private Item item;

    void Start()
    {
        item = GetComponent<Item>();
    }

    public Item Pickup()
    {
        Destroy(this);
        return item;
    }
}
