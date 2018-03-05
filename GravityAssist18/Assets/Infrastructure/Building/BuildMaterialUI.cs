using UnityEngine;
using Utility;
using UnityEngine.UI;
using System.Collections.Generic;

namespace Infrastructure
{
    public class BuildMaterialUI : MonoBehaviour
    {
        public List<BuildMaterial> buildMaterials;
        public int buildMaterialIndex;
        public RectTransform uiPanel;
        public GameObject buttonPrefab;
        
        private void Awake()
        {
            var gos = UIGenerator.GenerateUI(buttonPrefab, uiPanel, buildMaterials.Count, UILayout.Vertical);
            Image[] images = gos.Map((x) => x.GetComponent<Image>());
            images.Iteri((i, imag) => imag.color = buildMaterials[i].color);
            Button[] buttons = gos.Map((x) => x.GetComponent<Button>());
            buttons.Iteri((i, btn) => btn.onClick.AddListener(() => buildMaterialIndex = i));
        }
        public void SetCurBuildMaterial(CarvableBlock curBlock)
        {
            curBlock.materializer.buildMaterial = buildMaterials[buildMaterialIndex];
            curBlock.subDivider.buildMaterial = buildMaterials[buildMaterialIndex];
            curBlock.materializer.SetDefaultColor();
        }


    }
}
