using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class OpenMusicCanvasButton : MonoBehaviour
{
    [SerializeField] GameObject volumeCanvas;
    Button _button;

    void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(()=> volumeCanvas.SetActive(true));
    }
}
