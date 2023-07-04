using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan : MonoBehaviour
{
    [SerializeField] float windPower;

    [SerializeField] Direction direction;
    enum Direction
    {
        Left,
        Right,
        Up,
        Down
    }

    void Start()
    {
        transform.localRotation = direction switch
        {
            Direction.Left => Quaternion.Euler(0, 0, 0),
            Direction.Right => Quaternion.Euler(0, 0, 180),
            Direction.Up => Quaternion.Euler(0, 0, -90),
            Direction.Down => Quaternion.Euler(0, 0, 90),
            _ => Quaternion.identity
        };
    }

    void FixedUpdate()
    {
        // Rayの長さ
        float rayLength = 30f;

        var directionVector = direction switch
        {
            Direction.Left => Vector2.left,
            Direction.Right => Vector2.right,
            Direction.Up => Vector2.up,
            Direction.Down => Vector2.down,
            _ => Vector2.zero
        };

        // Raycastを使って指定レイヤー（Cat）との衝突を検出
        RaycastHit2D hit = Physics2D.Raycast(transform.position, directionVector, rayLength, LayerMask.GetMask("Cat"));
        // x軸負方向にRayを出し、それをDebug.DrawRayで表示
        Debug.DrawRay(transform.position, directionVector * rayLength, Color.red);

        if (hit.collider != null)
        {
            var child = hit.transform;
            var parent = child.parent.gameObject;

            var components = parent.GetComponentsInChildren<Rigidbody2D>();
            foreach (var rbs in components)
            {
                rbs.AddForce(directionVector* windPower);
            }
        }
    }
    
    
}
