using System.Collections.Generic;
using UnityEngine;
using Utility;
using System.IO;
using System.Linq;
using UnityEngine.UI;

namespace Infrastructure
{
    public class Saver : MonoBehaviour
    {
        public List<MonoBehaviour> OverwriteOnLoad;
        public List<MonoBehaviour> Smartblocks;
        public MainBuildUI mainBuildUI;
        public CString SaveDirectory;
        public InputField inputField;
        public bool readyToOverwrite;
        public RectTransform savesPanel;
        public GameObject ButtonPF;

        public void ShowUSure()
        {
            Debug.Log("USure?");
            readyToOverwrite = true;

        }
        void Awake()
        {
            inputField.onEndEdit.AddListener(OnSave);
        }
        public void UpdateSavesPanel()
        {
            var path = SaveDirectory.val;
            savesPanel.gameObject.DestroyKids();
            var dirs = Directory.GetDirectories(path);
            var ui = UIGenerator.GenerateUI(ButtonPF, savesPanel, dirs.Length, UILayout.Vertical);
            ui.Iteri((i, x) => x.GetComponentInChildren<Text>().text
                = dirs[i].Remove(0, path.Length + 1));
            ui.Iteri((i, x) => x.GetComponentInChildren<Button>()
                .onClick.AddListener(() => OnLoad(dirs[i].Remove(0, path.Length + 1))));

        }



        void OnSave(string SaveName)
        {
            var path = SaveDirectory.val;
            string newDir = SaveDirectory + @"\" + SaveName;

            //Directory.GetDirectories(path).Iter((x) => Debug.Log(x + " " + SaveDirectory + @"\" + SaveName));
            if (Directory.GetDirectories(path).Any((x) => x == newDir))
            {
                if (!readyToOverwrite)
                {
                    ShowUSure();
                }
                else
                {
                    ////// Delete Previous
                    Directory.Delete(newDir, true);
                    Save(newDir);
                }
            }
            else
            {
                Save(newDir);
            }


        }
        void Save(string newDir)
        {
            Directory.CreateDirectory(newDir);
            string OverwriteDir = newDir + @"/" + "Overwrite";
            string SmartBlockDir = newDir + @"/" + "SmartBlocks";
            Directory.CreateDirectory(OverwriteDir);
            Directory.CreateDirectory(SmartBlockDir);
            for (int i = 0; i < OverwriteOnLoad.Count; i++)
            {
                string jsonString = JsonUtility.ToJson(OverwriteOnLoad[i]);
                File.WriteAllText(OverwriteDir + @"/" + i + ".txt", jsonString);
            }
            var smartBlocks = mainBuildUI.gameObject.GetKids();

            UpdateSavesPanel();
        }

        void OnLoad(string SaveName)
        {
            var path = SaveDirectory.val;
            var saveDir = path + "/" + SaveName;
            var OverwriteDir = saveDir + "/" + "Overwrite";
            var overWriteFiles = Directory.GetFiles(OverwriteDir);
            for (int i = 0; i < OverwriteOnLoad.Count; i++)
            {
                string jsonString = File.ReadAllText(overWriteFiles[i]);
                JsonUtility.FromJsonOverwrite(jsonString, OverwriteOnLoad[i]);
            }

        }

        void SaveSmartBock(BuildingBlock block)
        {
            
        }

    }
}


