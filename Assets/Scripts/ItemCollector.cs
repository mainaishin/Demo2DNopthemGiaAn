using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int money = 0;
    //private int diamond = 0;
    [SerializeField] private Text moneyText;
    [SerializeField] private AudioSource collectionMoneySoundEffect;
    [SerializeField] private Text diamondText;
    [SerializeField] private AudioSource collectionDiamondSoundEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Money"))
        {
            collectionMoneySoundEffect.Play();
            Destroy(collision.gameObject);
            money+=100;
            moneyText.text = "Money: " + money;
        }

        if (collision.gameObject.CompareTag("Diamond"))
        {
            collectionDiamondSoundEffect.Play();
            //Destroy(collision.gameObject);
            //diamond++;
            //diamondText.text = "Diamond: " + diamond;
        }

    }

}
