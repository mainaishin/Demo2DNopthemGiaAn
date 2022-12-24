using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int collectedkimcuong = 0;
    public int victoryCondition = 3;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            DestroyImmediate(this);
        }
    }
    private static GameManager instance;

    public static GameManager MyInstance
    {
        get
        {
            if (instance == null)
                instance = new GameManager();
            return instance;
           
        }
    }
    public void Start()
    {
        UiManager.MyInstance.UpdateKimcuongUI(collectedkimcuong, victoryCondition);
    }
    public void AddKimcuong(int _kimcuong)
    {
        collectedkimcuong += _kimcuong;
        UiManager.MyInstance.UpdateKimcuongUI(collectedkimcuong, victoryCondition);
    }

    public void Finish()
    {
        if(collectedkimcuong >= victoryCondition)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            UiManager.MyInstance.ShowVictoryCondition(collectedkimcuong, victoryCondition);
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }
}
