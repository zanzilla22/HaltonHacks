using UnityEngine;
using UnityEngine.InputSystem;
public class JoiningScreen : MonoBehaviour
{
    public PlayerInputManager pm;
    void Update()
    {
        this.gameObject.SetActive(pm.playerCount == 0);
    }
}