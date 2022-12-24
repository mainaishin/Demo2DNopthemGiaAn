using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grounddestroy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == "Animalrall")
        {
            Destroy(target.gameObject);
        }
    }
}
