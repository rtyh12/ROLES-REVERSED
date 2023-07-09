using System.Collections;
using UnityEngine;
using TMPro;
using static SceneMaster;

public class DialogScript : MonoBehaviour {
    //const string kAlphaCode = "<color=#00000000>";
    const float kMaxTextTime = 0.1f;
    public static int TextSpeed = 2;
    private bool initiated = false;
    public bool pause = true;
    private bool end = false;

    public TMP_Text Text;
    public TMP_Text Next;
    private string currentText;
    private int currentTextIndex;
    private AudioSource audioSource;

    public string[] text = new string[] {
        "You are the regional district manager of the local evil horde. Your boss wants you to deal with some pesty little heroes by sending the troops in their direction. It is a simple desk job.",
        "The available troops come in, zou send them out in a way that makes sense and kills the hero. Easy. But damn! They kinda cute???? Maybe just send some easier monsters to scare them off but not kill them?",
        "Oh no they are still going… Thez look a little hungry though, maybe you should send them a snack? The boss won’t like that though… Guess you have to smuggle it to them using the horde. Hopefully they survive your romantic gift.",
    };

    //CanvasGroup Group;

    // Start is called before the first frame update
    void Start() {
        //Group = GetComponent<CanvasGroup>();
        //Group.alpha = 0;        
       
        audioSource = GetComponent<AudioSource>();
        currentTextIndex = 0;
    }

    public void Show(string text) {
        //Group.alpha = 1;
        currentText = text;
        StartCoroutine(DisplayText());
    }


    public void ReplaceText(string text) {
        Text.text = "";
        currentText = text;
        Show(text);
    }

    //didn't actually test this yet 
    public void Close() {

        //Group.alpha = 0;
        currentText = "";
        StopAllCoroutines();

    }

    // the thing that makes the text scroll
    private IEnumerator DisplayText() {
        Text.text = "";

        audioSource.Play();
        foreach (char c in currentText.ToCharArray()) {
            Text.text += c;
            yield return new WaitForSecondsRealtime(kMaxTextTime / TextSpeed);
        }

        if (Text.text == currentText) {
            audioSource.Stop();
            StopAllCoroutines();
        }
        yield return null;
    }

    private void showNext() {
        if (pause && !end) Next.text = ">>";
        else Next.text = "";
    }

    public void Update() {
        Debug.Log(initiated);
        if (!initiated)
        {
            initiated = SceneMaster.initiateEmailText;
            if (initiated)
            {
                Show(text[0]);
            }
        }
        else
        {
            pause = Text.text == currentText;
            showNext();

            if (pause && Input.GetMouseButtonDown(0))
            {
                pause = false;
                currentTextIndex++;
                if (currentTextIndex < text.Length)
                {
                    ReplaceText(text[currentTextIndex]);
                }
                else
                {
                    end = true;
                }
            }
            else
            {
                if (Input.GetMouseButtonDown(0))
                {
                    StopAllCoroutines();
                    Text.text = currentText;
                }
            }
        }
    }
}
