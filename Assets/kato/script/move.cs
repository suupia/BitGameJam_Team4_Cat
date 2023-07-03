using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 1f; // エスカレーターの速度

    private void OnCollistionStay(Collider other)
    {
        // オブジェクトがエスカレーターと接触し続けている間、エスカレーターのforward方向に一定の速度で進む
        other.transform.position += transform.right*speed* Time.deltaTime;
        Debug.Log("a");
    }
}
