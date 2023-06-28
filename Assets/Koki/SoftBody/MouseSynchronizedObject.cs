
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseSynchronizedObject : MonoBehaviour
{

    // スクリーン座標をワールド座標に変換した後の座標
    Vector2 beforePos;
    float maxVeloictyAmount = 50f; // 1fで進めるキョリ
    Rigidbody2D rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update ()
    {

        beforePos = gameObject.transform.position;
        // マウス位置座標をスクリーン座標からワールド座標に変換する
        Vector2  afterPos = Camera.main.ScreenToWorldPoint( Input.mousePosition);

        var translation = afterPos - beforePos;
        var velocityAmount = translation.magnitude / Time.deltaTime;
        if (velocityAmount >= maxVeloictyAmount)
        {
            translation = translation.normalized * maxVeloictyAmount * Time.deltaTime;
        }
        
        // ワールド座標に変換されたマウス座標を代入
        // gameObject.transform.position = afterPos;
        gameObject.transform.position = beforePos + translation;


    }
}

