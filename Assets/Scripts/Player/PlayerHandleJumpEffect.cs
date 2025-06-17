using UnityEngine;
using static GlobalSpace.GameUtilities;


public class PlayerHandleJumpEffect : MonoBehaviour
{
    [SerializeField] TrailRenderer ref_TrailRenderer;
    [SerializeField] PlayerData ref_PlayerData;


    private void Start()
    {
        CheckIsNotNull(ref_TrailRenderer, "ref_TrailRenderer in ref_TrailRenderer");
        CheckIsNotNull(ref_PlayerData, "ref_PlayerData in ref_TrailRenderer");
    }

    private void Update()
    {
        if (ref_TrailRenderer != null)
        {
            UpdateStateTrailRender();
        }

        //...

    }

    void UpdateStateTrailRender()
    {
        if (ref_PlayerData.is_on_ground_)
        {
            ref_TrailRenderer.emitting = false;
            //...
        }
        else
        {
            ref_TrailRenderer.emitting = true;
            //...
        }
    }
}
