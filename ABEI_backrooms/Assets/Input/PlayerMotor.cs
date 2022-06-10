using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    public float speed = 5f;
    
    [Header("Audio")] 
    public AudioClip[] footStepSound;
    public AudioClip jumpSound;
    public AudioSource audioSource1;
    void Start()
    {
        controller = GetComponent<CharacterController>(); 
    }
    public void ProcessMove(Vector3 input)
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;
        controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);
    }

    void PlayFootStepAudio()
    {
        if (!controller.isGrounded)
        {
            return;
        }

        int n = Random.Range(1, footStepSound.Length);
        audioSource1.clip = footStepSound[n];
        audioSource1.PlayOneShot(audioSource1.clip);

        footStepSound[n] = footStepSound[0];
        footStepSound[0] = audioSource1.clip;
    }
}
