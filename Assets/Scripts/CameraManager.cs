using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraManager : MonoBehaviour
{
    public static CameraManager Instance;
    public enum eCamera
    {
        MainCam,
        Cam2,
        Cam3,
    }

    [SerializeField] List<GameObject> listCamObj;
    [SerializeField] List<Button> listBtns;

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        switchCamera(eCamera.MainCam);
        initBtns();
    }

    private void initBtns()
    {
        int count = listBtns.Count;
        for (int iNum = 0; iNum < count; iNum++)
        {
            int value = iNum;//이걸 안하면 바뀐값이 계속 적용됨
            listBtns[iNum].onClick.AddListener(() => switchCamera(value));
        }
    }

    private void switchCamera(eCamera _value)
    {
        int count = listCamObj.Count;
        for (int iNum = 0; iNum < count; iNum++)
        {
            int value = (int)_value;

            listCamObj[iNum].SetActive(iNum == value);//위의 주석 한줄로 정리
        }
    }
    private void switchCamera(int _value)
    {
        int count = listCamObj.Count;
        for (int iNum = 0; iNum < count; iNum++)
        {
            int value = (int)_value;

            listCamObj[iNum].SetActive(iNum == value);//위의 주석 한줄로 정리
        }
    }
}
