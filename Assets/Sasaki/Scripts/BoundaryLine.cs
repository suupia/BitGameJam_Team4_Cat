using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BoundaryLine : MonoBehaviour
{
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
