using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorialSopen : MonoBehaviour
{
    // スクリーン座標をワールド座標に変換した後の座標
    Vector2 beforePos;
    float maxVeloictyAmount = 30f; // 1fで進めるキョリ
    bool isPointerEntered;
    public GameObject btn1;
    public GameObject btn2;


    void Update()
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

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("a");
        if (other.gameObject.layer == LayerMask.NameToLayer("Cat"))
        {
            Debug.Log("b");
            btn1.SetActive(false);
            btn2.SetActive(true);
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
        // gameObject.transform.position = afterPos;
        gameObject.transform.position = beforePos + translation;
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
