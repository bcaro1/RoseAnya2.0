using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint_Joseph : MonoBehaviour
{
    #region Protected
    [SerializeField]
    protected float DrawRadius = 1f;
    #endregion

    public virtual void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, DrawRadius);
    }
}
