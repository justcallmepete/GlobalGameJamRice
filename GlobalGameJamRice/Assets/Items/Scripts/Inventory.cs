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
        Scroll();
        if (Input.GetKey(KeyCode.E))
        {
            UseItem();
        }

        if (Input.GetKey(KeyCode.F))
        {
            ShootRaycast();
        }
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
            if (hit.transform.GetComponent<Lock>())
            {
                hit.transform.GetComponent<Lock>().Unlock(GetSelectedSlotItem().name);
            }
        }
    }

    void Scroll()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (selectedSlot < slots.Length)
            {
                selectedSlot++;
            }
            else
            {
                selectedSlot = 0;
            }
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (selectedSlot > 0)
            {
                selectedSlot--;
            }
            else
            {
                selectedSlot = slots.Length;
            }
        }
    }

    void UseItem()
    {
        if (GetSelectedSlotItem() != null)
        {
            GetSelectedSlotItem().Use();
        }
    }

    Item GetSelectedSlotItem()
    {
        if (selectedSlot < slots.Length && selectedSlot >=0)
        {
            if (slots[selectedSlot].isTaken)
            {
                return slots[selectedSlot].item;
            }
        }
        Debug.Log("There's no item in this slot or this slot doesn't exist");
        return null;
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
