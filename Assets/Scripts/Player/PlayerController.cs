using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private Camera followCamera;
    [SerializeField] private float rotationSpeed = 1f;
    [SerializeField] private Transform followTarget;
    [SerializeField] FloatingJoystick joystick;

    private Rigidbody rigidbody;

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

    private void FixedUpdate()
    {
        Movement();
    }

    void Movement()
    {
        float verticalInput = joystick.Vertical;
        float rotationInput = joystick.Horizontal;

        followTarget.transform.eulerAngles = new Vector3(followTarget.transform.eulerAngles.x, followTarget.transform.eulerAngles.y + rotationInput, 0);

        Vector3 movementInput = Quaternion.Euler(0, followTarget.transform.eulerAngles.y, 0) * new Vector3(0, 0, verticalInput);
        Vector3 movementDirection = movementInput.normalized;

        rigidbody.AddForce(movementDirection * moveSpeed * 100 * Time.deltaTime);
    }
}
