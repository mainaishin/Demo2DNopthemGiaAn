using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UiManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI txtKimcuong, txtVictoryCondition;
    [SerializeField] GameObject victoryCondition;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            DestroyImmediate(this);
        }
    }
    private static UiManager instance;

    public static UiManager MyInstance
    {
        get
        {
            if (instance == null)
                instance = new UiManager();
            return instance;

        }
    }
    public void UpdateKimcuongUI(int _kimcuong,int _victoryCondition)
    {
        txtKimcuong.text = "Kimcuong: " + _kimcuong + " / " + _victoryCondition;
    }
    public void ShowVictoryCondition(int _kimcuong, int _victoryCondition)
    {
        victoryCondition.SetActive(true);
        txtVictoryCondition.text = "You need " + (_victoryCondition - _kimcuong) + " more Kimcuong.";

    }
    public void HideVictoryCondition()
    {
        victoryCondition.SetActive(false);
    }
}
