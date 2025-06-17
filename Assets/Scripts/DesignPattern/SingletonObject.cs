using UnityEngine;


public class SingletonObject<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance_;    // => script component
    public static T GetInstance => instance_;


    public void InitSingletonObject()
    {
        if (instance_ == null)
        {
            instance_ = this as T;        //gan the hien hien tai dang ke thua lop base nay cho bien cua lop base ma chinh no dang ke thua
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
