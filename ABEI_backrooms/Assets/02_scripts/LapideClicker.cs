using UnityEngine;
public class LapideClicker : MonoBehaviour
{
    public InputManager ipt;
    public float dist = 5f;
    //Audio
    public AudioSource audioSource3;
    public AudioClip lapideRotationSound;
    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, dist) && hit.collider.tag == "lapide")
        {
            if (ipt.onFoot.MouseClick.triggered && hit.transform.GetComponent<LapideRotate>().correctlyRotated == false)
            {
                audioSource3.PlayOneShot(lapideRotationSound);
                hit.transform.Rotate(0f,45f,0f);
                Debug.Log(hit.transform.localEulerAngles);
            }
        }
    }
}