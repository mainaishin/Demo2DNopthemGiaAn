using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KimCuong : Collectable
{

    [SerializeField] int kimcuongValue = 1;
 

    protected override void Collected()
    {
        
        GameManager.MyInstance.AddKimcuong(kimcuongValue);
        Destroy(this.gameObject);
    }

}
