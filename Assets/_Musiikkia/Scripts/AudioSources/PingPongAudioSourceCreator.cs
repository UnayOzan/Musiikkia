using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PingPongAudioSourceCreator : BaseAudioSourceCreator
{
    protected override void CreateAudioSources()
    {
        for (var i = 0; i < 16; i++)
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

        audios = audios.Reverse().ToArray();

        for (var i = 8; i < 16; i++)
        {
            for (var j = 0; j < 8; j++)
            {
                AudioSourcesList[i].Add(audios[(i - 8) * 8 + j]);
            }
        }
    }
}