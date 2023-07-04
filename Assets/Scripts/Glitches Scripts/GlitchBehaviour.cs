using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class GlitchBehaviour : MonoBehaviour
{
     protected List<BlockStatus> adjcentBlocks = new List<BlockStatus>();

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.isTrigger)
        {
            adjcentBlocks.Add(other.GetComponent<BlockStatus>());
        }
    }

    protected abstract void Die();
}
