using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LobbyManager : MonoBehaviour
{
    [SerializeField] private string VersionName = "0.1";
    [SerializeField] private GameObject UserNameMenu;
    [SerializeField] private GameObject connetPanel;

    [SerializeField] private TMP_InputField UserNameInputField;
    [SerializeField] private TMP_InputField JoinGameInputField;
    [SerializeField] private TMP_InputField CreateGameInputField;

    [SerializeField] private GameObject StartButton;

    private void Awake()
    {
        PhotonNetwork.ConnectUsingSettings(VersionName);
    }
    private void Start()
    {
        UserNameMenu.SetActive(true);
    }
    public void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby(TypedLobby.Default);
        Debug.Log("isconneted");
    }

    public void UserNameInput()
    {
        if (UserNameInputField.text.Length >= 4)
        {
            StartButton.SetActive(true);
        }
        else
            StartButton.SetActive(false);
    }

    public void startButtonClick()
    {
        UserNameMenu.SetActive(false);
        PhotonNetwork.playerName = UserNameInputField.text;
    }

    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom(CreateGameInputField.text, new RoomOptions() { maxPlayers = 5 }, null);
    }

    public void JoinRoom()
    {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.maxPlayers = 5;
        PhotonNetwork.JoinOrCreateRoom(JoinGameInputField.text, roomOptions, TypedLobby.Default);
    }
    public void OnJointRoom()
    {
        PhotonNetwork.LoadLevel("Level");
    }
}
