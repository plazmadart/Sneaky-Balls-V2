using UnityEngine;
using Photon.Pun;

public class PhotonManager : MonoBehaviourPunCallbacks
{
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public GameObject MainMenu;

    public override void OnConnectedToMaster()
    {
        this.gameObject.SetActive(false);
        MainMenu.SetActive(true);
    }
}
