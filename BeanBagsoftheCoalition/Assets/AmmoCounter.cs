using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AmmoCounter : MonoBehaviour
{
    public TextMeshProUGUI curMag;
    public TextMeshProUGUI leftAmmo;
    public void SetMagCount(int count)
    {
        curMag.SetText(count.ToString());
    }
    public void SetLeftAmmo(int count)
    {
        leftAmmo.SetText(count.ToString());
    }
}
