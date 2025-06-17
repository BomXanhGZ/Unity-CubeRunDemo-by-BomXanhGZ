using UnityEngine;
using static GlobalSpace.GameUtilities;

public class IntroCubeHandleSprite : MonoBehaviour
{
    [SerializeField] Sprite[] ref_CuberSprites;
    [SerializeField] SpriteRenderer SP_Renderer;
    [SerializeField] IntroCubeHandleMove ref_IntroCubeHandleMove;


    private void Start()
    {
        for(int i = 0; i < ref_CuberSprites.Length; i++ )
           {CheckIsNotNull(ref_CuberSprites[i], "CubeSprite in SpawIntroCube at Index + " + i); }

        CheckIsNotNull(SP_Renderer, "SP_Renderer in IntroCubeHandleSprite");
        CheckIsNotNull(ref_IntroCubeHandleMove, "ref_IntroCubeHandleMove in IntroCubeHandleSprite");
    }

    public void UpdateSprite(int _dir)
    {
        if (SP_Renderer == null)                                                    // check null
        {
            Debug.LogError("null SpriteRenderer in IntroCubeHandleSprite");
            return;
        }

        if (ref_CuberSprites == null)
        {
            Debug.LogError("null ref_CuberSprites in IntroCubeHandleSprite");
            return;
        }
       
        int l_sprite = g_random.Next(ref_CuberSprites.Length);                   //Update & change Sprite from sp_Arr with c#_Random
        SP_Renderer.sprite = ref_CuberSprites[l_sprite];

        transform.localScale = new Vector3(_dir, transform.localScale.y, transform.localScale.z); 
    }
}
