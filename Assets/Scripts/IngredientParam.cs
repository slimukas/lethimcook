using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientParam : MonoBehaviour
{
    [Header("Ingredient parameters")]
    public float height;

    public float topPivot;
    public float bottomPivot;

    public string id;
    public Sprite ingredientImage;

    public bool canDelete;
}
