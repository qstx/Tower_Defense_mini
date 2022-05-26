using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyTowerDefense
{
    public class WatchTower : Tower
    {
        /// <summary>
        /// 子弹预制体
        /// </summary>
        [SerializeField]
        private GameObject BulletPrefab;
        /// <summary>
        /// 子弹发射点
        /// </summary>
        [SerializeField]
        private Transform firePoint;

        private bool isFireEnd = true;
        // Start is called before the first frame update
        protected override void Start()
        {
            base.Start();
        }

        // Update is called once per frame
        protected override void Update()
        {
            base.Update();
        }
        protected override void Fire()
        {
            if (!isFireEnd)
                return;
            isFireEnd = false;
            //Debug.Log("Fire");
            GameObject bullet = Instantiate(BulletPrefab, firePoint);
            Destroy(bullet, 1f);
            foreach (var monster in nearMonsters)
            {
                if (monster && !monster.Dead)
                    monster.Debuff = 0.2f;
            }
            StartCoroutine(WaitFire());
        }
        IEnumerator WaitFire()
        {
            yield return new WaitForSeconds(FireInterval * (1 - speedBuff));
            isFireEnd = true;
        }
        protected override void OnTriggerExit(Collider other)
        {
            base.OnTriggerExit(other);
            if (other.tag == "Monster")
            {
                Monster monster = other.GetComponent<Monster>();
                if(!monster.Dead)
                    monster.Debuff = 0f;
            }
        }
    }
}

