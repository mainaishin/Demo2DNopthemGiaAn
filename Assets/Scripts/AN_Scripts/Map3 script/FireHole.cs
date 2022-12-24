using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireHole : MonoBehaviour
{
    public Transform fPoint;
    public GameObject bullet;
    float timeBT;
    public float starttimrBT;
    // Start is called before the first frame update
    void Start()
    {
        timeBT = starttimrBT;
    }

    // Update is called once per frame
    void Update()
    {
        if(timeBT <= 0 )
        {
            Instantiate(bullet, fPoint.position, fPoint.rotation);
            timeBT = starttimrBT;
        }
        else
        {
            timeBT -= Time.deltaTime;
        }
    }
}
