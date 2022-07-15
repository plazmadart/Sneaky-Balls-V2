using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class PlayerNickname : MonoBehaviourPun
{
    public Text NickText;
    private PhotonView view;
    //public PhotonView Nickname;

    private void Start()
    {
        view = GetComponent<PhotonView>();
        NickText.text = view.Owner.NickName;
       // Nickname = GetComponent<PhotonView>();
       // if (!Nickname.IsMine)
       // {
       //     Nickname.gameObject.SetActive(false);
       // }
    }
}
