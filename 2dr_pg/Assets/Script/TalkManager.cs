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
        talkData.Add(1000, new string[] { "안녕?:0", "이곳에 처음왔구나:1" })  ;
        talkData.Add(3000, new string[] { "이것은 빈 박스입니다" });
        talkData.Add(2000, new string[] { "반갑다:0" });
        

        ImageData.Add(1000 + 0, ImagerArr[4]);
        ImageData.Add(1000 + 1, ImagerArr[5]);
        ImageData.Add(1000 + 2, ImagerArr[6]);
        ImageData.Add(1000 + 3, ImagerArr[7]);

        ImageData.Add(2000 + 0, ImagerArr[0]);
        ImageData.Add(2000 + 1, ImagerArr[1]);
        ImageData.Add(2000 + 2, ImagerArr[2]);
        ImageData.Add(2000 + 3, ImagerArr[3]);

        //Quest Talk
        talkData.Add(1000 + 10, new string[] { "안녕:0", "NPC B에게 가봐:1" });
        talkData.Add(2000 + 11, new string[] { "왔구나:1", "동전을 좀 찾아줄래?:0", "저 아래에 있을거야:3" });

        talkData.Add(2000 + 20, new string[] { "꼭 찾아와줘:3" });
        talkData.Add(5000 + 21, new string[] { "떨어진", "코인을 찾았습니다." });
        talkData.Add(2000 + 22, new string[] { "찾았구나:1" });

       
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
