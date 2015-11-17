using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour
{

    [SerializeField]
    GameObject Player;

    RaycastHit oldHit;
    Color oldColor;
    bool sameGameobject = false;

    float rangeToPlayer;

    // Use this for initialization
    void Start()
    {

        rangeToPlayer = Vector3.Distance(transform.position, Player.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        OpacityRaycast();

    }

    /// <summary>
    /// Not complete!!
    /// </summary>
    private void OpacityRaycast()
    {
        RaycastHit hit;

        Debug.DrawRay(transform.position, Player.transform.position - transform.position);
        Ray rayToPlayer = new Ray(transform.position, Player.transform.position - transform.position);

        if (Physics.Raycast(rayToPlayer, out hit, rangeToPlayer))
        {
            sameGameobject = true;
            if (oldHit.collider != null)
            {
                if (hit.collider.gameObject != oldHit.collider.gameObject)
                {
                    if (hit.collider.tag == "EnviromentToOpacity")
                    {
                        Renderer oldhitObject = oldHit.collider.gameObject.GetComponent<Renderer>();
                        oldhitObject.material.color = oldColor;
                    }
                }
                else
                {
                    sameGameobject = false;
                }
            }
            if (hit.collider.tag == "EnviromentToOpacity")
            {
                Renderer hitObject = hit.collider.gameObject.GetComponent<Renderer>();
                Color newColor = hitObject.material.color;
                if (!sameGameobject)
                {
                    oldColor = hitObject.material.color;
                }
                newColor.a -= 0.01f;
                if (hitObject.material.color.a > 0.4f)
                {
                    hitObject.material.color = newColor;
                }

            }

        }

    }
}
