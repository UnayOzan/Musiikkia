using System.Collections.Generic;
using UnityEngine;

public abstract class BaseAudioSourceCreator : MonoBehaviour
{
    public List<List<AudioSource>> AudioSourcesList;
    protected AudioSource[] audios;

    private void Awake()
    {
        audios = GetComponentsInChildren<AudioSource>();
        AudioSourcesList = new List<List<AudioSource>>();
        
        CreateAudioSources();
    }

    protected virtual void CreateAudioSources()
    {
        for (var i = 0; i < 8; i++)
        {
            AudioSourcesList.Add(new List<AudioSource>());
        }
        
        for (var i = 0; i < 8; i++)
        {
            for (var j = 0; j < 8; j++)
            {
                AudioSourcesList[i].Add(audios[i * 8 + j]);
            }
        }
    }
}