using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorialCupInCat : MonoBehaviour
{
    public GameObject btn2;
    public GameObject btn3;
    public GameObject btnnext;
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("a");
        if (other.gameObject.layer == LayerMask.NameToLayer("Cat"))
        {
            Debug.Log("b");
            btn2.SetActive(false);
            btn3.SetActive(true);
            btnnext.SetActive(true);
        }
    }
}
