using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class LookTo : MonoBehaviour
{

    public GameObject ground;
    public LayerMask water;
    public AudioMixerSnapshot groupA;
    public AudioMixerSnapshot groupB;
    public AudioMixerSnapshot groupC;
    bool lookedAtFire;
    bool lookedAtRadio;





    void Update()
    {
        Transform camera = Camera.main.transform;
        Ray ray;
        RaycastHit hit;
        GameObject hitObject;       

        Debug.DrawRay(camera.position, camera.rotation * Vector3.forward * 30f, Color.red);

        ray = new Ray(camera.position, camera.rotation * Vector3.forward*1f);

        if (Physics.Raycast(ray, out hit)) {

            hitObject = hit.collider.gameObject;

           // Debug.Log("The Object is " + hitObject);


            if (!lookedAtRadio && hitObject.gameObject.name == "Radio") {

                
                groupB.TransitionTo(1.5f);
                lookedAtRadio = true;

            }

            if (!lookedAtFire && hitObject.gameObject.name == "FireBoy")
            {

      
                groupA.TransitionTo(1.5f);
                lookedAtFire = true;

            }


            
        }



        if (Physics.SphereCast(camera.position, 5f, transform.forward, out hit, 1000, water))
        {
            hitObject = hit.collider.gameObject;

           // Debug.Log("The Object is (Spherecasting) " + hitObject);


            if (hitObject.gameObject.name == "CubeB")
            {

               /// Debug.Log("Object BBBBBBBBBBBBBB SPHERE");
                groupB.TransitionTo(1.5f);
            }

            if (hitObject.gameObject.name == "CubeA")
            {

                //Debug.Log("Object AAAAAAAAAAAAAA SPHERE");
                groupA.TransitionTo(1.5f);
            }

            //var distanceToObstacle = hit.distance;
        }
    }

    IEnumerator GetBack()
    {

        yield return new WaitForSeconds(3f);

    }
}
