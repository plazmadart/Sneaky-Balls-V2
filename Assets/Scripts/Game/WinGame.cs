using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class WinGame : MonoBehaviour
{

    public GameObject[] levels;
    public GameObject sceneObject;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
            Destroy(sceneObject);
            sceneObject = Instantiate(levels[Random.Range(0, levels.Length)]);
    }
}
