using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class TutorialCatInChecker : CatInChecker
{
    [SerializeField] GameObject message2;
    [SerializeField] GameObject message3;

    void Start()
    {
         base.Start();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);
        if (other.gameObject.layer == LayerMask.NameToLayer("Cat"))
        {
            message2.SetActive(false);
            message3.SetActive(true);
        }
    }
}