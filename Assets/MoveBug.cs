using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBug : MonoBehaviour
{
    public GameObject bug;
    public float speed;

    public void Update()
    {
        float y = Mathf.PingPong(Time.time * speed, 1) * 2 - 4;
        bug.transform.position = new Vector3(transform.position.x, y, 0);

    }

}
