using UnityEditor;
using UnityEngine;

namespace Game.Objects.Editor
{
    [CustomEditor(typeof(MovingObject))]
    public class MovingObjectEditor : UnityEditor.Editor
    {
        [DrawGizmo(GizmoType.Selected | GizmoType.NonSelected)]
        private static void Draw(MovingObject movingObject, GizmoType gizmoType)
        {
            if (!ShouldDraw(movingObject, gizmoType))
                return;

            if (movingObject.FromTransform == null || movingObject.ToTransform == null)
                return;

            Gizmos.color = Color.red;
            var fromTransformPosition = movingObject.FromTransform.position;
            var toTransformPosition = movingObject.ToTransform.position;

            Gizmos.DrawSphere(fromTransformPosition, 0.4f);
            Gizmos.DrawSphere(toTransformPosition, 0.4f);

            Gizmos.color = Color.green;
            Gizmos.DrawLine(fromTransformPosition, toTransformPosition);
        }

        private static bool ShouldDraw(MovingObject movingObject, GizmoType gizmoType)
        {
            if (gizmoType == GizmoType.Selected)
                return true;
            
            Transform parent = movingObject.transform.parent;
            if (parent == Selection.activeTransform)
                return true;

            for (int i = 0; i < parent.childCount; i++)
            {
                if (parent.GetChild(i) == Selection.activeTransform)
                    return true;
            }

            return false;
        }
    }
}