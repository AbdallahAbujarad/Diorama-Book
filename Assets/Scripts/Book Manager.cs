using UnityEngine;
using System.Collections.Generic;
public class BookManager : MonoBehaviour
{
    private float counterAfterDragged = 0;
    public float timeBetween = 3;
    public GameObject cam;
    public Vector3 camTargetPosition;
    public Vector3 camTargetRotation;
    public Vector3 camSecondTargetPosition;
    public Vector3 camSecondTargetRotation;
    public float camLerpSpeed = 1f;
    public List<GameObject> flip1;
    public List<Vector3> flip1positions;
    public List<Vector3> flip1rotations;
    public List<Vector3> end1positions;
    public List<Vector3> end1rotations;
    public List<GameObject> flip2;
    public List<Vector3> flip2positions;
    public List<Vector3> flip2rotations;
    public List<Vector3> end2positions;
    public List<Vector3> end2rotations;
    public List<GameObject> flip3;
    public List<Vector3> flip3positions;
    public List<Vector3> flip3rotations;
    public List<Vector3> end3positions;
    public List<Vector3> end3rotations;
    public List<GameObject> flip4;
    public List<Vector3> flip4positions;
    public List<Vector3> flip4rotations;
    public List<Vector3> end4positions;
    public List<Vector3> end4rotations;
    public Color nightColor;
    public Light directionalLight;
    public float flipLerpSpeed = 1f;
    public float nightLerpSpeed;
    public GameObject casing21;
    public Vector3 casing21targetPosition;
    public GameObject casing22;
    public Vector3 casing22targetPosition;

    private void Update() {
        if (BoxOpen.stoppedDragging)
        {
            cam.transform.position = Vector3.Lerp(cam.transform.position,camTargetPosition,Time.deltaTime*camLerpSpeed);
            cam.transform.rotation = Quaternion.Lerp(cam.transform.rotation,Quaternion.Euler(camTargetRotation),Time.deltaTime*camLerpSpeed);
            counterAfterDragged += Time.deltaTime;
            Flip(flip1,flip1positions,flip1rotations,flipLerpSpeed);
        }
        if (counterAfterDragged > timeBetween)
        {
            Flip(flip1,end1positions,end1rotations,flipLerpSpeed*3);
            Flip(flip2,flip2positions,flip2rotations,flipLerpSpeed);
            if (counterAfterDragged > timeBetween+1)
            {
                Deactivator(flip1);
            }
        }
        if (counterAfterDragged > timeBetween*2)
        {
            Flip(flip2,end2positions,end2rotations,flipLerpSpeed*3);
            Flip(flip3,flip3positions,flip3rotations,flipLerpSpeed);
            directionalLight.color = Color.Lerp(directionalLight.color,nightColor,Time.deltaTime*nightLerpSpeed);
            directionalLight.intensity = 0.2f;
            directionalLight.shadowStrength = 0.8f;
            if (counterAfterDragged > timeBetween*2+1)
            {
                Deactivator(flip2);
            }
        }
        if (counterAfterDragged > timeBetween*3)
        {
            Flip(flip3,end3positions,end3rotations,flipLerpSpeed*3);
            Flip(flip4,flip4positions,flip4rotations,flipLerpSpeed);
            if (counterAfterDragged > timeBetween*3+1)
            {
                Deactivator(flip3);
            }
        }
        if (counterAfterDragged > timeBetween*4)
        {
            cam.gameObject.transform.position = Vector3.Lerp(cam.transform.position,camSecondTargetPosition,Time.deltaTime*flipLerpSpeed);
            cam.gameObject.transform.rotation = Quaternion.Lerp(cam.transform.rotation,Quaternion.Euler(camSecondTargetRotation),Time.deltaTime*flipLerpSpeed);
            if (counterAfterDragged > timeBetween*4+1)
            {
                Deactivator(flip4);
            }
        }
        if (counterAfterDragged > timeBetween*4.5f)
        {
            casing21.gameObject.transform.position =Vector3.Lerp(casing21.gameObject.transform.position,casing21targetPosition,Time.deltaTime*flipLerpSpeed);
            casing22.gameObject.transform.position =Vector3.Lerp(casing22.gameObject.transform.position,casing22targetPosition,Time.deltaTime*flipLerpSpeed);
        }
    }
    private void Flip(List<GameObject> gameObjects,List<Vector3> positions,List<Vector3> rotations,float lerpSpeed)
    {
        for (int i = 0; i < gameObjects.Count; i++)
        {
            gameObjects[i].transform.position = Vector3.Lerp(gameObjects[i].transform.position,positions[i],Time.deltaTime*lerpSpeed);
            gameObjects[i].transform.rotation = Quaternion.Lerp(gameObjects[i].transform.rotation,Quaternion.Euler(rotations[i]),Time.deltaTime*lerpSpeed);
        }
    }
    private void Deactivator(List<GameObject> gameObjects)
    {
        for (int i = 1; i < gameObjects.Count; i++)
        {
            gameObjects[i].SetActive(false);
        }
    }

}
