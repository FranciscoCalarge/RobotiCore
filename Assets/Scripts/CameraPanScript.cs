using NUnit.Framework;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public class CameraPan {
    public GameObject from;
    public GameObject to;
    public float seconds;

}

public class CameraPanScript : MonoBehaviour
{
    [SerializeField]
    public List<CameraPan> panList;
    public List<GameObject> gameObjects;

    float lerpTime;
    int _cameraPanStep=0;
    private void Start()
    {
        Time.timeScale = 0f;
    }

    private void Update()
    {
        if (_cameraPanStep < panList.Count)
        {
            lerpTime += Time.unscaledDeltaTime /panList[_cameraPanStep].seconds;
            transform.position = Vector3.Lerp(panList[_cameraPanStep].from.transform.position, panList[_cameraPanStep].to.transform.position, lerpTime);
            transform.rotation = Quaternion.Lerp(panList[_cameraPanStep].from.transform.rotation, panList[_cameraPanStep].to.transform.rotation, lerpTime);
            if (lerpTime > 1f*panList[_cameraPanStep].seconds) {
                lerpTime = 0f;
                _cameraPanStep++;
            }
        }
        else
        {
            foreach (GameObject gobjs in gameObjects) {
                gobjs.SetActive(true);
            }
            Time.timeScale = 1f;
        }
    }
}
