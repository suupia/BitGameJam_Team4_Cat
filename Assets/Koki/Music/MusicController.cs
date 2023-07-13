using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UniRx;
using DG.Tweening;
using UnityEditor.Rendering;


public class MusicController : MonoBehaviour
{
    public float SeVolume => seSlider.value;
    
    [SerializeField] GameObject musicCanvas; // このスクリプトがアタッチされているオブジェクトの親であるCanvas
    [SerializeField] Slider bgmSlider;
    [SerializeField] Slider seSlider;

    [SerializeField] AudioSource bgmAudioSource;
    [SerializeField] AudioSource seAudioSource;

    [SerializeField] AudioClip titleBGM;
    [SerializeField] AudioClip stageBGM;

    [SerializeField] AudioClip buttonSE;
    [SerializeField] AudioClip selectStageSE;


    readonly Subject<Scene> _sceneLoadedSubject = new Subject<Scene>();

    static bool _isCreated = false; // DontDestroyOnLoadで生成されたオブジェクトが2つ以上できないようにstaticなフラグを持たせる

    void Start()
    {
        if (_isCreated)
        {
            Destroy(musicCanvas);
            return;
        }

        bgmSlider.onValueChanged.AddListener((value) => { bgmAudioSource.volume = value; });
        seSlider.onValueChanged.AddListener((value) => { seAudioSource.volume = value; });

        // 初期化
        bgmSlider.value = 0.5f;
        seSlider.value = 0.5f;


        DontDestroyOnLoad(musicCanvas);


        SceneManager.sceneLoaded += OnSceneLoaded;

        // 最初のシーンは登録するよりも前に読み込まれるので、タイトルシーンから始まると認めて、タイトルBGMを再生する
        PlayTitleBGM();

        // シーンが読み込まれたときに通知を受け取る
        _sceneLoadedSubject.Subscribe(scene =>
        {
            if (scene.name == "GameTitle")
            {
                PlayTitleBGM();
            }
            else
            {
                PlayStageBGM();
            }
        });
        
        _isCreated = true;

    }
    
    public void PlayButtonSE()
    {
        seAudioSource.PlayOneShot(buttonSE);
    }
    public void PlaySelectStageSE()
    {
        seAudioSource.PlayOneShot(selectStageSE);
    }
    
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        _sceneLoadedSubject.OnNext(scene);
    }

    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        _sceneLoadedSubject.Dispose();
    }

    void PlayTitleBGM()
    {
        bgmAudioSource.clip = titleBGM;
        bgmAudioSource.Play();
    }

    void PlayStageBGM()
    {
        float fadeInDuration = 1.0f;

        Debug.Log($"PlayerStageBGM");

        // 既にステージBGMが再生されている場合は何もしない
        if (bgmAudioSource.clip == stageBGM) return;
        bgmAudioSource.clip = stageBGM;

        // シーンの読み込み中にKillされているみたいで、うまくフェードインできない　→　SceneTransitionクラスを作成して、それをSubscribeしたらいけるはず
        // bgmAudioSource.DOFade(bgmSlider.value, fadeInDuration).SetEase(Ease.InQuad).Play(); 
        bgmAudioSource.Play();
    }


}