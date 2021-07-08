﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if(_instance == null)
            {
                Debug.LogError("GameManager is missing!");
            }
            return _instance;
        }
    }

    public bool HasCard { get; set; }
    public PlayableDirector introCutscene;

    private void Awake()
    {
        _instance = this;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            introCutscene.time = 58f;
            AudioManager.Instance.PlayMusic();
        }
    }

}
