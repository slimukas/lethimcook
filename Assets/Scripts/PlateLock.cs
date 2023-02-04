using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateLock : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Placable")
        {
            this.transform.parent = other.transform;
            this.GetComponent<BoxCollider>().enabled = false;
            this.GetComponent<Rigidbody>().isKinematic = true;
            this.transform.localPosition = new Vector3(0, 0, 0);
            this.transform.localRotation = new Quaternion(0, 0, 0, 0);
            this.transform.parent = null;
        }
    }



}
