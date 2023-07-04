using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorialText : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject btn1;
    public GameObject btn2;
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
}
