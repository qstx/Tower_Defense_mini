using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyTowerDefense
{
    public class Destination : MonoBehaviour
    {
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
            {
                WaveManager.singleton.OnMonsterDead(other.GetComponent<Monster>());
                Destroy(other.gameObject);
            }
        }
    }
}

