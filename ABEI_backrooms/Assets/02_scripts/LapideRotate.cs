using UnityEngine;
public class LapideRotate : MonoBehaviour
{
    public bool correctlyRotated;
    public float correctRotation;
    public float startingRotation;
    private void Start()
    {
        transform.Rotate(0f,startingRotation,0f);
    }
    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit) && hit.collider.tag == "estatua")
        {
            if (!correctlyRotated)
            {
                correctlyRotated = true;
            }
        }
    }
}