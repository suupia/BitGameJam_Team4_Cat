using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class CloseMusicCanvasButton : MonoBehaviour
{
    [SerializeField] GameObject closeCanvas;
    Button _button;

    void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(()=> closeCanvas.SetActive(false));
    }
}
