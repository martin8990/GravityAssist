using UnityEngine.UI;
using UnityEngine;
namespace Infrastructure
{
    public class PlayerBudget : MonoBehaviour
    {
        public static int budget = 1000;
        public static Text BudgetText;
        public Text budgetText;
        private void Awake()
        {
            BudgetText = budgetText;     
        }

        public static void AddMoney(int Added)
        {
            budget += Added;
            BudgetText.text = "$ : " + budget;
        }
    }

}


