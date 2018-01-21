using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Domain;
using Utility;
using UnityEngine.UI;

namespace Infrastructure
{
    

       
    public class Placer : MonoBehaviour
    {
        public Vector3Int GridResolution;
        public GameObject categoryButtonPF;
        public GameObject ObjButton;

        public GameObject CategoryPanel;
        public GameObject ObjectPanel;
        GameObject[] subUI = new GameObject[1];
        public List<Category> Catalogue = new List<Category>();
        Camera cam;
        bool placing;
        PlaceAble curPlaceAble;

        private void Start()
        {
            var UI = UIGenerator.GenerateUI(categoryButtonPF, CategoryPanel.transform, Catalogue.Count,UILayout.Horizontal);
            UI.Iteri((k, x) => x.GetComponentInChildren<Text>().text = Catalogue[k].name);
            UI.Iteri((k, x) => x.GetComponent<Button>().onClick.AddListener(() => DisplayUI(k)));


            cam = Camera.main;
        }

        public void DisplayUI(int catId)
        {
            subUI.Iter((x) => Destroy(x));
            subUI = UIGenerator.GenerateUI(ObjButton, ObjectPanel.transform, Catalogue[catId].gameObjects.Count, UILayout.Horizontal);
            subUI.Iteri((k, x) => x.GetComponentInChildren<Text>().text = Catalogue[catId].gameObjects[k].name);
            subUI.Iteri((k, x) => x.GetComponent<Button>().onClick.AddListener(() => Place(catId,k)));

        }

        public void Debug()
        {
            Place(0, 0);
        }
        public void Place(int CategoryId, int GOId)
        {
            var placeAbleGO = Instantiate(Catalogue[CategoryId].gameObjects[GOId]);
            placeAbleGO.transform.parent = transform;
            placing = true;
            curPlaceAble = placeAbleGO.GetComponent<PlaceAble>();
        }
        private void Update()
        {
            if (placing)
            {
                var pos = MousePositioning.MouseToWorldPos(cam);
                var posRound = new Vector3(
                    Mathf.Round(pos.x-curPlaceAble.scale.x/2f) + curPlaceAble.scale.x/2f,
                    Mathf.Round(pos.y) + curPlaceAble.scale.y/2f,
                    Mathf.Round(pos.z - curPlaceAble.scale.z / 2f)+ curPlaceAble.scale.z / 2f);
                curPlaceAble.transform.position = posRound;

                if (Input.GetMouseButtonDown(0))
                {
                    placing = false;
                    curPlaceAble.GetComponent<Collider>().enabled = true;
                }
            }
        }
    }
}
