using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IcePillar : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        // Rayの長さ
        float rayLength = 30f;

        // y軸負方向にRayを出し、それをDebug.DrawRayで表示
        Debug.DrawRay(transform.position, Vector2.down * rayLength, Color.red);

        // Raycastを使って指定レイヤー（Cat）との衝突を検出
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, rayLength, LayerMask.GetMask("Cat"));

        // ヒットした場合にはログを出す
        if (hit.collider != null)
        {
            // Rigidbody2Dの重力を有効にする
            GetComponent<Rigidbody2D>().gravityScale = 3.0f;
        }
    }

    // IcePillarがCatレイヤーに触れたら
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Cat"))
        {
            // シーンをリロードする
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
