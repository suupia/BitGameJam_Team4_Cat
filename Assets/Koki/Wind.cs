using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{
    // Update is called once per frame
    void FixedUpdate()
    {
        // Rayの長さ
        float rayLength = 30f;
        float forceAmount = 15f;


        // Raycastを使って指定レイヤー（Cat）との衝突を検出
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left, rayLength, LayerMask.GetMask("Cat"));
        // x軸負方向にRayを出し、それをDebug.DrawRayで表示
        Debug.DrawRay(transform.position, Vector2.left * rayLength, Color.red);

        if (hit.collider != null)
        {
            var child = hit.transform;
            var parent = child.parent.gameObject;

            var components = parent.GetComponentsInChildren<Rigidbody2D>();
            foreach (var rbs in components)
            {
                rbs.AddForce(Vector2.left * forceAmount);
            }
        }
    }
    
    
}
