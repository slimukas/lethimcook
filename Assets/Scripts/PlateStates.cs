using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateStates : MonoBehaviour
{
    [SerializeField] private Material clean;
    [SerializeField] private Material dirty;
    [SerializeField] private GameObject holder;

    public bool isClean;

    private void Awake()
    {
        CheckPlacable();
    }

    private void CheckPlacable()
    {
        if (isClean == true)
        {
            holder.SetActive(true);
        }
        else
        {
            holder.SetActive(false);
        }
    }

    public void Clean()
    {
        if (isClean == false)
        {
            this.gameObject.GetComponent<Renderer>().material = clean;
            gameObject.name = "CleanPlate";
            isClean = true;
            CheckPlacable();
        }
    }

    public void Dirty()
    {
        if (isClean == true)
        {
            foreach (Transform child in holder.transform)
            {
                GameObject.Destroy(child.gameObject);
            }

            this.gameObject.GetComponent<Renderer>().material = dirty;
            gameObject.name = "DirtyPlate";
            isClean = false;
            CheckPlacable();
        }

    }

}
