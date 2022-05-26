using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace MyTowerDefense
{
    public enum InputState { Norm, ShowTower, ShowUI };
    public class InputManager : MonoBehaviour
    {
        static public InputManager singleton;
        [SerializeField]
        public InputState inputState = InputState.Norm;
        /// <summary>
        /// 要进行操作的塔
        /// </summary>
        [SerializeField]
        private Tower tower;
        /// <summary>
        /// 要进行删除操作的平台
        /// </summary>
        [SerializeField]
        private Platform platform;
        private void Awake()
        {
            if (!singleton)
                singleton = this;
            else
                Debug.LogError("InputManager singleton");
        }
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (inputState == InputState.Norm)
            {
                if (!EventSystem.current.IsPointerOverGameObject() && Input.GetMouseButtonDown(0))
                {
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    if (Physics.Raycast(ray, out RaycastHit raycastHit, 100) && raycastHit.collider.tag == "Platform" && raycastHit.collider.GetComponent<Platform>().tower)
                    {
                        inputState = InputState.ShowUI;
                        platform = raycastHit.collider.GetComponent<Platform>();
                        platform.ShowUI();
                        platform.UI.GetComponentInChildren<Button>().onClick.AddListener(delegate { OnClearBtnClicked(); });
                    }
                }
            }
            else if (inputState == InputState.ShowTower)
            {
                if (Input.GetMouseButtonDown(1))
                {
                    inputState = InputState.Norm;
                    Destroy(tower.gameObject);
                    return;
                }
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if(!EventSystem.current.IsPointerOverGameObject() && Physics.Raycast(ray,out RaycastHit raycastHit, 100) && raycastHit.collider.tag == "Platform")
                {
                    tower.gameObject.SetActive(true);
                    tower.transform.position = raycastHit.point;
                    //platform = raycastHit.collider.GetComponent<Platform>();
                    //platform.GetComponent<MeshRenderer>().material.color = Color.red;
                    if (Input.GetMouseButtonDown(0) && !raycastHit.collider.GetComponent<Platform>().tower)
                    {
                        if (tower.cost > GameManager.singleton.Money)
                            return;
                        else
                            GameManager.singleton.Money -= tower.cost;
                        platform = raycastHit.collider.GetComponent<Platform>();
                        platform.tower = tower;
                        if (platform.buff)
                            platform.buff.PutBuff(tower);
                        tower.transform.position = raycastHit.collider.transform.position;
                        tower.Initial();
                        inputState = InputState.Norm;
                        return;
                    }
                }
                else
                {
                    tower.gameObject.SetActive(false);
                    //if(platform)
                    //    platform.GetComponent<MeshRenderer>().material.color = Color.white;
                }
            }
            else if (singleton.inputState == InputState.ShowUI)
            {
                if (!EventSystem.current.IsPointerOverGameObject() && Input.GetMouseButtonDown(0))
                {
                    Destroy(platform.UI);
                    singleton.inputState = InputState.Norm;
                }
            }
        }
        public void OnTowerIconClicked(int towerTpye)
        {
            if (inputState != InputState.Norm)
                return;
            tower = Instantiate(TowerManager.singleton.TowerPrefabs[towerTpye]).GetComponent<Tower>();
            tower.gameObject.SetActive(false);
            inputState = InputState.ShowTower;
        }
        private void OnClearBtnClicked()
        {
            GameManager.singleton.Money += platform.tower.cost / 2;
            Destroy(platform.UI);
            Destroy(platform.tower.gameObject);
            singleton.inputState = InputState.Norm;
        }
    }
}

