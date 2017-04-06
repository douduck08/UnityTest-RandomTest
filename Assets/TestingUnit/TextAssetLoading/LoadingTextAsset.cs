using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class LoadingTextAsset : MonoBehaviour {

    public string filePath;
    private Text m_text;

    void Start () {
        m_text = GetComponent<Text> ();
    }

}
