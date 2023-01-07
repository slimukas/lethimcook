using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dish", menuName = "New Dish")]
public class Dish : ScriptableObject
{

    [Header("Available toppings that are not important")]
    public GameObject[] availableIngredients;
    [Header("Max number of toppings")]
    public int maxToppings;

    [Header("Important/mandatory ingredients")]
    [Header("------------------------------------")]
    public PointList importantIngredients = new PointList();


    [Header("Generated order")]
    [Header("------------------------------------")]
    public List<GameObject> order;


}

[System.Serializable]
public class ImportantIngredient
{
    public GameObject ingredient;
    public int priority;

}

[System.Serializable]
public class PointList
{
    public List<ImportantIngredient> importantIngredient;
}