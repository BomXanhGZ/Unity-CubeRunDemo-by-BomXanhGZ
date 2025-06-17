using UnityEngine;
using static GlobalSpace.GameUtilities;


public class DeathZoneCol : MonoBehaviour
{
    [SerializeField] PlayerHandleDeath ref_PlayerHandleDeath;


    void Start()
    {
        CheckIsNotNull(ref_PlayerHandleDeath, "ref_PlayerHandleDeath in DeathZoneCol");   
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            ref_PlayerHandleDeath.HandleDeath();
        }
    }
}
