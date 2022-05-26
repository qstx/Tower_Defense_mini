using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyTowerDefense
{
    public class Bullet : MonoBehaviour
    {
        public float speed = 1;
        public int power = 100;
        /// <summary>
        /// Ä¿±ê¹ÖÎï
        /// </summary>
        public Monster target;
        // Start is called before the first frame update
        void Start()
        {
            Destroy(gameObject, 10);
        }

        // Update is called once per frame
        void Update()
        {
            if (!target.Dead)
                transform.LookAt(target.hitPoint);
            else
                Destroy(gameObject,0.1f);
            transform.Translate(Vector3.forward * speed, Space.Self);
        }
    }
}

