using System.Collections;
using UnityEngine;
using TMPro;

public class DialogScript : MonoBehaviour
{
    //const string kAlphaCode = "<color=#00000000>";
    const float kMaxTextTime = 0.1f;
    public static int TextSpeed = 2;

    public TMP_Text Text;
    private string CurrentText; 

    //CanvasGroup Group;
    
    // Start is called before the first frame update
    void Start()
    {
        //Group = GetComponent<CanvasGroup>();
        //Group.alpha = 0;        
        Show("some text idk blububububu");
    }

   public void Show(string text)
   {    
        //Group.alpha = 1;
        CurrentText = text;
        StartCoroutine(DisplayText());
   }

    public void Close()
    {
        //Anim?.SetBool("Open", false);\
        //Group.alpha = 0;
        CurrentText = "";
        StopAllCoroutines();
        
    }

    private IEnumerator DisplayText()
    {
        Text.text = "";

        foreach(char c in CurrentText.ToCharArray())
        {   
            Text.text += c;

            yield return new WaitForSecondsRealtime(kMaxTextTime / TextSpeed);
        }
        yield return null;
    }
}
