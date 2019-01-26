using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : MonoBehaviour {

    public string requiredKeyName;

	public void Unlock(string keyName)
    {
        Debug.Log("attempting to unlock " + gameObject.name + " with " + keyName);
        if (requiredKeyName.Equals(keyName))
        {
            gameObject.SetActive(false);
        }
    }
}
