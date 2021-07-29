using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{

    [SerializeField] private KeyType keyType;

    public enum KeyType
    {
        None,
        Key1,
        Key2,
        Key3,
        Key4
    }

    public KeyType GetKeyType()
    {
        return keyType;
    }

}