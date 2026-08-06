using UnityEngine;
using UnityEngine.UI;


public class Pedestal : MonoBehaviour
{
    [SerializeField] private Slider slider;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(0, slider.value, 0);
    }
    public void rotate()
    {
        transform.Rotate(Vector3.up, Mathf.Clamp(slider.value, 0, 360));

    }
    public void testSlider()
    {
       Debug.Log("Rotating by angle: " + slider.value);
        
    }
    public void rotate(int angle)
    {
        transform.Rotate(Vector3.up, Mathf.Clamp(angle, -360, 360));
    }
}
