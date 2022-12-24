using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballrespawm : MonoBehaviour
{
    private Vector3 respawnPoint;
    public void Start()
    {
        respawnPoint = transform.position;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            transform.position = respawnPoint;
        }
    }
}
