using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyTowerDefense
{
    public enum BuffType { Speed,Power,Range}
    public class Buff : MonoBehaviour
    {
        public BuffType buffType;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
        public void PutBuff(Tower tower)
        {
            if (buffType == BuffType.Speed)
                tower.speedBuff = 0.2f;
            else if (buffType == BuffType.Power)
                tower.powerBuff = 0.2f;
            else if (buffType == BuffType.Range)
                tower.RangeBuff = 0.5f;
        }
    }
}

