using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDoor : MonoBehaviour
{
    [SerializeField] private Key.KeyType KeyType;

    public Key.KeyType GetKeyType()
    {
        return KeyType; 
    }

    public void OpenDoor()
    {
        gameObject.SetActive(false);
        

    }
}
