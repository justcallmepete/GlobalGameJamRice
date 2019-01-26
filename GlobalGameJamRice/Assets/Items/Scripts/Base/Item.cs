using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

	// pickuppable
    //torch, can, gas canister, pan, Christmas lights, platenspeler, radio, 
    public Sprite sprite;

    public Vector3 positionInHands;


     public virtual void Use() { }
}
