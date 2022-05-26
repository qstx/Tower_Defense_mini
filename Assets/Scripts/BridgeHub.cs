using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyTowerDefense;

public class BridgeHub : MonoBehaviour
{
    /// <summary>
    /// 怪物最终目标
    /// </summary>
    [SerializeField]
    private Transform destination;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Monster")
            other.GetComponent<Monster>().target = destination;
    }
}
