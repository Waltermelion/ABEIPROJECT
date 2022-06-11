using UnityEngine;

public class FlashingLights : MonoBehaviour
{
    [SerializeField] private Light luz;
    void Update()
    {
        luz.intensity = Mathf.PingPong(Time.deltaTime, 1);
    }
}