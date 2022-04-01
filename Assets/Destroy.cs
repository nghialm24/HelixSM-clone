using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    GameObject sphere;

    private Vector3 breakLeft = new Vector3(-30f, 0f, 0f);
    private Vector3 breakRight = new Vector3(30f, 0f, 0f);
    [SerializeField] float rotY;

    private void Start()
    {
        sphere = GameObject.Find("Sphere");
    }
    private void FixedUpdate()
    {
        rotY = transform.eulerAngles.y + transform.parent.eulerAngles.y;
        if(rotY >= 360)
        {
            rotY -= 360;
        }
    }
    private void LateUpdate()
    {
        if (transform.position.x != 0 || transform.position.y >= sphere.transform.position.y)
        {
            //if (180 < rotY && rotY <= 360)
            //{
                Vector3 targetPoint = transform.position + breakLeft;
                gameObject.transform.position = Vector3.MoveTowards(transform.position, targetPoint, 50 * Time.deltaTime);
            //}
            //else
            //{
            //    Vector3 targetPoint2 = transform.position + breakRight;
            //    gameObject.transform.position = Vector3.MoveTowards(transform.position, targetPoint2, 50 * Time.deltaTime);
            //}
            Destroy(gameObject, 2);
        }
        
    }
}
