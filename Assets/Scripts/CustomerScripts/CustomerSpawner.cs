using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject customerPrefab;
    [SerializeField] private bool canSpawn;
    [SerializeField] private float minDelay = 1f;
    [SerializeField] private float maxDelay = 5f;
    public Transform spawnPoint;


    private void Start()
    {
        canSpawn = false;
        Game.Current.room.OnDoorOpened += CanSpawn;

    }
    private void CanSpawn()
    {
        float delay = Random.Range(minDelay, maxDelay);
        Invoke("Spawn", delay);
    }
    private void Update()
    {

    }
    private void Spawn()
    {
        if (transform.childCount < 2)
        {
            GameObject instance = Instantiate(customerPrefab, spawnPoint.transform.position, Quaternion.identity);
            instance.transform.parent = transform;
            instance.gameObject.SetActive(true);
        }
        float delay = Random.Range(minDelay, maxDelay);
        Invoke("Spawn", delay);
    }
}
