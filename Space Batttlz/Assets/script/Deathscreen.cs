using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Deathscreen : MonoBehaviour
{
    public GameObject gameManager;

    // public string nomScene = "PvScene";
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        gameObject.SetActive(false);
    }

    public void Setup()
    {
        gameObject.SetActive(true);
    }

    public void QuitScreen()
    {
        gameObject.SetActive(false);
    }

    public void RestartButton()
    {
        gameManager.Respawn();
    }

    public void ExitButton()
    {
        Debug.Log("Retour au menu (placeholder, menu existe pas encore)");
    }
}
