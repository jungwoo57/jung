using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TypeEffect talk;
    public Animator talkPanel;
    public GameObject scanObject;
    public Animator NpcImageAnim;
    public bool isAction;
    public TalkManager TalkManager;
    public QuestManager QuestManager;
    public Image NpcImage;
    public int talkIndex;
    public Sprite prevImage;
    public GameObject menuSet;
    public GameObject questSet;
    public GameObject Player;
    public Text questtext;

    public void Start()
    {
        talkPanel.SetBool("isShow",false);
        Debug.Log(QuestManager.checkQuest());
        questtext.text= QuestManager.checkQuest();
        GameLoad();
    }
    void Update() 
    {

        if (Input.GetButtonDown("Cancel"))
        {
            if (menuSet.activeSelf)
            {
                menuSet.SetActive(false);
                questSet.SetActive(false);
            }
            else
            {
                Debug.Log("esc눌리는중");
                menuSet.SetActive(true);
                questSet.SetActive(true);
            }
            
        }
    }
    // Update is called once per frame
    public void Action(GameObject scanObj)
    {
                  
            scanObject = scanObj;
            ObjectData objData = scanObject.GetComponent<ObjectData>();
            Talk(objData.id, objData.isNpc);
            talkPanel.SetBool("isShow",isAction);
     }

    void Talk(int id, bool isNpc)
    {
        int questTalkIndex = 0;
        string talkdata = "";
        if (talk.isAnim)
        {
            talk.SetMsg("");
            return;
        }
        else
        {
            questTalkIndex = QuestManager.GetQuestTalkIndex(id);
            talkdata = TalkManager.GetTalk(id + questTalkIndex, talkIndex);
        }
        if (talkdata == null) {
            isAction = false;
            talkIndex = 0;
            questtext.text = QuestManager.checkQuest(id);
            return;
        }
        if (isNpc)
        {
            talk.SetMsg(talkdata.Split(':')[0]);
            NpcImage.sprite = TalkManager.GetImage(id, int.Parse(talkdata.Split(':')[1]));
            NpcImage.color = new Color(1, 1, 1, 1);
            if (prevImage != NpcImage.sprite)
            {
                NpcImageAnim.SetTrigger("doEffect");
                prevImage = NpcImage.sprite;
            }
            }
        else {
            talk.SetMsg(talkdata);
            NpcImage.color = new Color(1, 1, 1, 0);
        }

        isAction = true;
        talkIndex++;
    }

    public void GameSave() 
    {
        PlayerPrefs.SetFloat("PlayerX", Player.transform.position.x);
        PlayerPrefs.SetFloat("PlayerY", Player.transform.position.y);
        PlayerPrefs.SetFloat("QuestId", QuestManager.questId);
        PlayerPrefs.SetFloat("QuestActionIndex", QuestManager.questActionIndex);
        PlayerPrefs.Save();
        menuSet.SetActive(false);
        //player.x ,y
        //questId/
        //questIndex
    }
    public void GameLoad()
    {
        if (!PlayerPrefs.HasKey("PlayerXx"))
            return;
        
        float x = PlayerPrefs.GetFloat("PlayerX");
        float y = PlayerPrefs.GetFloat("PlayerY");
        int questId = PlayerPrefs.GetInt("QuestId");
        int questActionIndex = PlayerPrefs.GetInt("QuestActionIndex");

        Player.transform.position = new Vector3(x, y, 0);
        QuestManager.questId = questId;
        QuestManager.questActionIndex = questActionIndex;
        QuestManager.ControlObject();
        
    }
    public void GameExit() 
    {
        Application.Quit();
    }
}
