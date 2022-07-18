using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
public class MainMenu : MonoBehaviourPunCallbacks
{
    public InputField InputFieldNameRoom;
    public InputField InputFieldNamePlayer;

    public void CreateRoom()
    {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 6;
        PhotonNetwork.NickName = InputFieldNamePlayer.text;
        PhotonNetwork.CreateRoom(InputFieldNameRoom.text, roomOptions);
    }

    public void JoinRoom()
    {
        PhotonNetwork.NickName = InputFieldNamePlayer.text;
        PhotonNetwork.JoinRoom(InputFieldNameRoom.text);
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Game");
    }

}
