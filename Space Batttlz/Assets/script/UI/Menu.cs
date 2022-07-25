using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;

public class Menu : MonoBehaviour
{
    [SerializeField] GameObject menu;
    [SerializeField] GameObject username;
    [SerializeField] Text ipText;
    [SerializeField] Button joinBtn;
    [SerializeField] Text usernameText;
    [SerializeField] Button goBtn;
    public NetworkManager manager;

    private bool isHosting;
    private string ip;

    private void Start()
    {
        joinBtn.interactable  = false;
        goBtn.interactable  = false;
    }

    private void Update()
    {
        joinBtn.interactable = (ipText.text != "") ? true : false; 
        goBtn.interactable = (usernameText.text != "") ? true : false; 
    }

    public void HostLobby()
    {
        isHosting = true;
        Username();
    }
    public void JoinLobby()
    {
        ip = ipText.text;
        isHosting = false;
        Username();
    }
    public void ServerOnly()
    {
        Debug.Log("Server only");
        manager.StartServer();
    }
    public void Quit()
    {
        Quit();
    }

    public void Username()
    {
        menu.gameObject.SetActive(!menu.gameObject.activeInHierarchy);
        username.gameObject.SetActive(!menu.gameObject.activeInHierarchy);
    }

    public void Go()
    {
        if (isHosting)
        {
            Debug.Log("hosting, username = " + usernameText.text);
            manager.StartHost();
            menu.gameObject.SetActive(false);
            username.gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("joining ip = " + ip + ", username = " + usernameText.text);
            manager.networkAddress = ip;
            manager.StartClient();
            menu.gameObject.SetActive(false);
            username.gameObject.SetActive(false);
        }
    }


}
