using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

public class ClearEffectStarter : MonoBehaviour
{
    public List<TimedAudioSource> timedAudioSources;
    public List<TimedParticleSystem> timedParticleSystems;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            foreach (var timedAudioSource in timedAudioSources)
            {
                StartCoroutine(StartAfterDelay(timedAudioSource.audioSource.Play, timedAudioSource.startTime));
            }
            foreach (var timedParticleSystem in timedParticleSystems)
            {
                StartCoroutine(StartAfterDelay(timedParticleSystem.particleSystem.Play, timedParticleSystem.startTime));
            }
        }
    }

    IEnumerator StartAfterDelay(System.Action action, float delay)
    {
        yield return new WaitForSeconds(delay);
        action();
    }
}
