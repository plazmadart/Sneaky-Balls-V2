using UnityEngine;

public class TargetFollow : MonoBehaviour
{
    [SerializeField] Transform followObject;

    void Update()
    {
        if (followObject == null)
        {
            return;
        }

        else { transform.position = followObject.position; }
            
    }
}
