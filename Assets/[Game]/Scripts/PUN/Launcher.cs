using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Launcher : MonoBehaviourPunCallbacks
{
   public static Launcher Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    [SerializeField] private GameObject loadingScreen;
    [SerializeField] private GameObject menuButtons;
    [SerializeField] private TMP_Text loadingText;

    private void Start()
    {
        CloseMenus();

        loadingScreen.SetActive(true);
        loadingText.text = "ConnectIng to Network...".ToUpper();

        PhotonNetwork.ConnectUsingSettings();
    }

    private void CloseMenus()
    {
        loadingScreen.SetActive(false);
        menuButtons.SetActive(false);
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
        loadingText.text = "Joining Lobby...".ToUpper();
    }
    public override void OnJoinedLobby() //main menu
    {
        CloseMenus();
        menuButtons.SetActive(true);
    }
}
