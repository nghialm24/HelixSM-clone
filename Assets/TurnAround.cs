using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnAround : MonoBehaviour
{
    GameObject sphere;

    private void Awake()
    {
        sphere = GameObject.Find("Sphere");

    }
    void Update()
    {
        if (!sphere.activeSelf)
        {
            transform.Rotate(0, 0, 0);
        }
        else if (transform.position.x == 0)
            transform.Rotate(0, 90 * Time.deltaTime, 0);
    }
}
