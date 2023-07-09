using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Serialization;

public class CupInCat : MonoBehaviour
{
    [SerializeField] GameObject backSelectStageButton;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Cat"))
        {
            backSelectStageButton.SetActive(true);
        }
    }
}
