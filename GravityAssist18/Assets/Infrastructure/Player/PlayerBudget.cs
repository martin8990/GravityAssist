using UnityEngine.UI;
using UnityEngine;
namespace Infrastructure
{
    public class PlayerBudget : MonoBehaviour
    {
        public static int budget = 100;
        public static Text BudgetText;
        public Text budgetText;
        private void Awake()
        {
            budgetText.text = "$ : " + budget;
            BudgetText = budgetText;     
        }

        public static void AddMoney(int Added)
        {
            budget += Added;
            BudgetText.text = "$ : " + budget;
        }
        public static void RemoveMoney(int amount)
        {
            budget -= amount;
            BudgetText.text = "$ : " + budget;

        }
    }

}


