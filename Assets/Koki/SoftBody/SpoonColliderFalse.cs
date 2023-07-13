using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class SpoonColliderFalse : MonoBehaviour
{
    CatInChecker _catInChecker;
    void Start()
    {
        _catInChecker = FindObjectOfType<CatInChecker>();
        this.ObserveEveryValueChanged(_ => _catInChecker.IsClear).Where(x => x).Subscribe(_ =>
        {
            // 子オブジェクトのすべてのコライダーを無効化する
            foreach (Collider2D collider in GetComponentsInChildren<Collider2D>())
            {
                collider.enabled = false;
            }
        });
    }
    
}
