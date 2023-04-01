using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCan : MonoBehaviour
{
    [SerializeField] private ParticleSystem trashVFX;
    [SerializeField] private Animation trashAnimation;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<IngredientParam>() != null)
        {
            if (other.gameObject.GetComponent<IngredientParam>().canDelete == true)
            {
                GameObject.Destroy(other.gameObject);
                trashVFX.Play();
                trashAnimation.Play();
            }
        }
    }
}
