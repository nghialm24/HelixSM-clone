using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HelixManager : MonoBehaviour
{
    [SerializeField] GameObject[] helixRings;
    [SerializeField] Image[] backGround;

    Vector3 ySpawn = new Vector3(0, -7, 53);

    void Start()
    {
        SpawnRing();
    }

    public void SpawnRing()
    {
        int index = Random.Range(0, helixRings.Length);
        Instantiate(helixRings[index], transform.up + ySpawn, Quaternion.identity);
        backGround[index].gameObject.SetActive(true);
    }
}
