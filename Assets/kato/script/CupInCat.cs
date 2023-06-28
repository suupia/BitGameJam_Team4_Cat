using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CupInCat : MonoBehaviour
{
    public GameObject btn;
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("a");
        if (other.gameObject.layer == LayerMask.NameToLayer("Cat"))
        {
            Debug.Log("b");
            btn.SetActive(true);
        }
    }
}
