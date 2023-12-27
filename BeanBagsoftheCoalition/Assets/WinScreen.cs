using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class WinScreen : MonoBehaviour
{
    public Animator anim;
    public TextMeshProUGUI winText;
    public int killWinThreshold = 15;

    void Update()
    {
        GameObject[] p = GameObject.FindGameObjectsWithTag("Player");
        for (int i = 0; i < p.Length; i++)
        {
            if (p[i].GetComponent<fpsController>().kills >= killWinThreshold)
                StartCoroutine(Win(i + 1));
        }
    }
    public IEnumerator Win(int playerNo)
    {
        anim.SetBool("isWin", true);
        winText.SetText("Player " + playerNo + " Won!");
        yield return new WaitForSeconds(4.5f);
        SceneManager.LoadScene(0);
    }
}
