using UnityEngine;

public class GamModeAudioSource : BaseAudioSourceCreator
{
    private int currentRowIndex;

    public void OpenLine(int index)
    {
        //close all prev.
        var selectedRow = transform.GetChild(currentRowIndex);
        GamModeMusicButton gamModeMusicButton;

        foreach (Transform child in selectedRow)
        {
            gamModeMusicButton = child.GetComponent<GamModeMusicButton>();
            gamModeMusicButton.SetNonSelectable();
        }

        currentRowIndex++;

        if (currentRowIndex > 7)
            return;

        //open next 3
        
        selectedRow = transform.GetChild(currentRowIndex);
        
        var start = Mathf.Clamp(index - 1,0,7);
        var end = Mathf.Clamp(index + 1,0,7);
        
        for (var i = start; i <= end; i++)
        {
            gamModeMusicButton = selectedRow.GetChild(i).GetComponent<GamModeMusicButton>();
            gamModeMusicButton.SetSelectable();
        }

        //keep the pressed one clickable
        var lastPressedTransform = transform.GetChild(currentRowIndex - 1).GetChild(index);
        var lastGamModeMusicButton = lastPressedTransform.GetComponent<GamModeMusicButton>();
        lastGamModeMusicButton.SetSelectable();
    }

    public void CloseLine(int index)
    {
        Transform selectedRow;
        GamModeMusicButton gamModeMusicButton;
        int start;
        int end;
        
        if (currentRowIndex < 8)
        {
            selectedRow = transform.GetChild(currentRowIndex);

            start = Mathf.Clamp(index - 1,0,7);
            end = Mathf.Clamp(index + 1,0,7);
        
            for (var i = start; i <= end; i++)
            {
                gamModeMusicButton = selectedRow.GetChild(i).GetComponent<GamModeMusicButton>();
                gamModeMusicButton.SetNonSelectable();
            }
        }
        
        if (currentRowIndex - 1 == 0)
        {
            selectedRow = transform.GetChild(currentRowIndex - 1);
            foreach (Transform child in selectedRow)
            {
                gamModeMusicButton = child.GetComponent<GamModeMusicButton>();
                gamModeMusicButton.SetSelectable();
            }

            currentRowIndex = 0;
            return;
        }
        selectedRow = transform.GetChild(currentRowIndex - 2);

        for (var i = 0; i < selectedRow.childCount; i++)
        {
            if (selectedRow.GetChild(i).GetComponent<GamModeMusicButton>().state == GamModeMusicButton.State.Selected)
            {
                index = i;
            }
        }
        currentRowIndex--;

        selectedRow = transform.GetChild(currentRowIndex);

        start = Mathf.Clamp(index - 1,0,7);
        end = Mathf.Clamp(index + 1,0,7);
        
        for (var i = start; i <= end; i++)
        {
            gamModeMusicButton = selectedRow.GetChild(i).GetComponent<GamModeMusicButton>();
            gamModeMusicButton.SetSelectable();
        }
    }
}