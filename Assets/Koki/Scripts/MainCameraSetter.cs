using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Canvas))]
public class MainCameraSetter : MonoBehaviour
{
    void Start()
    {
        var canvas = GetComponent<Canvas>();
        
        canvas.worldCamera = Camera.main;
    }

}
