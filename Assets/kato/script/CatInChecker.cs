using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Serialization;

public class CatInChecker : MonoBehaviour
{
    GameObject _backSelectStageButton;

    void Start()
    {
        _backSelectStageButton = GameObject.FindGameObjectWithTag("BackSelectStageButton");
        _backSelectStageButton.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Cat"))
        {
            _backSelectStageButton.SetActive(true);
        }
    }
}
