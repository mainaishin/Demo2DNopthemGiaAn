using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static float healthAmount;
    // Start is called before the first frame update
    void Start()
    {
        healthAmount = 10;
    }

    // Update is called once per frame
    void Update()
    {
        if (healthAmount <= 0)
            Destroy(gameObject);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("AttackArea"))
            healthAmount -= 2f;
    }
}
