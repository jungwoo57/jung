using System.Collections;
using System.Collections.Generic;

public class QuestData
{
    public string questname;
    public int[] npcId;

    public QuestData(string name, int[] npc) 
    {
        questname = name;
        npcId = npc;
    }
}
