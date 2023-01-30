using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject customerPrefab;
    [SerializeField] private Transform spawnPoint;

    void Start()
    {
        Debug.Log(transform.childCount);
    }

    void Update()
    {
        if (transform.childCount < 2)
        {
            GameObject instance = Instantiate(customerPrefab, spawnPoint.transform.position, Quaternion.identity);
            instance.transform.parent = transform;
        }
    }

}
