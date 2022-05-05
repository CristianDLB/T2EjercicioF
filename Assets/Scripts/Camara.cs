using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    public Transform robot;
    void Start()
    {
        
    }

 
    void Update()
    {
        var x = robot.position.x + 2f;
        var y = robot.position.y + 2f;
        transform.position = new Vector3(x, y, transform.position.z);
    }
}
