using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveClouds : MonoBehaviour
{

    public Vector2 speed;

    void LateUpdate()
    {
        GetComponent<Renderer>().material.mainTextureOffset = speed * Time.time;
    }

}

