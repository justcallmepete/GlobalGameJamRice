using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public Transform holder;
	public List<Item> playerInventory = new List<Item>();
    public Slot[] slots;
    public int selectedSlot;
    Slot emptySlot;

    void Update()
    {
        ShootRaycast();
    }

    //input for the cursor

    void OnDrawGizmos()
    {
        Vector3 direction = transform.TransformDirection(Vector3.forward * 5);
        Gizmos.DrawRay(transform.position, direction);
    }

    void ShootRaycast()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width/2, Screen.height/2,0));
        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log("Hit: " + hit);
            if (hit.transform.GetComponent<Pickuppable>())
            {
               AddItem(hit.transform.GetComponent<Pickuppable>().Pickup());
            }
        }
    }

    Slot GetSelectedSlot()
    {
        if (selectedSlot < slots.Length && selectedSlot >=0)
        {
            if (slots[selectedSlot].isTaken)
            {
                return slots[selectedSlot];
            }
            return emptySlot;
        }
        else
        {
            Debug.Log("Can't select this slot");
            return emptySlot;
        }
    }

    void AddItem(Item obj)
    {
        playerInventory.Add(obj);
        GameObject temp = obj.transform.gameObject;
        temp.transform.SetParent(holder);
        temp.transform.localPosition = new Vector3(0, 0, 0);
        temp.SetActive(false);

        for (int i = 0; i < slots.Length; i++)
        {
            if (!slots[i].isTaken)
            {
                slots[i].isTaken = true;
                slots[i].SetSprite(obj.sprite);
                slots[i].item = obj;
                Debug.Log("set sprite");
                break;
            }
        }
    }
}
