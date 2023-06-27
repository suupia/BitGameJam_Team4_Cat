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
    // Start is called before the first frame update
    void Start()
    {
        // 初期位置、初期速度を保存
        startPosition = transform.position;
        startVelocity = GetComponent<Rigidbody2D>().velocity;

        // コルーチンを開始
        StartCoroutine(LaunchFireBall());
    }

    // Update is called once per frame
    void Update()
    {

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
            GetComponent<Rigidbody2D>().velocity = startVelocity;
            // speedをy軸方向に加える
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, speed);
            // timeInterval秒待つ
            yield return new WaitForSeconds(timeInterval);
        }
    }
}
