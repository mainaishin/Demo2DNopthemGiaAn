using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControler : MonoBehaviour
{
    [SerializeField] private float speed;
    private float currPosX;
    private Vector3 velocity = Vector3.zero;

    void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, new Vector3(currPosX, transform.position.y, transform.position.z), ref velocity, speed );

    }

    public void MoveToNewRoom(Transform _newRoom)
    {
        currPosX = _newRoom.position.x;
    }
}
