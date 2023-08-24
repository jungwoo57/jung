using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public int questId;
    public int questActionIndex;
    public GameObject[] questObject;
    Dictionary<int, QuestData> questList;

    void Awake()
    {
        questList = new Dictionary<int, QuestData>();
        GenerateData();
;    }

    void GenerateData() 
    {
        questList.Add(10, new QuestData("���� ������ ��ȭ�ϱ�", new int[] {1000,2000 }));
        questList.Add(20, new QuestData("NPC B�� ���� ã��", new int[] {2000,5000,2000}));

    }

    public int GetQuestTalkIndex(int id) 
    {
        id = questId + questActionIndex;
        return id;
    }

    public string checkQuest(int id) 
    {
        if (id == questList[questId].npcId[questActionIndex])
        {
            questActionIndex++;
        }
        ControlObject();
        
        if (questActionIndex == questList[questId].npcId.Length) 
        {
            NextQuest();
        }
        return questList[questId].questname;
    }

    public string checkQuest() 
    {
        return questList[questId].questname;
    }
    void NextQuest()
    {
        questId += 10;
        questActionIndex = 0;
    }
    public void ControlObject() 
    {
        switch (questId) 
        {
            case 10:
                if (questActionIndex == 2) questObject[0].SetActive(true);
                break;
            case 20:
                if (questActionIndex == 0)
                    questObject[0].SetActive(false);
                break;
        
        }
    }

}
