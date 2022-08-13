using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using MoreMountains.NiceVibrations;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    private List<List<AudioSource>> _audioSourcesList;

    [SerializeField] private BaseAudioSourceCreator[] _audioSourceCreators;
    [SerializeField] private BaseAudioSourceCreator _selectedAudioSourceCreator;

    [Header("Vibration?")] 
    [SerializeField] private bool shouldVibrate;
    
    [Header("Player Settings")] 
    [SerializeField] private float interval = .125f; // 1/8 by default

    [Header("UI")] [SerializeField] private TMP_Text _progressText;

    private void Start()
    {
        UpdateGrid(0);

        StartCoroutine(Play());
    }

    private IEnumerator Play()
    {
        for (var i = 0; i < _audioSourcesList.Count; i++)
        {
            foreach (var audioSource in _audioSourcesList[i].Where(audioSource => !audioSource.mute))
            {
                audioSource.transform.DOScale(1.2f, .05f)
                    .SetEase(Ease.Flash)
                    .OnComplete(() =>
                    {
                        audioSource.transform.DOScale(1f, .05f)
                            .SetEase(Ease.Flash);
                    });

                if (shouldVibrate)
                {
                    MMVibrationManager.Haptic(HapticTypes.SoftImpact);
                }
                audioSource.Play();
            }

            UpdateUIProgress(i);

            yield return new WaitForSeconds(interval);
        }

        if (_selectedAudioSourceCreator is PingPongAudioSourceCreator)
            yield return new WaitForSeconds(interval);
        
        StartCoroutine(Play());
    }

    public void UpdateGrid(int index)
    {
        _selectedAudioSourceCreator = _audioSourceCreators[index];
        _audioSourcesList = _selectedAudioSourceCreator.AudioSourcesList;

        StopAllCoroutines();

        StartCoroutine(Play());
    }

    private void UpdateUIProgress(int index)
    {
        index++;

        _progressText.text = index + "/8";

        if (_selectedAudioSourceCreator is PingPongAudioSourceCreator && index > 8)
        {
            _progressText.text = 16 - index + "/8";
        }
    }

    public void SetHaptic(bool value)
    {
        shouldVibrate = !value;
    }
}