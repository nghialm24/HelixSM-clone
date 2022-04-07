using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelixRingController : MonoBehaviour
{
    GameObject sphere;
    private Vector3 breakLeft = new Vector3(-30f, 0f, 0f);
    private Vector3 breakRight = new Vector3(30f, 0f, 0f);
    public SphereManager isbreaking;
    [SerializeField] float rotY;

    private void Start()
    {
        sphere = GameObject.Find("Sphere");
        isbreaking = sphere.GetComponent<SphereManager>();
    }
    private void FixedUpdate()
    {
        rotY = transform.eulerAngles.y;
        if (isbreaking.posY == transform.position.y || transform.position.x != 0 || transform.position.y >= sphere.transform.position.y)
        {
            if (180 < rotY && rotY <= 360)
            {
                gameObject.transform.position = Vector3.MoveTowards(transform.position, breakLeft, 50 * Time.deltaTime);
            }
            else
            {
                gameObject.transform.position = Vector3.MoveTowards(transform.position, breakRight, 50 * Time.deltaTime);
            }
            Destroy(gameObject, 2f);
        }
    }
}

