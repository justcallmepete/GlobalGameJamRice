using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch_Refueler : MonoBehaviour
{
    [SerializeField]
    private Torch playerTorch;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //ToDo refill player fuel in script
            playerTorch.isInZone = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //ToDo refill player fuel in script
            playerTorch.isInZone = false;
        }
    }
}
