using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;

public class MyLine : MonoBehaviour
{
    public Sprite lineImage;
    public float lineWidth = 0.1f;
    public List<GameObject> lines = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void MakeLine(Vector2 from, Vector2 to, Color col)
    {
        GameObject NewObj = new GameObject();
        NewObj.name = "line from " + from + " to " + to;
        Image NewImage = NewObj.AddComponent<Image>();
        NewImage.sprite = lineImage;
        NewImage.color = col;
        RectTransform rect = NewObj.GetComponent<RectTransform>();
        rect.SetParent(transform);
        rect.localScale = Vector3.one;

        Vector3 a = new Vector3(from.x, from.y, 0);
        Vector3 b = new Vector3(to.x, to.y, 0);


        rect.localPosition = (a + b) / 2;
        Vector3 dif = a - b;
        rect.sizeDelta = new Vector3(dif.magnitude, lineWidth);
        rect.rotation = Quaternion.Euler(new Vector3(0, 0, 180 * Mathf.Atan(dif.y / dif.x) / Mathf.PI));

        lines.Add(NewObj);
    }
    [ContextMenu("ResetLines")]
    public void Reset()
    {
        foreach (GameObject line in lines)  //can use opject pooling
        {
            if (line != null)
                if (Application.isPlaying)
                    Destroy(line);
                else
                {
                    DestroyImmediate(line);
                }
        }
        lines.Clear();
    }
}
