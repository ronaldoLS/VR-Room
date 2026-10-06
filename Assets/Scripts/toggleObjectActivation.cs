using UnityEngine;

public class toggleObjectActivation : MonoBehaviour
{
    public void ToggleActivation()
    {
        this.gameObject.SetActive(!this.gameObject.activeSelf);
    }
}
