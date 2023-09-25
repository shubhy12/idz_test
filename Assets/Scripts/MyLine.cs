using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyLine : MonoBehaviour
{
    public Sprite lineImage;
    public float lineWidth = 0.1f;
    public Image pencil;
    public float pencilMoveSmoothness = 1.0f;
    public float pencilMoveSpeed = 1.0f;
    public List<GameObject> lines = new List<GameObject>();

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
        float tanDiff = dif.x != 0 ? dif.y / dif.x : Mathf.Infinity;
        rect.rotation = Quaternion.Euler(new Vector3(0, 0, 180 * Mathf.Atan(tanDiff) / Mathf.PI));

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

    internal IEnumerator MovePencil(Vector3 from, Vector3 to)
    {
        float t = 0;
        WaitForSeconds forSeconds = new WaitForSeconds(pencilMoveSmoothness);
        while (!(pencil.transform.position == to))
        {
            t += pencilMoveSmoothness;
            Vector3 lerpPos = Vector3.Lerp(from, to, t * pencilMoveSpeed);
            pencil.transform.position = lerpPos;
            yield return forSeconds;
        }
        pencil.transform.position = to;
    }
}
