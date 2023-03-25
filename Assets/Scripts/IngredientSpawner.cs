using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientSpawner : MonoBehaviour
{
    [SerializeField] private GameObject ingredient;
    [SerializeField] private Transform spawnPosition;

    public void Spawn()
    {
        Debug.Log("Spawned");
        Instantiate(ingredient, spawnPosition);
    }
}
