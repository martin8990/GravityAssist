//using UnityEngine;
//using UnityEngine.UI;
//namespace Infrastructure
//{
//    public class MasterController : MonoBehaviour
//    {
//        public UIMode uiMode = UIMode.BUILD;
//        public Text ModeText;
//        public Button ModeButton;
//        public MainBuildUI mainBuildUI;
//        public MainActionUI mainActionUI;

//        public GameObject Action;
//        public GameObject BuildCanvas;


//        void Awake()
//        {
//            ModeText.text = "Build";
//            ModeButton.onClick.AddListener(OnModeButtonClick);
//            BuildCanvas.SetActive(true);
//            Action.SetActive(false);

//        }
//        public void OnModeButtonClick()
//        {
//            if (uiMode == UIMode.BUILD)
//            {

//                uiMode = UIMode.ACTION;
//                ModeText.text = "Live";
//                BuildCanvas.SetActive(false);
//                Action.SetActive(true);

//            }
//            else if (uiMode == UIMode.ACTION)
//            {
//                uiMode = UIMode.BUILD;
//                ModeText.text = "Build";
//                BuildCanvas.SetActive(true);
//                Action.SetActive(false);

//            }

//        }
//        void Update()
//        {
//            switch (uiMode)
//            {
//                case UIMode.BUILD:
//                    mainBuildUI.OnUpdate();
//                    break;
//                case UIMode.ACTION:
//                    mainActionUI.OnUpdate();
//                    break;
//                default:
//                    break;
//            }
//        }


//    }
//    public enum UIMode
//    {
//        BUILD,ACTION
//    }
//}
