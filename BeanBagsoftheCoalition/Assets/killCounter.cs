using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class killCounter : MonoBehaviour
{
    public TextMeshProUGUI killText;
    public void SetKillCount(int count)
    {
        killText.SetText(count.ToString());
    }
}
