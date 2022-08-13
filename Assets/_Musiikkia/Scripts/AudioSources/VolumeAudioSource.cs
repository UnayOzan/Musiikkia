using System.Collections.Generic;
using UnityEngine;

public class VolumeAudioSource : BaseAudioSourceCreator
{
    protected override void CreateAudioSources()
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
