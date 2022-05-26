using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyTowerDefense
{
    public class BallistaTower : Tower
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
        /// <summary>
        /// 子弹伤害
        /// </summary>
        [SerializeField]
        public int power = 100;
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
            Bullet bullet = Instantiate(BulletPrefab, firePoint).GetComponent<Bullet>();
            bullet.power = (int)(power*(1+powerBuff));
            bullet.target = nearMonsters[0];
            StartCoroutine(WaitFire());
        }
        IEnumerator WaitFire()
        {
            yield return new WaitForSeconds(FireInterval * (1 - speedBuff));
            isFireEnd = true;
        }
    }
}

