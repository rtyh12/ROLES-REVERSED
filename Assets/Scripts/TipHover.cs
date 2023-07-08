using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class TipHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
    public string tipToShow;
    
    private float timeToWait = 0.5f;
    public void OnPointerEnter(PointerEventData eventData) {
        StopAllCoroutines();
        StartCoroutine(StartTimer());
    }

    public void OnPointerExit(PointerEventData eventData) {
        StopAllCoroutines();
        TipManager.OnMouseLoseFocus();
    }

    private void ShowMessage() {
        TipManager.OnMouseHover(tipToShow, Input.mousePosition);
    }

    private IEnumerator StartTimer() {
        yield return new WaitForSeconds(timeToWait);

        ShowMessage();
    }
}
