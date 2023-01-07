using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientParam : MonoBehaviour
{
    [Header("Ingredient parameters")]
    [SerializeField] private float height;

    public float Height()
    {
        return height;
    }
}
