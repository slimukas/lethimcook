using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OrderTicket : MonoBehaviour
{
    [SerializeField] private CustomerOrder ingredient;
    [SerializeField] private GameObject orderTicket;
    [SerializeField] private Transform ticketPosition;
    [SerializeField] private TMP_Text ticketNumber;

    private SpriteRenderer ticketSprite;
    private Sprite orderSprite;

    //THINK OF A BETTER WAY!
    public void GenerateTicket()
    {
        ticketNumber = orderTicket.transform.GetChild(orderTicket.transform.childCount - 1).GetChild(0).GetComponent<TMP_Text>();
        ticketNumber.text = ingredient.orderTicketNumber.ToString();
        Debug.Log(orderTicket.transform.childCount + " ====" + (orderTicket.transform.childCount - 1));

        for (int i = 0; i < orderTicket.transform.childCount - 1; i++)
        {
            ticketSprite = orderTicket.transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>();
            ticketSprite.sprite = null;
        }
        for (int i = 0; i < ingredient.order.Count; i++)
        {

            ticketSprite = orderTicket.transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>();
            orderSprite = ingredient.order[i].gameObject.GetComponent<IngredientParam>().ingredientImage;
            // Debug.Log(ticketSprite + " - " + orderSprite);

            ticketSprite.sprite = orderSprite;
            // Debug.Log(ticketSprite + " -- " + orderSprite);

        }
        Instantiate(orderTicket, new Vector3(ticketPosition.position.x, ticketPosition.position.y + 0.5f, ticketPosition.position.z), Quaternion.identity);


    }
}
