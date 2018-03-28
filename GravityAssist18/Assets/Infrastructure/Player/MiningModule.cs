//using UnityEngine;
//using Utility;
//using System.Collections.Generic;
//using System;

//namespace Infrastructure
//{


//    public class MiningModule : MonoBehaviour
//    {
//        public Camera cam;
//        public Dictionary<Hexagon, Func<float>> HexesToMine = new Dictionary<Hexagon, Func<float>>();

//        public LayerMask HexLayer;
//        Hexagon curHex;
//        public float miningSkill = 20;
//        Hexagon prevHex;
//        Color prevCol;

//        public void ResetCol()
//        {
//            if (prevHex != null)
//            {
//                prevHex.ChangeColor(prevCol);
//            }
//        }

//        public void SelectHexes(Player player)
//        {
//            if (prevHex!=null)
//            {
//                prevHex.ChangeColor(prevCol);
//            }
//            var hex = MousePositioning.GetTypeUnderMouse<Hexagon>(cam, HexLayer);
//            if (hex != null)
//            {
//                if (Input.GetMouseButton(0) || Input.GetMouseButtonDown(0))
//                {

//                    if (Input.GetKey(KeyCode.LeftShift))
//                    {
//                        if (HexesToMine.ContainsKey(hex))
//                        {
//                            player.playerActions.Remove(HexesToMine[hex]);
//                            HexesToMine.Remove(hex);
//                            hex.ChangeColor(ColorManager.DefaultColor);
//                        }
//                    }
//                    else
//                    {
//                        if (!HexesToMine.ContainsKey(hex))
//                        {
//                            Func<float> fun = () => RemoveHex(hex);
//                            player.playerActions.Add(fun);
//                            HexesToMine.Add(hex, fun);
//                            hex.ChangeColor(ColorManager.ToMineColor);
//                        }
//                    }
//                }
//                else
//                {
//                    //prevHex = hex;
//                    //prevCol = hex.GetComponent<MeshRenderer>().material.color;
//                    //hex.ChangeColor(ColorManager.MouseOverColor);
//                }
//            }

//        }
//        public float RemoveHex(Hexagon hex)
//        {
//            var cost = hex.MiningCost / miningSkill;
//            HexesToMine.Remove(hex);
//            //EnemyAISpawner.positions.Add(hex.transform.position);
//            Destroy(hex.gameObject);

//            return cost;
//        }




//    }

//}


