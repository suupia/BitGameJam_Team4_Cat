using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseSynchronizedObject : MonoBehaviour
{
    // スクリーン座標をワールド座標に変換した後の座標
    Vector2 beforePos;
    float maxVeloictyAmount = 10f; // 1fで進めるキョリ
    bool isPointerEntered;

    Rigidbody2D _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        beforePos = gameObject.transform.position;
        // マウス位置座標をスクリーン座標からワールド座標に変換する
        Vector2 afterPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (isPointerEntered)
        {
            TrackingMouse(afterPos);
        }
        else
        {
            CheckOnMouseEntered(afterPos);
        }
    }

    void TrackingMouse(Vector2 afterPos)
    {
        var translation = afterPos - beforePos;
        var velocityAmount = translation.magnitude / Time.deltaTime;
        if (velocityAmount >= maxVeloictyAmount)
        {
            translation = translation.normalized * maxVeloictyAmount * Time.deltaTime;
        }

        // ワールド座標に変換されたマウス座標を代入
        // gameObject.transform.position = beforePos + translation;
        // gameObject.transform.Translate(translation);
        _rb.MovePosition(beforePos + translation);
    }

    void CheckOnMouseEntered(Vector2 afterPos)
    {
        var posX = gameObject.transform.position.x;
        var posY = gameObject.transform.position.y;
        var width = gameObject.GetComponent<SpriteRenderer>().bounds.size.x;
        var height = gameObject.GetComponent<SpriteRenderer>().bounds.size.y;
        // Debug.Log($"width: {width}, height: {height}");
        if (posX - width / 2 < afterPos.x && afterPos.x < posX + width / 2 &&
            posY - height / 2 < afterPos.y && afterPos.y < posY + height / 2)
        {
            isPointerEntered = true;
        }
        else
        {
            isPointerEntered = false;
        }
    }
}