﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawPath : MonoBehaviour
{
    public Color lineColor;
    private List<Transform> nodes = new List<Transform>();

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = lineColor;

        Transform[] pathTransforms = GetComponentsInChildren<Transform>();
        nodes = new List<Transform>();

        for (int i = 0; i < pathTransforms.Length; i++)
        {
            if (pathTransforms[i] != transform)
            {
                nodes.Add(pathTransforms[i]);
            }
        }

        for (int i = 0; i < nodes.Count; i++)
        {
            Vector3 currentNode = nodes[i].position;
            Vector3 perviousNode = Vector3.zero;

            if (i > 0)
            {
                perviousNode = nodes[i - 1].position;
            }
            else if (i == 0 && nodes.Count > 1)
            {
                perviousNode = nodes[nodes.Count - 1].position;
            }

            Gizmos.DrawLine(perviousNode, currentNode);
            Gizmos.DrawWireSphere(currentNode, 0.3F);
        }
    }
}
