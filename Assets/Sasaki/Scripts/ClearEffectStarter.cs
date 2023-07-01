using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[System.Serializable]  // このクラスがUnityのインスペクタで編集可能になります
public class TimedAudioSource
{
    public AudioSource audioSource;
    public float startTime;
}

[System.Serializable]
public class TimedParticleSystem
{
    public ParticleSystem particleSystem;
    public float startTime;
}

[System.Serializable]
public class TimedTextMeshProUGUI
{
    public TextMeshProUGUI textMeshProUGUI;
    public float startTime;
    public float endTime;
}

public class ClearEffectStarter : MonoBehaviour
{
    public List<TimedAudioSource> timedAudioSources;
    public List<TimedParticleSystem> timedParticleSystems;
    public List<TimedTextMeshProUGUI> timedTexts;


    void Start() 
    {
        // Initialization
        foreach (var timedText in timedTexts)
        {
            timedText.textMeshProUGUI.enabled = false;
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartEffect();
        }
    }

    public void StartEffect()
    {
        foreach (var timedAudioSource in timedAudioSources)
        {
            StartCoroutine(StartAfterDelay(timedAudioSource.audioSource.Play, timedAudioSource.startTime));
        }
        foreach (var timedParticleSystem in timedParticleSystems)
        {
            StartCoroutine(StartAfterDelay(timedParticleSystem.particleSystem.Play, timedParticleSystem.startTime));
        }
        foreach (var timedText in timedTexts)
        {
            StartCoroutine(ShowAndHideText(timedText.textMeshProUGUI, timedText.startTime, timedText.endTime));
        }
    }

    IEnumerator StartAfterDelay(System.Action action, float delay)
    {
        yield return new WaitForSeconds(delay);
        action();
    }

    IEnumerator ShowAndHideText(TextMeshProUGUI textMeshProUGUI, float startTime, float endTime)
    {
        yield return new WaitForSeconds(startTime);
        textMeshProUGUI.enabled = true;
        yield return new WaitForSeconds(endTime - startTime);
        textMeshProUGUI.enabled = false;
    }
}
