using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggStackWarriorInc : MonoBehaviour
{

    public static int _currentEggStack =0;
    public static int _maxEggStack = 10;
    public EggStackManager eggStackManager;
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Girdi");
            if (_currentEggStack < _maxEggStack && EggStackManager.pickUpedEggs >0)
            {
                //StartCoroutine(IncEggAdding());
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Girdi");
            if (_currentEggStack < _maxEggStack && EggStackManager.pickUpedEggs > 0)
            {
                //StartCoroutine(IncEggAdding());
                _currentEggStack++;
                EggStackManager.pickUpedEggs--;
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
            //StopCoroutine(IncEggAdding());
            CancelInvoke();
        }
    }
    public void IncEggAdding()
    {
        for (int i = 0; i < eggStackManager.eggObjects.Count; i++)
        {
            Debug.Log("Çalýþtý");
            var obj = eggStackManager.eggObjects[eggStackManager.eggObjects.Count - i - 1];
            var _obj = GameObject.Find("egg (unityengine.gameobject)");
            obj.tag = "Egg";
            eggStackManager.eggObjects.Remove(obj);
            obj.transform.parent = _obj.transform;
            ObjectPooling.Instance.SetPoolObject(obj.gameObject, 1);
            CancelInvoke();
        }
        //foreach (var obj in eggStackManager.eggObjects)
        //{
        //    Debug.Log("Çalýþtý");
        //    var _obj = GameObject.Find("EGG (UNITYENGINE.GAMEOBJECT)");
        //    obj.tag = "Egg";
        //    obj.transform.parent = _obj.transform;
        //    eggStackManager.eggObjects.Remove(obj);
        //    ObjectPooling.Instance.SetPoolObject(obj.gameObject, 1);
        //    break;
        //}
    }
}
