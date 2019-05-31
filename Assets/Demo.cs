using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using com.mob.mobpush;
using System;

public class Demo : MonoBehaviour {

    public MobPush mobPush;

    void Start()
    {
        mobPush = gameObject.GetComponent<MobPush>();
        mobPush.onNotifyCallback = OnNitifyHandler;
        mobPush.onTagsCallback = OnTagsHandler;
        mobPush.onAliasCallback = OnAliasHandler;
        mobPush.onDemoReqCallback = OnDemoReqHandler;
        mobPush.onRegIdCallback = OnRegIdHandler;
        mobPush.onBindPhoneNumCallback = OnBindPhoneNumHandler;

        // IPHONE 要想收到 APNs 和本地通知，必须先要 setCustom (only ios)
#if UNITY_IPHONE

        // 真机调试 false , 上线 true
        mobPush.setAPNsForProduction(false);

        CustomNotifyStyle style = new CustomNotifyStyle();
        style.setType(CustomNotifyStyle.AuthorizationType.Badge | CustomNotifyStyle.AuthorizationType.Sound | CustomNotifyStyle.AuthorizationType.Alert);
        mobPush.setCustomNotification(style);

#endif
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }



    void OnNitifyHandler(int action, Hashtable resulte)
    {
        Debug.Log("OnNitifyHandler");
        if (action == ResponseState.CoutomMessage)
        {
            Debug.Log("CoutomMessage:" + MiniJSON.jsonEncode(resulte));
        }
        else if (action == ResponseState.MessageRecvice)
        {
            Debug.Log("MessageRecvice:" + MiniJSON.jsonEncode(resulte));
        }
        else if (action == ResponseState.MessageOpened)
        {
            Debug.Log("MessageOpened:" + MiniJSON.jsonEncode(resulte));
        }
    }

    void OnTagsHandler(int action, string[] tags, int operation, int errorCode)
    {

        Debug.Log("OnTagsHandler  action:" + action + " tags:" + String.Join(",", tags) + " operation:" + operation + "errorCode:" + errorCode);
    }

    void OnAliasHandler(int action, string alias, int operation, int errorCode)
    {
        Debug.Log("OnAliasHandler action:" + action + " alias:" + alias + " operation:" + operation + "errorCode:" + errorCode);
    }

    void OnRegIdHandler(string regId)
    {
        Debug.Log("OnRegIdHandler-regId:" + regId);
    }

    void OnBindPhoneNumHandler(bool isSuccess)
    {
        Debug.Log("OnBindPhoneNumHandler-result:" + isSuccess);
    }

    void OnDemoReqHandler(bool isSuccess)
    {
        Debug.Log("OnDemoReqHandler:" + isSuccess);
    }
}
