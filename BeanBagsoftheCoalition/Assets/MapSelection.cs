using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MapSelection : MonoBehaviour
{
    public Map[] Maps;
    public Image mapImage;
    public TextMeshProUGUI mapName;
    private int curMapNumber = 0;
    void Start()
    {
        SetMap(0);
    }

    public void SetMap(int noChange)
    {
        if (curMapNumber + noChange > Maps.Length - 1)
            curMapNumber = 0;
        else if (curMapNumber + noChange < 0)
            curMapNumber = Maps.Length - 1;
        else
            curMapNumber += noChange;

        mapImage.sprite = Maps[curMapNumber].MapImage;
        mapName.SetText(Maps[curMapNumber].MapName);
    }
    public void PlayMap()
    {
        SceneManager.LoadScene(Maps[curMapNumber].MapName);
    }
}
