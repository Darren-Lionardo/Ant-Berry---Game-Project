using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class eggPicker : MonoBehaviour
{
    private float egg = 0;

    public TextMeshProUGUI textegg;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "Egg")
        {
            egg++;
            textegg.text = egg.ToString() + "x";

            Destroy(other.gameObject);
        }
    }
}
