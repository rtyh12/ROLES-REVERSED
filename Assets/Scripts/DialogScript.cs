using System.Collections;
using UnityEngine;
using TMPro;

public class DialogScript : MonoBehaviour
{
    //const string kAlphaCode = "<color=#00000000>";
    const float kMaxTextTime = 0.1f;
    public static int TextSpeed = 2;

    public TMP_Text Text;
    private string currentText; 

    private string firstText = "You are the regional district manager of the local evil horde. Your boss wants you to deal with some pesty little heroes by sending the troops in their direction. It is a simple desk job. ";
    private string secondText = "The available troops come in, zou send them out in a way that makes sense and kills the hero. Easy. But damn! They kinda cute???? Maybe just send some easier monsters to scare them off but not kill them?" ;
    private string thirdText = "Oh no they are still going… Thez look a little hungry though, maybe you should send them a snack? The boss won’t like that though… Guess you have to smuggle it to them using the horde. Hopefully they survive your romantic gift.";
    
    //CanvasGroup Group;
    
    // Start is called before the first frame update
    void Start()
    {
        //Group = GetComponent<CanvasGroup>();
        //Group.alpha = 0;        
        Show(firstText);
    }

   public void Show(string text)
   {    
        //Group.alpha = 1;
        currentText = text;
        StartCoroutine(DisplayText());
   }


   //idk if i need this but maybe?
   public void ReplaceText(string text)
   {    
        StopAllCoroutines();
        Text.text = "";
        currentText = text;
        Show(text);
   }

    //didn't actually test this yet 
    public void Close()
    {
        //Anim?.SetBool("Open", false);\
        //Group.alpha = 0;
        currentText = "";
        StopAllCoroutines();
        
    }

    // the thing that makes the text scroll
    private IEnumerator DisplayText()
    {
        Text.text = "";

        foreach(char c in currentText.ToCharArray())
        {   
            Text.text += c;

            yield return new WaitForSecondsRealtime(kMaxTextTime / TextSpeed);
        }
        yield return null;
    }

    /*void Update()
    {   
        if (Input.GetMouseButtonDown(0))
        {   
            StopAllCoroutines();
            Text.text = currentText;
            yield return new WaitForSeconds(0.2f);
            Debug.Log("Pressed left-click.");
        }
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("Pressed right-click.");
        }
        //yield return new WaitForSeconds(0.2f);
        
        if (Text.text == firstText){
            ReplaceText(secondText);
        } else if (Text.text == secondText){
            ReplaceText(thirdText);
        }
    }*/
}
