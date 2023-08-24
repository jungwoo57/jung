using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypeEffect : MonoBehaviour
{
    // Start is called before the first frame update

    string targetMsg;
    public int CharPerSeconds;
    public GameObject EndCursor;
    public bool isAnim;
    Text msgText;
    AudioSource audioSource;
    int index;
    float interval;
    

    public void Awake()
    {
        msgText = GetComponent<Text>();
        audioSource = GetComponent<AudioSource>();       //EndCursor = GetComponent<GameObject>();
    }
    public void SetMsg(string msg)
    {
        if (isAnim) 
        {
            msgText.text = targetMsg;
            CancelInvoke();
            EffectEnd();
        }
        else
        {
            targetMsg = msg;
            EffectStart();
        }
 ;
    }

    // Update is called once per frame
    void EffectStart()
    {
        msgText.text="";
        index = 0;
        EndCursor.SetActive(false);

        interval = 1.0f / CharPerSeconds;
        Debug.Log(interval);
        isAnim = true;
        Invoke("Effecting",interval);

    }

    void Effecting()
    {
        if (msgText.text == targetMsg) {
            EffectEnd();
            return;
        }
        msgText.text += targetMsg[index];
        if (targetMsg[index] != ' ' || targetMsg[index] !='.') {
            audioSource.Play();
        }
        Invoke("Effecting", interval);
        index++;
    }

    void EffectEnd() 
    {
        isAnim = false;
        EndCursor.SetActive(true);
        
    }
}
