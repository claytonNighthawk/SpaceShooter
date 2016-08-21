using UnityEngine;
using System.Collections;

public class DestroyByBountry : MonoBehaviour {

    void OnTriggerExit(Collider other) {
        Destroy(other.gameObject);
    }
}
