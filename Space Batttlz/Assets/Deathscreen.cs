using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Deathscreen : MonoBehaviour
{

    // public string nomScene = "PvScene";
    void Start()
    {
        gameObject.SetActive(false);
    }

    public void Setup()
    {
        gameObject.SetActive(true);
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("PvScene");
    }

    public void ExitButton()
    {
        Debug.Log("Retour au menu (placeholder, menu existe pas encore)");
    }
}
