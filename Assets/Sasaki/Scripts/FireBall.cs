using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public float timeInterval = 5;
    public float speed = 20;
    public float waitingTime = 0;

    Vector2 startPosition;
    Vector2 startVelocity;

    Rigidbody2D _rb;
    Vector3 _localScale;
    
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _localScale = transform.localScale;
        
        // 初期位置、初期速度を保存
        startPosition = transform.position;
        startVelocity = GetComponent<Rigidbody2D>().velocity;

        // コルーチンを開始
        StartCoroutine(LaunchFireBall());
    }

    void Update()
    {
        // 速度に合わせて向きを決定する
        if (_rb.velocity.y < 0)
        {
            transform.localScale = _localScale;
        }
        else
        {
            transform.localScale = new Vector3(_localScale.x, - _localScale.y, _localScale.z);
        }

    }

    // Catレイヤーに触れたら
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Cat"))
        {
            // シーンをリロードする
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
        }
    }

    IEnumerator LaunchFireBall()
    {
        // waitingTime秒待つ
        yield return new WaitForSeconds(waitingTime);
        
        while (true)
        {
            // 位置を初期値に戻す
            transform.position = startPosition;
            // 速度を初期値に戻す
            _rb.velocity = startVelocity;
            // speedをy軸方向に加える
            _rb.velocity = new Vector2(0, speed);
            // timeInterval秒待つ
            yield return new WaitForSeconds(timeInterval);
        }
    }
}
