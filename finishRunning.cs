using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finishRunning : MonoBehaviour
{
    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(-3 * Time.fixedDeltaTime, 0, 0);
    }
}
