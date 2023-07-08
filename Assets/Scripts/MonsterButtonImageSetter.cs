using UnityEngine;
using UnityEngine.UI;

public class MonsterButtonImageSetter : MonoBehaviour {
    public StateManager stateManager;
    private MonsterType monsterType;
    public Image buttonImage;
    public TipHover tipHover;

    void SetNextMonster() {
        monsterType = stateManager.RequestMonster();
        var monsterData = stateManager.GetMonsterDataFor(monsterType);
        buttonImage.sprite = monsterData.sprite;
        tipHover.tipToShow = monsterData.description;
    }

    void Start() {
        SetNextMonster();
        tipHover = GetComponent<TipHover>();
    }

    public void ClickButton() {
        Debug.Log(monsterType);
        SetNextMonster();
    }
}
