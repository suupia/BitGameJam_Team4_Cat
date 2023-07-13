using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatReseter : MonoBehaviour
{
    float _boundaryX = 120f; // ScreenPointの座標系での値（解像度と同じ単位ということ）
    float _boundaryY = 80f;

    void Update()
    {
        var pos = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        var x = pos.x;
        var y = pos.y;
        Debug.Log($"x: {x}, y: {y}, Screen.width: {Screen.width}, Screen.height: {Screen.height}");
        if( x <- _boundaryX 
            || x > Screen.width + _boundaryX 
            || y <  - _boundaryY 
            /* || y > Screen.height  + _boundaryY */)  // 上の条件は付けない
        {
            // シーンをリロードする
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
        }
    }
    
}
