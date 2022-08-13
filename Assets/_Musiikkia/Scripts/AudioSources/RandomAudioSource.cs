using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RandomAudioSource : BaseAudioSourceCreator
{
    [SerializeField] private int pressedButtonAmount;

    private List<DefaultMusicButton> _musicButtons;

    private void Start()
    {
        _musicButtons = GetComponentsInChildren<DefaultMusicButton>().ToList();
    }

    public void RandomizeAudioSources()
    {
        foreach (var musicButton in _musicButtons)
        {
            musicButton.UpdateStatus(false);
        }

        var random = new System.Random();
        _musicButtons = _musicButtons.OrderBy(a => random.Next()).ToList();

        for (var i = 0; i < pressedButtonAmount; i++)
        {
#if UNITY_EDITOR
            _musicButtons[i].OnPointerClick(null);
#else
            _musicButtons[i].OnPointerEnter(null);
#endif
        }
    }

    public void UpdatePressedButtonAmount(float amount)
    {
        pressedButtonAmount = (int)amount;
    }
}
