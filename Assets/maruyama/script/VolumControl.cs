using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// "AudioSource"コンポーネントがアタッチされていない場合アタッチ
[RequireComponent(typeof(AudioSource))]
public class VolumControl : MonoBehaviour
{
	private AudioSource m_audioSource;

	private void Start()
	{
		// "AudioSource"コンポーネントを取得
		m_audioSource = gameObject.GetComponent<AudioSource>();

	}


	// スライドバー値の変更イベント
	//newSliderValue:スライドバーの値(自動的に引数に値が入る)
	public void SoundSliderOnValueChange(float newSliderValue)
	{
		// 音楽の音量をスライドバーの値に変更
		m_audioSource.volume = newSliderValue;
	}
}
