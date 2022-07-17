using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private Camera followCamera;
    [SerializeField] private Transform followTarget;
    [SerializeField] FloatingJoystick joystick;

    private new Rigidbody rigidbody;

    PhotonView view;

    public PlayerController scriptPlayerController;
    public GameObject Camera;
    public Text NickText;

    private void Awake()
    {
        view = GetComponent<PhotonView>();

        NickText.text = view.Owner.NickName;

        if (!view.IsMine)
        {
            Camera.SetActive(false);
            scriptPlayerController.enabled = false;
        }

        rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Vector2 verticalInput = joystick.Direction;

        Vector3 movementInput = Quaternion.Euler(0, followCamera.transform.eulerAngles.y, 0) * new Vector3(verticalInput.x, 0, verticalInput.y);
        Vector3 movementDirection = movementInput * moveSpeed * 100;

        rigidbody.AddForce(movementDirection * Time.deltaTime);
    }
}
