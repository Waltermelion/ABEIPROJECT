using UnityEngine;

public class MenuCameraMovement : MonoBehaviour
{

    public Transform currentMount;

    public float speedFactor = 0.1f;

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, currentMount.position, speedFactor);
        transform.rotation = Quaternion.Slerp(transform.rotation,currentMount.rotation,speedFactor);
    }

    public void setMount(Transform newMount)
    {
        currentMount = newMount;
    }
}
