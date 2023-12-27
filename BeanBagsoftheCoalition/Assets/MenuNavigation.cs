using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class MenuNavigation : MonoBehaviour
{
    public EventSystem EventSystem;
    public fpsController player;
    public GameObject pauseMenu, mainPauseMenu, optionsMenu, loadoutMenu;
    public GameObject pauseFirstButton, optionsFirstButton, loadoutFirstButton;
    public GameObject[] MenuButtons;
    public GameObject[] OptionsButtons;
    public GameObject[] LoadoutButtons;

    bool pauseCooldown = false;
    int curMenuButton = 0;
    Vector2 navigationInput;
    float pressInput;
    bool navCooldown = false;
    bool clickCooldown = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.isOptions == true && !pauseCooldown)
            PauseUnpause();
        if (!player.isOptions)
            pauseCooldown = false;

        if (pauseMenu.activeInHierarchy)
        {
            if (pressInput > 0.5f && !clickCooldown)
                ClickCurButton();
            if (!(pressInput > 0.5f))
                clickCooldown = false;

            if (mainPauseMenu.activeInHierarchy)
            {
                if (Mathf.RoundToInt(navigationInput.y) != 0 && !navCooldown)
                {
                    MoveMenuButton(-Mathf.RoundToInt(navigationInput.y));
                    navCooldown = true;
                }
                if (Mathf.RoundToInt(navigationInput.y) == 0)
                    navCooldown = false;
            }
            if (optionsMenu.activeInHierarchy)
            {
                if (Mathf.RoundToInt(navigationInput.y) != 0 && !navCooldown)
                {
                    MoveOptionsButton(-Mathf.RoundToInt(navigationInput.y));
                    navCooldown = true;
                }
                if (Mathf.RoundToInt(navigationInput.y) == 0)
                    navCooldown = false;
            }
            if (loadoutMenu.activeInHierarchy)
            {
                if (Mathf.RoundToInt(navigationInput.x) != 0 && !navCooldown)
                {
                    MoveLoadoutButton(-Mathf.RoundToInt(navigationInput.x));
                    navCooldown = true;
                }
                if (Mathf.RoundToInt(navigationInput.x) == 0)
                    navCooldown = false;
            }
        }
    }
    

    public void PauseUnpause()
    {
        pauseCooldown = true;
        pauseCooldown = player.isOptions;
        if(!pauseMenu.activeInHierarchy)
        {
            pauseMenu.SetActive(true);
            curMenuButton = 0;

            mainPauseMenu.SetActive(true);
            optionsMenu.SetActive(false);
            loadoutMenu.SetActive(false);

            OpenCloseOptionsMenu(false);
        } else
        {
            pauseMenu.SetActive(false);

            mainPauseMenu.SetActive(true);
            optionsMenu.SetActive(false);
            loadoutMenu.SetActive(false);

        }

    }
    public void OpenCloseOptionsMenu(bool b)
    {
        Debug.Log(b);
        mainPauseMenu.SetActive(!b);
        optionsMenu.SetActive(b);
        if (b)
        {
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(optionsFirstButton);
        } else
        {
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(pauseFirstButton);
        }
    }
    public void OpenCloseLoadoutMenu(bool b)
    {
        Debug.Log(b);
        mainPauseMenu.SetActive(!b);
        loadoutMenu.SetActive(b);
        if (b)
        {
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(loadoutFirstButton);
        } else
        {
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(pauseFirstButton);
        }
    }


    public void MoveMenuButton(int n)
    {
        curMenuButton = Mathf.Clamp(curMenuButton + n, 0, MenuButtons.Length - 1);

        if (MenuButtons[curMenuButton] != EventSystem.current)
        {
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(MenuButtons[curMenuButton]);
        }
        //Debug.Log(EventSystem.current);
    }
    public void MoveOptionsButton(int n)
    {
        curMenuButton = Mathf.Clamp(curMenuButton + n, 0, OptionsButtons.Length - 1);

        if (OptionsButtons[curMenuButton] != EventSystem.current)
        {
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(OptionsButtons[curMenuButton]);
        }
        //Debug.Log(EventSystem.current);
    }
    public void MoveLoadoutButton(int n)
    {
        curMenuButton = Mathf.Clamp(curMenuButton + n, 0, LoadoutButtons.Length - 1);

        if (LoadoutButtons[curMenuButton] != EventSystem.current)
        {
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(LoadoutButtons[curMenuButton]);
        }
        //Debug.Log(EventSystem.current);
    }



    void ClickCurButton()
    {
        clickCooldown = true;
        if (mainPauseMenu.activeInHierarchy)
            MenuButtons[curMenuButton].GetComponent<Button>().onClick.Invoke();
        else if (optionsMenu.activeInHierarchy)
            OptionsButtons[curMenuButton].GetComponent<Button>().onClick.Invoke();
        else if (loadoutMenu.activeInHierarchy)
            LoadoutButtons[curMenuButton].GetComponent<Button>().onClick.Invoke();
    }

    public void OnNavigate(InputAction.CallbackContext ctx) => navigationInput = ctx.ReadValue<Vector2>();
    public void OnButtonPress(InputAction.CallbackContext ctx) => pressInput = ctx.ReadValue<float>();

    public void GetClicked(float n)
    {
        Debug.Log("Clicked: " + n);
    }
}
