using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggStackWorkerInc : MonoBehaviour
{
    public static int _currentEggStack = 0;
    public static int _maxEggStack = 10;
    public EggStackManager eggStackManager;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (_currentEggStack < _maxEggStack && EggStackManager.pickUpedEggs > 0)
            {
                InvokeRepeating("IncEggAdding", 0.5f, 0.5f);
            }
            else
            {
                CancelInvoke();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CancelInvoke();
        }
    }

    public void IncEggAdding()
    {
        for (int i = 0; i < eggStackManager.eggObjects.Count; i++)
        {
            _currentEggStack++;
            EggStackManager.pickUpedEggs--;
            var obj = eggStackManager.eggObjects[eggStackManager.eggObjects.Count - i - 1];
            var _obj = GameObject.Find("egg (unityengine.gameobject)");
            obj.tag = "Egg";
            eggStackManager.eggObjects.Remove(obj);
            obj.transform.parent = _obj.transform;
            ObjectPooling.Instance.SetPoolObject(obj.gameObject, 1);
            CancelInvoke();
        }
    }
}
