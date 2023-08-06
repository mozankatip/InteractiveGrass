using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GrassPainter))]
public class GrassPainterEditor : Editor
{
    private bool isErasing;
    private bool isPainting;

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        GrassPainter painter = (GrassPainter)target;

        // Add an erase button to the Inspector
        if (GUILayout.Button("Erase All Grass"))
        {
            painter.EraseAllGrass();
        }

    }

    private void OnSceneGUI()
    {
        GrassPainter painter = (GrassPainter)target;
        Event currentEvent = Event.current;

        switch (currentEvent.type)
        {
            case EventType.MouseDown:
                if (currentEvent.button == 0)
                {
                    HandleUtility.AddDefaultControl(GUIUtility.GetControlID(FocusType.Passive));
                    isPainting = true; // Set isPainting to true when the mouse is pressed
                    currentEvent.Use();
                }
                break;

            case EventType.MouseUp:
                if (currentEvent.button == 0)
                {
                    isPainting = false; // Set isPainting to false when the mouse is released
                    currentEvent.Use();
                }
                break;
        }

        if (isPainting) // Only paint grass if isPainting is true
        {
            Ray ray = HandleUtility.GUIPointToWorldRay(Event.current.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, float.MaxValue, painter.paintTargetLayer))
            {
                painter.StartPainting(hit.point, hit.normal);
            }
        }

        // Repaint the scene view while painting to show the changes immediately.
        if (isPainting)
        {
            SceneView.RepaintAll();
        }
    }
}
