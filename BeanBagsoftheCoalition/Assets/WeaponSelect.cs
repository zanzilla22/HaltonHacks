using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class WeaponSelect : MonoBehaviour
{
    public fpsController player;
    public Gun[] guns;
    public Image gunIcon;
    public TextMeshProUGUI gunName;

    int curGunNumber;

    void Start()
    {
        if (guns != null)
            player.curGun = guns[curGunNumber];
        gunIcon.sprite = guns[curGunNumber].icon;
        gunIcon.SetNativeSize();
        for (int i = 0; i < guns.Length; i++)
        {
            guns[i].gameObject.SetActive(false);
        }
        guns[curGunNumber].gameObject.SetActive(true);
        gunName.SetText(guns[curGunNumber].gameObject.name);
    }

    public void ChangeWeapon(int noChange)
    {
  
        if (curGunNumber + noChange > guns.Length - 1)
            curGunNumber = 0;
        else if (curGunNumber + noChange < 0)
            curGunNumber = guns.Length - 1;
        else
            curGunNumber += noChange;

        gunIcon.sprite = guns[curGunNumber].icon;
        gunIcon.SetNativeSize();
        gunName.SetText(guns[curGunNumber].gameObject.name);
    }
    public void UpdateWeapon()
    {
        Debug.Log("WeaponUpdate");
        player.curGun = guns[curGunNumber];
        for (int i = 0; i < guns.Length; i++)
        {
            guns[i].gameObject.SetActive(false);
        }
        guns[curGunNumber].gameObject.SetActive(true);
    }
}
