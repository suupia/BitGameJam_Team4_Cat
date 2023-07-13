using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Serialization;
using UniRx;

public class CatInChecker : MonoBehaviour
{
    GameObject _backSelectStageButton;
    ClearEffectStarter _clearEffectStarter;
    public bool IsClear => _isClear;
    bool _isClear = false;

    protected void Start()
    {
        // Debug.Log($"{this.GetType()} Start()");
        _backSelectStageButton = GameObject.FindGameObjectWithTag("BackSelectStageButton");
        _backSelectStageButton.SetActive(false);

        _clearEffectStarter = GameObject.FindGameObjectWithTag("ClearEffectStarter").GetComponent<ClearEffectStarter>();

        this.ObserveEveryValueChanged(_ => _isClear).Where(_ => _isClear).Subscribe(_ =>
        {
            _backSelectStageButton.SetActive(true);
            _clearEffectStarter.StartEffect();
        });

    }

    protected void OnTriggerEnter2D(Collider2D other)
    {
        // Debug.Log($"{this.GetType()} OnTriggerEnter2D()");

        if (other.gameObject.layer == LayerMask.NameToLayer("Cat"))
        {
            _isClear = true;

        }
    }
}
