using UnityEngine;
using Random = UnityEngine.Random;
public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    public float speed = 5f;
    private InputManager inputManager;
    
    [Header("Audio")] 
    public AudioClip[] footStepSound;
    public AudioClip jumpSound;
    public AudioSource audioSource1;
    
    public float audioPlayRate = 15f;
    private float nextTimeToPlay = 0f;
    void Start()
    {
        controller = GetComponent<CharacterController>(); 
        inputManager = GetComponent<InputManager>();
    }
    public void ProcessMove(Vector3 input)
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;
        controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);
        if (inputManager.onFoot.Movement.IsPressed() && Time.time >= nextTimeToPlay)
        {
            nextTimeToPlay = Time.time + 1f / audioPlayRate;
            PlayFootStepAudio();
        }
    }
    void PlayFootStepAudio()
    {
        int n = Random.Range(1, footStepSound.Length);
        audioSource1.clip = footStepSound[n];
        audioSource1.PlayOneShot(audioSource1.clip);

        footStepSound[n] = footStepSound[0];
        footStepSound[0] = audioSource1.clip;
    }
}