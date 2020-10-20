using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideObstructingObjects : MonoBehaviour
{
    GameObject player;
    Collider obstruction;
    [SerializeField]
    LayerMask layerObstruction;                                               

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void LateUpdate()
    {
        RaycastHit hit;

        if(Physics.Raycast(transform.position,player.transform.position-transform.position,out hit,20f,layerObstruction))

       /* if (Physics.Raycast(transform.position, player.transform.position - transform.position, out hit, 20f)*/
        // if (Physics.Raycast(transform.position, player.transform.position - transform.position, out hit, 4.5f))
        {
            if (!hit.collider.CompareTag("Player") && !hit.collider.CompareTag("Hole"))
            {
                obstruction = hit.collider;
                MeshRenderer mesh;
                if (obstruction.TryGetComponent<MeshRenderer>(out mesh))
                    mesh.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.ShadowsOnly;
            }
            else
            {
                if (obstruction != null)
                {
                    MeshRenderer mesh;
                    if (obstruction.TryGetComponent<MeshRenderer>(out mesh))
                        obstruction.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
                }
            }
        }
    }

}
