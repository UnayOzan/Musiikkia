using TMPro;
using UnityEngine;

public class GameInformationUpdater : MonoBehaviour
{
    [SerializeField] private TMP_Text informationText;

    [Header("Information")] [SerializeField]
    private string defaultGameInfo;

    [SerializeField] private string pingPongGameInfo;
    [SerializeField] private string randomGameInfo;
    [SerializeField] private string volumeGameInfo;
    [SerializeField] private string gamModeGameInfo;

    public void UpdateInformation(int index)
    {
        var text = "";
        switch (index)
        {
            case 0:
            case 1:
            case 2:
                text = defaultGameInfo;
                break;
            case 3:
                text = pingPongGameInfo;
                break;
            case 4:
                text = randomGameInfo;
                break;
            case 5:
                text = volumeGameInfo;
                break;
            case 6:
                text = gamModeGameInfo;
                break;
        }

        informationText.text = text;
    }
}