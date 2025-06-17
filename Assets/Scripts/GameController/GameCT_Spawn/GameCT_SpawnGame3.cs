using System.Collections.Generic;
using UnityEngine;


public class GameCT_SpawnGame3 : MonoBehaviour, IGameControllerSpawnData
{
    [SerializeField] List<GameObject> ref_Prefabs;
    //...

    #region SPAWN_OBJECT_POS
    //Coin Pos
    static readonly Vector3 COIN_POS_1 = new Vector3(26.5f, -5.5f, 1.0f);
    static readonly Vector3 COIN_POS_2 = new Vector3(85.5f, -6.0f, 1.0f);
    static readonly Vector3 COIN_POS_3 = new Vector3(112.5f, -7.5f, 1.0f);
    public static readonly Vector3[] COIN_POS = { COIN_POS_1, COIN_POS_2, COIN_POS_3 };

    //WinFlagPos
    public static readonly Vector3 FLAG_POS = new Vector3(117.5f, -5.15f, 1.0f);

    //...
    #endregion


    private void Start()
    {
        SpawnStaticObject();
    }

    public void SpawnStaticObject()
    {
        if (ref_Prefabs == null)
        {
            Debug.LogError("ref_Prefabs in GameCT_SpawnGame1");
            return;
        }

        foreach (var obj in ref_Prefabs)
        {
            if (obj.name == "Coin")                                     //Spawn Coin
            {
                for (int i = 0; i < COIN_POS.Length; i++)
                { Instantiate(obj, COIN_POS[i], Quaternion.identity); }
            }

            if (obj.name == "WinFlag")                                 //Win Flag
            {
                Instantiate(obj, FLAG_POS, Quaternion.identity);
            }

            //...
        }
    }

    public void SpawnDynamicObject()
    {

    }
}
