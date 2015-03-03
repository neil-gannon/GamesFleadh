using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(Curve))]
public class CurveInspector : Editor
{
    private Curve curve;
    private Transform handleTransform;
    private Quaternion handleRotation;

    private void OnSceneGUI()
    {
        curve = target as Curve;
        Curve.PointPair[] pairs = new Curve.PointPair[curve.Points.Length / 2];

        handleTransform = curve.transform;
        handleRotation = Tools.pivotRotation == PivotRotation.Local ? handleTransform.rotation : Quaternion.identity;

        for (int i = 0; i < curve.Points.Length; i++)
        {
            if (i + 1 < curve.Points.Length)
            {
                Vector3 p0 = ShowPoint(i);
                Vector3 p1 = ShowPoint(i + 1);

                if (i < pairs.Length)
                    pairs[i] = new Curve.PointPair() { P0 = p0, P1 = p1 };
            }
        }

        Handles.color = Color.red;

        foreach (var p in pairs)
            Handles.DrawLine(p.P0, p.P1);
    }

    private Vector3 ShowPoint(int index)
    {
        Vector3 point = handleTransform.TransformPoint(curve.Points[index]);

        EditorGUI.BeginChangeCheck();

        point = Handles.DoPositionHandle(point, handleRotation);

        if (EditorGUI.EndChangeCheck())
        {
            Undo.RecordObject(curve, "Move Point");
            EditorUtility.SetDirty(curve);
            curve.Points[index] = handleTransform.InverseTransformPoint(point);
        }

        return point;
    }
}
