using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Deathscreen : MonoBehaviour
{
    public HealthManager playerHelathManager;

    public Text[] texts;
    public Image[] images;
    public Button[] buttons;

    // public string nomScene = "PvScene";
    void Start()
    {
        QuitScreen();
    }

    public void Setup()
    {
        //gameObject.SetActive(true);
        foreach (Text txt in texts)
        {
            txt.enabled = true;
        }
        foreach (Image img in images)
        {
            img.enabled = true;
        }
        foreach(Button btn in buttons)
        {
            btn.enabled = true;
        }
    }

    public void QuitScreen()
    {
        //gameObject.SetActive(false);
        foreach (Text txt in texts)
        {
            txt.enabled = false;
        }
        foreach (Image img in images)
        {
            img.enabled = false;
        }
        foreach(Button btn in buttons)
        {
            btn.enabled = false;
        }
    }

    public void RestartButton()
    {
        Debug.Log("reswpawn");
        playerHelathManager.Respawn();
    }

    public void ExitButton()
    {
        Debug.Log("Retour au menu (placeholder, menu existe pas encore)");
    }
}
