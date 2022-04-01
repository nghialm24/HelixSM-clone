using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnAround : MonoBehaviour
{
    void Update()
    {
        if (transform.position.x == 0)
            transform.Rotate(0, 80 * Time.deltaTime, 0);
    }
}
