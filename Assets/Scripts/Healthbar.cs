using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [SerializeField] private PlayerLife playerHealth;
    [SerializeField] private Image totalhealthBar;
    [SerializeField] private Image currenhealthBar;

    private void Start()
    {
        totalhealthBar.fillAmount = playerHealth.currentHealth / 10;
    }

    private void Update()
    {
        currenhealthBar.fillAmount = playerHealth.currentHealth / 10;
    }
}
