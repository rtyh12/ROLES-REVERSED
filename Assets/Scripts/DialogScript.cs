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
    private string FullText = "You are the regional district manager of the local evil horde. Your boss wants you to deal with some pesty little heroes by sending the troops in their direction. It is a simple desk job. ";
    
    //CanvasGroup Group;
    
    // Start is called before the first frame update
    void Start()
    {
        //Group = GetComponent<CanvasGroup>();
        //Group.alpha = 0;        
        Show(FullText);
    }

   public void Show(string text)
   {    
        //Group.alpha = 1;
        CurrentText = text;
        StartCoroutine(DisplayText());
   }


   //idk if i need this but maybe?
   public void ReplaceText(string text)
   {
        StopAllCoroutines();
        Text.text = "";
        FullText = text;
        Show(text);
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

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {   
            StopAllCoroutines();
            Text.text = FullText;
            Debug.Log("Pressed left-click.");
        }
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("Pressed right-click.");
        }
    }
}
