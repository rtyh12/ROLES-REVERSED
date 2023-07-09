using System.Collections.Generic;

using UnityEngine;

public enum MonsterType {
    Basic,
    Stronger,
    Banona,
    Doctor,
    Dog,
    Flower,
    STRONK_DUCK,
    None,
}

// this here bc dictionaries dont appear in the inspector
// (i kinda hate this aaaa)
[System.Serializable]
public struct MonsterData {
    public MonsterType type;
    public Sprite sprite;
    public GameObject prefab;
    public string description;
}

public class StateManager : MonoBehaviour {
    public List<MonsterType> upcomingMonsters = new List<MonsterType>();
    private int lastSentMonsterIndex = -1;

    public MonsterData[] monsterData;

    public MonsterData GetMonsterDataFor(MonsterType monsterType) {
        int index = System.Array.FindIndex<MonsterData>(
            monsterData,
            monsterData => monsterData.type == monsterType);

        return monsterData[index];
    }

    public MonsterType RequestMonster() {
        lastSentMonsterIndex++;
        bool doWeStillHaveMonsters = lastSentMonsterIndex < upcomingMonsters.Count;
        return doWeStillHaveMonsters ? upcomingMonsters[lastSentMonsterIndex] : MonsterType.None;
    }

    public void Spawn(MonsterType monsterType) {
        var monsterData = GetMonsterDataFor(monsterType);
        Instantiate(monsterData.prefab, new Vector3(7f, 0f, 0f), Quaternion.identity);
    }
}
