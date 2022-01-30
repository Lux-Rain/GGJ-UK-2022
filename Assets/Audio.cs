using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    [SerializeField]
    private AK.Wwise.Event ambient;
    [SerializeField]
    private AK.Wwise.Event music;
    [SerializeField]
    private AK.Wwise.State musicState;

    private void Start()
    {
        ambient.Post(gameObject);
        music.Post(gameObject);
    }
}
