using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour
{
    public bool isInZone = false;
    [SerializeField]
    private float currentFuel = 50f;
    private float maxFuel = 100f;
    private float decaySpeed = .1f;

    void Update()
    {
        GainFuel();
        LoseFuel();
    }

    void LoseFuel()
    {
        if (isInZone) return;

        currentFuel -= 1 * Time.deltaTime * decaySpeed;
    }

    public void GainFuel()
    {
        if (!isInZone) return;

        if (currentFuel < maxFuel)
        {
            currentFuel++;
            if (currentFuel > maxFuel)
                currentFuel = maxFuel;
        }   
    }
}
