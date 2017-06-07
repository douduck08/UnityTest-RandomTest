using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class DelegateTest : MonoBehaviour {

    Action callback = null;
    ClassA testObject = null; 
	
    void Start() {
        AddCallback ();
        CountClassA ();
        RunCallback ();

        DestroyClassA ();
        RunCallback ();
        CountClassA ();

        CleanCallback ();
        RunCallback ();
        CountClassA ();
    }

    [InvokeButton]
    public void AddCallback() {
        if (testObject == null) {
            testObject = new ClassA ();
        }

        callback += testObject.FunctionA;
    }

    [InvokeButton]
    public void RunCallback () {
        if (callback != null) {
            callback ();
        } else {
            Debug.Log ("null callback");
        }
    }

    [InvokeButton]
    public void CleanCallback () {
        callback = null;
        GC.Collect ();
    }

    [InvokeButton]
    public void DestroyClassA() {
        testObject = null;
        GC.Collect ();
    }

    [InvokeButton]
    public void CountClassA () {
        Debug.Log ("ClassA count: " + ClassA.Count);
    }

}


public class ClassA {
    public static int Count = 0;
    
    public ClassA () {
        Count += 1;
    }

    ~ClassA () {
        Count -= 1;
    }

    public void FunctionA () {
        Debug.Log ("FunctionA called");
    }
}
