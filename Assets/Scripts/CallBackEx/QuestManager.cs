using UnityEngine;

public class QuestManager : MonoBehaviour , IQuestCallBacks
{
    [SerializeField] private Monster monster;
    private int killCount = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        monster.callBacks = this;
    }

    public void OnMonsterKilled(string monstername)
    {
        killCount++;
        Debug.Log($"{monstername}처치 수 : {killCount}");

        if (killCount > 0)
        {
            Debug.Log("퀘스트 완료");
        }
    }

}
