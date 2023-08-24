using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;
    Dictionary<int, Sprite> ImageData;

    public Sprite[] ImagerArr;
    private void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        ImageData = new Dictionary<int, Sprite>();
        GenerateData();
    }

    void GenerateData() 
    {
        talkData.Add(1000, new string[] { "�ȳ�?:0", "�̰��� ó���Ա���:1" })  ;
        talkData.Add(3000, new string[] { "�̰��� �� �ڽ��Դϴ�" });
        talkData.Add(2000, new string[] { "�ݰ���:0" });
        

        ImageData.Add(1000 + 0, ImagerArr[4]);
        ImageData.Add(1000 + 1, ImagerArr[5]);
        ImageData.Add(1000 + 2, ImagerArr[6]);
        ImageData.Add(1000 + 3, ImagerArr[7]);

        ImageData.Add(2000 + 0, ImagerArr[0]);
        ImageData.Add(2000 + 1, ImagerArr[1]);
        ImageData.Add(2000 + 2, ImagerArr[2]);
        ImageData.Add(2000 + 3, ImagerArr[3]);

        //Quest Talk
        talkData.Add(1000 + 10, new string[] { "�ȳ�:0", "NPC B���� ����:1" });
        talkData.Add(2000 + 11, new string[] { "�Ա���:1", "������ �� ã���ٷ�?:0", "�� �Ʒ��� �����ž�:3" });

        talkData.Add(2000 + 20, new string[] { "�� ã�ƿ���:3" });
        talkData.Add(5000 + 21, new string[] { "������", "������ ã�ҽ��ϴ�." });
        talkData.Add(2000 + 22, new string[] { "ã�ұ���:1" });

       
    }

    public string GetTalk(int id, int talkIndex)
    {

        if (!talkData.ContainsKey(id))
            if (!talkData.ContainsKey(id - id % 10))
            {
                return GetTalk(id - id % 100, talkIndex);
            }
            else
            {
                return GetTalk(id - id % 10, talkIndex);
            }
        if (talkIndex == talkData[id].Length)
            return null;
        else
            return talkData[id][talkIndex];
    }

    public Sprite GetImage(int id, int ImageIndex) 
    {
        return ImageData[id + ImageIndex];
    }
}
