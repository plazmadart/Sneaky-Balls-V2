using Photon.Pun;
using UnityEngine;

public class RespawnManager : MonoBehaviour
{
    public GameObject[] spawns;
    public GameObject player;

    private void Awake()
    {
        Vector3 randomPosition = spawns[Random.Range(0, spawns.Length)].transform.localPosition;
        PhotonNetwork.Instantiate(player.name, randomPosition, Quaternion.identity);
    }

}
