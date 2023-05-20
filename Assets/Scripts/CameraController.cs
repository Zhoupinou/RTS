using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float moveSpeed, zoomSpeed, rotateSpeed;
    public GameObject SelectedGameObject;
    
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        PlayerControls();
        
    }
    void PlayerControls()
    {
        if(Input.GetKey(KeyCode.A))
        {
            transform.Translate(-moveSpeed,0,0);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(moveSpeed,0,0);
        }
         else if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0,0,moveSpeed);
        }
          else if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0,0,-moveSpeed);
        }

        if(Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(0,-rotateSpeed,0);
        }

        else if(Input.GetKey(KeyCode.E))
        {
            transform.Rotate(0,rotateSpeed,0);
        }
        if(Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            //Zoom-
            transform.Translate(0,-zoomSpeed,0);
        }
        else if(Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            //Zoom+
            transform.Translate(0,zoomSpeed,0);
        }

        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, 100))
            {
                if(hit.collider.tag == "Selectable")
                {
                    //selection de l'objet
                    SelectedGameObject = hit.collider.gameObject;
                }
                
            }
        }
        if(Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, 100))
            {
                if(SelectedGameObject.tag == "Selectable")
                {
                     if(hit.collider.gameObject.GetComponent<RessourceType>())
                        {
                            if((hit.collider.gameObject.GetComponent<RessourceType>().ressource == RessourceTypes.Iron))
                            {
                                SelectedGameObject.GetComponent<TaskManager>().StartMining(hit.collider.gameObject);
                            }
                        }
                        else
                        {
                            SelectedGameObject.GetComponent<PeasantMovementController>().target = hit.point;
                        }
                    
                    
                }
                Debug.Log(hit.collider.gameObject.name);
            }
        }
    }
}
