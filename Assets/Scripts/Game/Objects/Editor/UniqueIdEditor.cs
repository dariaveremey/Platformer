using System;
using System.Linq;
using P3D.Game.Utility;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEditor.TerrainTools;
using UnityEngine;

namespace P3D.Game.Objects.Editor
{
    [CustomEditor(typeof(UniqueId))]
    public class UniqueIdEditor : UnityEditor.Editor
    {
        private void OnEnable()
        {
            UniqueId uniqueId = (UniqueId) target;

            if (IsPrefab(uniqueId))
                return;
            if (string.IsNullOrEmpty(uniqueId.Id))
            {
                Generate(uniqueId);
            }
            else
            {
                UniqueId[] allUniqueIds = FindObjectsOfType<UniqueId>();
                if (allUniqueIds.Any(x => x != uniqueId && x.Id == uniqueId.Id))
                    Generate(uniqueId);
            }
        }

        private void Generate(UniqueId uniqueId)
        {
           uniqueId.Generate();
           if (!Application.isPlaying)
           {
               EditorUtility.SetDirty(uniqueId);
               EditorSceneManager.MarkSceneDirty(uniqueId.gameObject.scene);
           }
        }

        private bool IsPrefab(UniqueId uniqueId) =>
            uniqueId.gameObject.scene.rootCount == 0;
    }
}