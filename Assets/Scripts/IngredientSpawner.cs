using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientSpawner : MonoBehaviour
{
    [SerializeField] private GameObject ingredient;
    [SerializeField] private Transform spawnPosition;

    public void Spawn()
    {
        var newObj = Instantiate(ingredient, spawnPosition);
        newObj.transform.localPosition = Vector3.zero;
        newObj.transform.localScale = Vector3.one;
    }
}
