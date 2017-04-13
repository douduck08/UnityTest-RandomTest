using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectLoadTest : MonoBehaviour {

    public GameObject TestPrefab;
    public int TestAmountX = 100;
    public int TestAmountY = 100;
    public float ObjectGrid = 1f;
    public Vector3 Moving = new Vector3 (10, 10, 10);

    private List<GameObject> m_gameObjectList = new List<GameObject>();

	void Start () {
        float timer;

        timer = Time.realtimeSinceStartup;
        InstantiatePrefab ();
        Debug.Log (string.Format ("InstantiatePrefab: {0}", Time.realtimeSinceStartup - timer));

        timer = Time.realtimeSinceStartup;
        SetIntoGrid ();
        Debug.Log (string.Format ("SetIntoGrid: {0}", Time.realtimeSinceStartup - timer));

        timer = Time.realtimeSinceStartup;
        SetAllActive (false);
        Debug.Log (string.Format ("SetAllActive(false): {0}", Time.realtimeSinceStartup - timer));

        timer = Time.realtimeSinceStartup;
        SetAllActive (true);
        Debug.Log (string.Format ("SetAllActive(true): {0}", Time.realtimeSinceStartup - timer));

        timer = Time.realtimeSinceStartup;
        MovingAll ();
        Debug.Log (string.Format ("MovingAll: {0}", Time.realtimeSinceStartup - timer));
    }

    private void InstantiatePrefab () {
        for (int x = 0; x < TestAmountX; x++) {
            for (int y = 0; y < TestAmountY; y++) {
                m_gameObjectList.Add(GameObject.Instantiate<GameObject> (TestPrefab, this.transform));
            }
        }
    }

    private void SetIntoGrid () {
        for (int x = 0; x < TestAmountX; x++) {
            for (int y = 0; y < TestAmountY; y++) {
                m_gameObjectList[x * TestAmountY + y].transform.localPosition = new Vector2(x * ObjectGrid, y * ObjectGrid);
            }
        }
    }

    private void SetAllActive (bool active) {
        for (int x = 0; x < TestAmountX; x++) {
            for (int y = 0; y < TestAmountY; y++) {
                m_gameObjectList[x * TestAmountY + y].gameObject.SetActive(active);
            }
        }
    }

    private void MovingAll () {
        for (int x = 0; x < TestAmountX; x++) {
            for (int y = 0; y < TestAmountY; y++) {
                Vector3 newPos = m_gameObjectList[x * TestAmountX + y].transform.localPosition + Moving;
                m_gameObjectList[x * TestAmountY + y].transform.localPosition = newPos;
            }
        }
    }
}
