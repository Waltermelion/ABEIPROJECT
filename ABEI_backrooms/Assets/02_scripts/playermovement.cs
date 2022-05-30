using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    void Update()
    {
        float valueH = Input.GetAxis("Horizontal");
        transform.position += transform.right * valueH * Time.deltaTime * 3f;

        float valueV = Input.GetAxis("Vertical");
        transform.position += transform.forward * valueV * Time.deltaTime * 3f;

        float angle = 1;
        float horizontal = Input.GetAxis("Horizontal");
        transform.Rotate(transform.up, horizontal * angle, Space.Self);
    }

    void FixedUpdate()
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        if (Physics.Raycast(transform.position, fwd, out hit) && hit.collider.tag == "enemy")
        {
            Debug.Log("Inimigo a destruir perto!");
            hit.collider.gameObject.active = false;
        }

    }
}