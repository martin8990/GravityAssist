using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
public class TypingInput : MonoBehaviour
{
    public InputField inputField;
    public AssemblyDB assemblyDB;
    public GameObject SuggestPF;
    public Transform SuggestTF;
    
    public int maxSuggestions;
    public Transform poolParent;

    List<string> AssemblyNames = new List<string>();
    List<GameObject> SuggestObjects;
    List<Text> names;

    public void Start()
    {
        inputField.ActivateInputField();
        AssemblyNames = assemblyDB.AssemblyBois.Select(t => t.name).ToList();
        SuggestObjects = GOMassInstantiator.MassInstantiate(SuggestPF, SuggestTF, maxSuggestions);
        UIPositioner.PositionVertically(SuggestTF, ComponentsGetter.GetFromGOS<RectTransform>(SuggestObjects));
        names = ComponentsGetter.GetFromGOSKids<Text>(SuggestObjects);
    }
    public void OnInputChanged()
    {
        if (inputField.text.Length>0)
        {
            var similarWords = Intellisense.GetSimilarWords(inputField.text, AssemblyNames,maxSuggestions,0.5f);
            int maxWords = Mathf.Min(maxSuggestions, similarWords.Count);
            for (int i = 0; i < maxWords; i++)
            {
                names[i].text = similarWords[i];
            }
            for (int i = maxWords; i < maxSuggestions; i++)
            {
                names[i].text = "";
            }
        }        
    }
    public void OnEnter()
    {
        Debug.Log("Enter");
        inputField.ActivateInputField();
    }
}