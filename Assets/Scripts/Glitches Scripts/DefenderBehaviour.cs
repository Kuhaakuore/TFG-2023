using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DefenderBehaviour : GlitchBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(ProtectAdjacentBlocks), 0, 5.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ProtectAdjacentBlocks()
    {
        foreach (var blockStatus in adjcentBlocks.Where(blockStatus => blockStatus != null))
        {
            if (blockStatus.modifier == BlockStatus.Modifier.Protected) continue;
            if (blockStatus.GetComponent<RegularBlockBehaviour>() != null)
            {
                blockStatus.gameObject.GetComponent<RegularBlockBehaviour>().ActivateProtection();
            }
            else if (blockStatus.GetComponent<PointerBlockBehaviour>() != null)
            {
                blockStatus.gameObject.GetComponent<PointerBlockBehaviour>().ActivateProtection();
            }
        }
    }

    protected override void Die()
    {
        Destroy(gameObject);
    }
}
