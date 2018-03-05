using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Events;

namespace Infrastructure
{

    public class MainBuildUI : MonoBehaviour
    {
        public HistoryManager historyManager;
        public MouseBuildUI mouseBuildUI;
        public BuildMaterialUI BuildMaterialUI;

        public SmartBlockBuilder smartBlockBuilder;
        public SmartBlockCompleter smartBlockCompleter;

        public BuildUIMode mode;
        CarvableBlock curBlock;
        
        private void Start()
        {
           
            smartBlockBuilder.OnNewSmartblock = ((x) => BuildMaterialUI.SetCurBuildMaterial(x));
            smartBlockBuilder.OnNewSmartblock +=((x) => mode = BuildUIMode.MouseDrag);
            smartBlockBuilder.OnNewSmartblock +=((x) => curBlock = x);

            mouseBuildUI.newBlock.AddListener(smartBlockBuilder.BuildSmartBlock);
            mouseBuildUI.stopped.AddListener(() => mode = BuildUIMode.Normal);
            mouseBuildUI.completed.AddListener(() => smartBlockCompleter.CompleteBlock(curBlock));
            smartBlockCompleter.blockCompleted = ((x) => historyManager.AddElement(x));
        }
  
        public void Update()
        {
            switch (mode)
            {
                case BuildUIMode.Normal:
                    historyManager.OnUpdate();
                    break;
                case BuildUIMode.MouseDrag:
                    mouseBuildUI.OnUpdate(curBlock);
                    break;
                case BuildUIMode.Editing:
                    break;
                default:
                    break;
            }     
        }
       



    }
}
public enum BuildUIMode
{
    Normal,
    MouseDrag,
    Editing
}
