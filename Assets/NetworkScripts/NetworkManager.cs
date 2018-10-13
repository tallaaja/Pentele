using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NetworkManager : MonoBehaviour {

    public Grid hexMap;
    public Button nameButton;
    public InputField nameInput;

    public Text console;
    private const string VERSION = "v0.0.1";
    public string roomName = "roomname";
    public string playerPrefabName = "Male";
    public Transform spawnPoint;
    private GameObject map;
    private string[] names;

	// Use this for initialization
	void Start () {
        

        nameButton.onClick.AddListener(gimmeName);
	}

    void gimmeName(){

        PhotonNetwork.playerName = nameInput.text;
        PhotonNetwork.ConnectUsingSettings(VERSION);

    }

    void OnJoinedLobby()
    {
        RoomOptions roomOptions = new RoomOptions() { IsVisible = false, MaxPlayers = 2 };
        PhotonNetwork.JoinOrCreateRoom(roomName, roomOptions, TypedLobby.Default);
    }

    void OnCreatedRoom()
    {
        hexMap.GenerateGrid();
    }
	
    void OnJoinedRoom()
    {
        //console.text = PhotonNetwork.connectionState + " players: \n" + PhotonNetwork.countOfPlayersInRooms;
        Debug.Log(PhotonNetwork.connectionState + " ALSKDJFA: " + PhotonNetwork.countOfPlayersInRooms);
        
        PhotonNetwork.Instantiate(playerPrefabName, spawnPoint.position, spawnPoint.rotation, 0);



    }

    private void Update()
    {
        Debug.Log(PhotonNetwork.playerList.ToStringFull());
        Debug.Log(PhotonNetwork.connectionState + " players: " + PhotonNetwork.countOfPlayers);
        //console.text = PhotonNetwork.connectionState + " players: \n" + PhotonNetwork.countOfPlayersInRooms + roomName;
    }
}
