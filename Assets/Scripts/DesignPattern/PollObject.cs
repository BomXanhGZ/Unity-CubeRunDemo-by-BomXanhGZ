using System.Collections.Generic;
using UnityEngine;


public class PollObject<T> where T : MonoBehaviour
{
    private List<T> pool_ = new List<T>();      //poll list
    private T prefab_;                          //poll obj
    private Transform parent_;                  //attribute

    public PollObject(T _obj, int size, Transform _parent = null)       //T Is Data Type
    {
        this.prefab_ = _obj;
        this.parent_ = _parent;
        for(int i = 0; i < size; i++)
        {
            T l_obj = GameObject.Instantiate(this.prefab_, this.parent_);
            l_obj.gameObject.SetActive(false);
            pool_.Add(l_obj);
        }
    }

    public T GetObject()
    {
        for(var obj = 0; obj < pool_.Count; obj++)
        {
            if (!pool_[obj].gameObject.activeInHierarchy)
            {
                return pool_[obj];
            }
        }

        T newObj = GameObject.Instantiate(this.prefab_, this.parent_);
        newObj.gameObject.SetActive(true);
        pool_.Add(newObj);
        return newObj;
    }

    public void ReturnObject(T _obj)
    {
        _obj.gameObject.SetActive(true);
    }
}
