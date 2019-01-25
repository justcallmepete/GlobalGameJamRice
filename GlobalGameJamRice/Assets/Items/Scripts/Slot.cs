using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{

    public bool isTaken;
    public Sprite sprite;
    public Item item;

    public void SetSprite(Sprite ding)
    {
        sprite = ding;
        GetComponent<Image>().sprite = ding;
    }
}
