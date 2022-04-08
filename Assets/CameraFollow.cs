using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    private Vector3 offset;
    private Vector3 min;
    private void Start()
    {
        offset = transform.position - target.position;
        min = target.position;
    }

    private void Update()
    {
        if (target.position.y < min.y)
        {
            min = target.position;
        }
        Vector3 newPosition = min + offset;
        transform.position = newPosition;
    }
}
