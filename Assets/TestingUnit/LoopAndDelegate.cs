using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class LoopAndDelegate : MonoBehaviour {

    public int testTimes;

    private int m_count = 0;
    private float m_timer;

    private Action m_action;
    private event Action m_event;

    void Start () {
        StartTimer ();
        for (int i = 0; i < testTimes; i++) {
            m_action += PlusOne;
        }
        ShowTimer ("Prepare Action");

        StartTimer ();
        for (int i = 0; i < testTimes; i++) {
            m_event += PlusOne;
        }
        ShowTimer ("Prepare Event");

        StartTimer ();
        for (int i = 0; i < testTimes; i++) {
            PlusOne ();
        }
        ShowTimer ("For loop");

        StartTimer ();
        m_action ();
        ShowTimer ("Action");

        StartTimer ();
        m_event ();
        ShowTimer ("Event");
    }
	
    private void PlusOne () {
        m_count += 1;
    }

    private void StartTimer() {
        m_timer = Time.realtimeSinceStartup;
    }

    private void ShowTimer (string title) {
        Debug.Log (string.Format ("{0}: {1}", title, Time.realtimeSinceStartup - m_timer));
    }
}
