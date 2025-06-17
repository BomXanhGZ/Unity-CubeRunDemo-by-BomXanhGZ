using UnityEngine;
using static GlobalSpace.GameUtilities;


public class WindmillObject : MonoBehaviour
{
    PolygonCollider2D[] ref_PolygonCollider2D;

    void Start()
    {
        ref_PolygonCollider2D = GetComponents<PolygonCollider2D>();
    }

    void HandlePolyCollider(int idx)
    {
        if(!CheckIsNotNull(ref_PolygonCollider2D[idx], "ref_PolygonCollider2D in WindmillObject") )
        {
            Debug.Log("error, null at ref_PolygonCollider2D of Windmill");
            return;
        }

        foreach(var col in ref_PolygonCollider2D)
        {
            col.enabled = false;
        }

        ref_PolygonCollider2D[idx].enabled = true;
    }
}
