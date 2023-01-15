using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderTicket : MonoBehaviour
{
    [SerializeField] private CustomerOrder ingredient;
    [SerializeField] private GameObject orderTicket;
    private SpriteRenderer ticketSprite;
    private Sprite orderSprite;

    //THINK OF A BETTER WAY!
    public void GenerateTicket()
    {
        for (int i = 0; i < orderTicket.transform.childCount; i++)
        {
            ticketSprite = orderTicket.transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>();
            ticketSprite.sprite = null;
        }
        for (int i = 0; i < ingredient.order.Count; i++)
        {

            ticketSprite = orderTicket.transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>();
            orderSprite = ingredient.order[i].gameObject.GetComponent<IngredientParam>().ingredientImage;
            Debug.Log(ticketSprite + " - " + orderSprite);

            ticketSprite.sprite = orderSprite;
            Debug.Log(ticketSprite + " -- " + orderSprite);

        }
        Instantiate(orderTicket, transform.position, Quaternion.identity);


    }
}
