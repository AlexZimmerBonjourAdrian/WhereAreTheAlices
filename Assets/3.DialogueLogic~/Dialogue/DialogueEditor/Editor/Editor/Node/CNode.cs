using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using System.Security.Policy;

public class CNode  
{

    public Rect rect;
    public string title;

    public GUIStyle style;

    public bool isDragged;

    public CNode(Vector2 position, float width, float height, GUIStyle nodeStyle)
    {
        rect = new Rect(position.x, position.y, width, height);
        style = nodeStyle;
    }
    // Start is called before the first frame update
    public void Draw()
    {
        GUI.Box(rect, title, style);
    }
    public void Drag(Vector2 delta)
    {
        rect.position += delta;
    }
    public bool ProcessEvents(Event e)
    {
        switch (e.type)
        {
            case EventType.MouseDown:
                if (e.button == 0)
                {
                    if (rect.Contains(e.mousePosition))
                    {
                        isDragged = true;
                        GUI.changed = true;
                    }
                    else
                    {
                        GUI.changed = true;
                    }
                }
                break;

            case EventType.MouseUp:
                isDragged = false;
                break;

            case EventType.MouseDrag:
                if (e.button == 0 && isDragged)
                {

                    Drag(e.delta);
                    e.Use();
                    return true;
                }
                break;
        }
        return false;
    }
}
