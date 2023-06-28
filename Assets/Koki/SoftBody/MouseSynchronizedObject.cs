using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseSynchronizedObject : MonoBehaviour
{
	// スクリーン座標をワールド座標に変換した後の座標
	 Vector2 screenPosition;
	 
	 public float forceAmount = 100000000000f; // 上向きの力の大きさ

	void Update () {

		// マウス位置座標をスクリーン座標からワールド座標に変換する
		screenPosition = Camera.main.ScreenToWorldPoint( Input.mousePosition);
		// ワールド座標に変換されたマウス座標を代入
		gameObject.transform.position = screenPosition;
		
		if (Input.GetMouseButtonDown(0))
		{
			// マウスの位置を取得（スクリーン座標からワールド座標へ変換）
			Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

			// 上向きのRayを生成
			RaycastHit2D hit = Physics2D.Raycast(mousePos + Vector2.up * 1.5f, Vector2.up);

			// Rayが何かに当たった場合
			if(hit.collider != null)
			{
				Debug.Log($"AddForce to {hit.collider.gameObject.name}");
				// 当たったオブジェクトにRigidbody2Dコンポーネントがあるか確認
				Rigidbody2D rb = hit.collider.gameObject.GetComponent<Rigidbody2D>();
				if (rb != null)
				{
					// 上向きの力を追加
					rb.AddForce(Vector2.up * forceAmount, ForceMode2D.Impulse);
				}
			}
		}
	}
}
