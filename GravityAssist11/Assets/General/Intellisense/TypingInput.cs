using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System;

public class TypingInput : MonoBehaviour
{
    public InputField inputField;
    public AssemblyDB assemblyDB;
    public SuggestText suggestText;
    public int maxSuggest; 
    
    List<string> AssemblyNames = new List<string>();

    public void Start()
    {
        inputField.ActivateInputField();
        AssemblyNames = assemblyDB.AssemblyBois.Select(t => t.name).ToList();
        suggestText.Init();    
    }
 
    
    public void OnInputChanged()
    {
        var Suggestions = SuggestionFinder.GetSuggestions(inputField.text,maxSuggest)
    }


 }

public class ModeSwitcher : MonoBehaviour
{

}

public class AddresSwitcher
{
    public static List<Address> Curadresses;
    public static List<string> CurrentOptions;
    public static void ResetAddreses(List<Address> Adresses)
    {
        Curadresses = Adresses;
        CurrentOptions = Adresses.Select(t => t.name).ToList();
    }
    public static void GotoSubAdresses(string name)
    {
        Curadresses = Curadresses.Where(t => t.name == name).Single().GetSubAdresses();
        CurrentOptions = Curadresses.Select(t => t.name).ToList();
    }
    public static void AddOptions(string input,int maxSuggestions,SuggestText suggestText)
    {
        SuggestionFinder.GetSuggestions(input, maxSuggestions, CurrentOptions,suggestText);
    }
}