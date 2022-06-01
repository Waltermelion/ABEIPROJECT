using UnityEngine;
using UnityEngine.SceneManagement;

public class playermovement : MonoBehaviour
{
    void Update()
    {
        float valueH = Input.GetAxis("Horizontal");
        transform.position += transform.right * valueH * Time.deltaTime * 5f;

        float valueV = Input.GetAxis("Vertical");
        transform.position += transform.forward * valueV * Time.deltaTime * 5f;

        float angle = 1;
        float horizontal = Input.GetAxis("Horizontal");
        transform.Rotate(transform.up, horizontal * angle, Space.Self);
    }
}