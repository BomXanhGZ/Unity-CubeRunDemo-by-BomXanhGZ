using UnityEngine;


namespace GlobalSpace
{
    public enum Direction
    {
        Dir_LEFT    = 0,
        Dir_RIGHT   = 1,
        Dir_UP      = 2,
        Dir_DOWN    = 3,
    };

    static public class GameUtilities
    {
        static public System.Random g_random = new System.Random();

        public static bool CheckIsNotNull<T>(T _Obj , string _Info) where T : UnityEngine.Object
        {
            if (_Obj != null) 
            {
                return true; 
            }

            Debug.LogWarning("Null At: " + _Info);
            return false;
        }

        //...
    }
}