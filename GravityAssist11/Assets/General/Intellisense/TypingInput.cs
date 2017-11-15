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
    public Color Selected;
    public Color Unselected;

    public List<KeyCode> UpKeys;
    public List<KeyCode> DownKeys;
    public float KeyWaitTime;


    List<string> AssemblyNames = new List<string>();
    List<GameObject> SuggestObjects;
    List<Text> names;
    List<Image> images;

    public void Start()
    {
        inputField.ActivateInputField();
        AssemblyNames = assemblyDB.AssemblyBois.Select(t => t.name).ToList();
        SuggestObjects = GOMassInstantiator.MassInstantiate(SuggestPF, SuggestTF, maxSuggestions);
        UIPositioner.PositionVertically(SuggestTF, ComponentsGetter.GetFromGOS<RectTransform>(SuggestObjects));
        names = ComponentsGetter.GetFromGOSKids<Text>(SuggestObjects);
        images = ComponentsGetter.GetFromGOSKids<Image>(SuggestObjects);
        StartCoroutine(Intellisense.UpdateIndex(UpKeys, DownKeys, KeyWaitTime, Selected, Unselected, images));
    }
 
    
    public void OnInputChanged()
    {
        Intellisense.AutofillTextboxes(inputField, maxSuggestions, AssemblyNames, names);
        Intellisense.HighLightSelected(Selected, Unselected, images);
    }
 }