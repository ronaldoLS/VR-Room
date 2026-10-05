using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Attachment;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class ToggleNearFar : MonoBehaviour
{
    [SerializeField] private NearFarInteractor nearFarInteractor;

    public void ToggleNearFarInteractor()
    {
        if (nearFarInteractor != null)
        {
            nearFarInteractor.farAttachMode = nearFarInteractor.farAttachMode == InteractorFarAttachMode.Near
                ? InteractorFarAttachMode.Far
                : InteractorFarAttachMode.Near;
        }
    }
}
