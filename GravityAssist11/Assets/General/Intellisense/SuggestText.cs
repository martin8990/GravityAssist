using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SuggestText : MonoBehaviour
{

    public GameObject SuggestPF;
    public Transform SuggestTF;

    public int maxSuggestions;
    public Color Selected;
    public Color Unselected;

    public List<KeyCode> UpKeys;
    public List<KeyCode> DownKeys;
    public int maxWords;

    List<GameObject> SuggestObjects;
    List<Text> names;
    List<Image> images;
    float KeyWaitTime;
    int index = 0;

    public void Init()
    {
        SuggestObjects = GOMassInstantiator.MassInstantiate(SuggestPF, SuggestTF, maxSuggestions);
        UIPositioner.PositionVertically(SuggestTF, ComponentsGetter.GetFromGOS<RectTransform>(SuggestObjects));
        names = ComponentsGetter.GetFromGOSKids<Text>(SuggestObjects);
        images = ComponentsGetter.GetFromGOSKids<Image>(SuggestObjects);
        StartCoroutine(UpdateIndex());
    }


    public IEnumerator UpdateIndex()
    {

        foreach (var key in UpKeys)
        {
            if (Input.GetKey(key))
            {
                index++;
                if (index >= maxWords)
                {
                    index = 0;

                }
                yield return new WaitForSeconds(KeyWaitTime);
                HighLightSelected();
            }

        }
        foreach (var key in DownKeys)
        {
            if (Input.GetKey(key))
            {
             
                index--;
                if (index < 0)
                {
                    index = 0;
                }
                yield return new WaitForSeconds(KeyWaitTime);
                HighLightSelected();
            }

        }
        yield return null;
        StartCoroutine(UpdateIndex());

    }
    public void ShowSuggestions(List<string> words) 
    {
        for (int i = 0; i < words.Count; i++)
        {
            names[i].text = words[i];
        }
        index = 0;
        HighLightSelected();
        
    }


    public void HighLightSelected()
    {
        for (int i = 0; i < maxWords; i++)
        {
            if (i == index)
            {
                images[i].color = Selected;
            }
            else
            {
                images[i].color = Unselected;
            }
        }
    }


}
