using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject customerPrefab;
    [SerializeField] private bool canSpawn;
    public Transform spawnPoint;


    private void Awake()
    {
        canSpawn = false;
        Game.Current.room.OnDoorOpened += Spawn;
    }
    private void Spawn()
    {
        canSpawn = true;
    }

    private void Update()
    {
        if (transform.childCount < 2 && canSpawn)
        {
            GameObject instance = Instantiate(customerPrefab, spawnPoint.transform.position, Quaternion.identity);
            instance.transform.parent = transform;
            instance.gameObject.SetActive(true);

        }
    }

}
