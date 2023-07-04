using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using Koki;
using UnityEngine;

public class CenterBoneController : MonoBehaviour
{
    // 反時計回りに設定する必要があることに注意
    [SerializeField] Transform pos1;
    [SerializeField] Transform pos2;
    [SerializeField] Transform pos3;
   [Tooltip("基底の係数")] [SerializeField] Vector2 offset;

    Quaternion _beforeRotation = Quaternion.identity;

    float s, t; // 単位ベクトルを分解した時の係数
    
    void Start()
    {
        var beforePos1 = pos1.position;
        var beforePos2 = pos2.position;
        var beforePos3 = pos3.position;

        var vector1 = beforePos2 - beforePos1;
        var vector2 = beforePos3 - beforePos1;
        var determinant = vector1.x * vector2.y - vector1.y * vector2.x;

        // e = s * vector1 + t * vector2　を解いた結果
        s = vector2.y / determinant;
        t = -vector1.y / determinant;

        _beforeRotation = transform.localRotation;

        
    }

    void LateUpdate()
    {
        var afterPos1 = pos1.position;
        var afterPos2 = pos2.position;
        var afterPos3 = pos3.position;

        var vector1 = afterPos2 - afterPos1;
        var vector2 = afterPos3 - afterPos1;

        var f_e = s * vector1 + t * vector2; // 変形後のeをf(e)とする

        // 注意:cosを使う方法だと角度の情報が落ちる
        var angle = KokiUtility.Angle360(new Vector2(1, 0), f_e.normalized);

        // 位置
        Vector3  convertedOffset = offset.x * vector1.normalized + offset.y * vector2.normalized;
        transform.position = (afterPos1 + afterPos2 + afterPos3) / 3f + convertedOffset;

        // 回転
        if (_beforeRotation != Quaternion.identity)
        {
            transform.localRotation = _beforeRotation * Quaternion.Euler(0, 0,- angle);  // z軸が奥を向いているため-をつける
        }
    }

    // /// <summary>
    // /// SpriteSkinでの初期化よりも後に行う必要がある
    // /// </summary>
    // async UniTask DelaySetRotation()
    // {
    //     int waitFrame = 1000;
    //     for (int i = 0; i < waitFrame; i++)
    //     {
    //         await UniTask.Yield(PlayerLoopTiming.Update);
    //     }
    // }
}
