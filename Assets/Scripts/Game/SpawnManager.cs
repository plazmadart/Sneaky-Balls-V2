using Photon.Pun;
using UnityEngine;
using Photon.Realtime;

public class SpawnManager : MonoBehaviourPunCallbacks
{
    public GameObject[] levels;
    public GameObject sceneObject;
    public GameObject[] spawns;
    public GameObject player;
    public GameObject respawnPlayer;
    private static int AlreadyConnected;

    private void Start()
    {
        Spawn();
    }
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Spawn();
    }

    private void Spawn()
    {
        if (AlreadyConnected == 1) return;
        AlreadyConnected = 1;
        Vector3 randomPosition = spawns[Random.Range(0, spawns.Length)].transform.localPosition;
            player = PhotonNetwork.Instantiate(player.name, randomPosition, Quaternion.identity);
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        base.OnPlayerLeftRoom(otherPlayer);
    } 

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            sceneObject = GameObject.FindGameObjectWithTag("level");
            respawnPlayer = GameObject.FindGameObjectWithTag("Player");
            Vector3 randomPosition = spawns[Random.Range(0, spawns.Length)].transform.localPosition;
            Destroy(sceneObject);
            sceneObject = Instantiate(levels[Random.Range(0, levels.Length)]);
            respawnPlayer.transform.position = randomPosition;
        }
    }
}
