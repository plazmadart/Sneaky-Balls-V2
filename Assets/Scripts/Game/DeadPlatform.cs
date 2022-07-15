using UnityEngine;

public class DeadPlatform : MonoBehaviour
{
    public GameObject respawnPlayer;
    public GameObject[] spawns;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            respawnPlayer = GameObject.FindGameObjectWithTag("Player");
            Vector3 randomPosition = spawns[Random.Range(0, spawns.Length)].transform.localPosition;
            respawnPlayer.transform.position = randomPosition;
        }
    }
}
