using UnityEngine;
using System.Collections;
using UnitySampleAssets.CrossPlatformInput;
using System.Text.RegularExpressions;
public class dash2 : MonoBehaviour
{
    int recCommandLength =98;
    
    string inputCommands = "";
    public Transform playermove;
    public float Dashspeed = 10;
    public float Dashtime = 3;
    float horizontal, vertical;
    float time;
    int a = 0;
    int size;
    Vector3 lookPos;
    float[,] stick = new float[100, 100];
    float[,] checkframe = new float[30, 30];
    // Use this for initialization
    void Start()
    {
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        horizontal = CrossPlatformInputManager.GetAxisRaw("Horizontal");
        vertical = CrossPlatformInputManager.GetAxisRaw("Vertical");
        getAxis();
    }
    void getAxis()
    {
        if (a >= 99)
        {
            a = 1;
            //stick[,] = new float[recCommandLength, recCommandLength];
        }
        stick[0,a] = horizontal;
        stick[1,a] = vertical;
        confirmCommand();
        a++;
    }
    void confirmCommand()
    {
        //
        int comLength = 30;
        if (a <=comLength)
        {
            size = a;
        }
        else
        {
            size = a - comLength;
        }
        //
        if (stick[0, a] != 0 || stick[1, a] != 0)
        {
            for (int i = 0; i < size; i++)
            {
                if (checkframe[0, i] >= -1 * stick[0, a] - 0.4f &&
                checkframe[0, i] <= -1 * stick[0, a] + 0.4f &&
                checkframe[1, i] >= -1 * stick[1, a] - 0.4f &&
                checkframe[1, i] <= -1 * stick[1, a] + 0.4f)
                for (int q = 0; i < size-i; q++)
                {
                    if (checkframe[0, i - q] >=stick[0, a] - 0.4f &&
                    checkframe[0, i - q] <=stick[0, a] + 0.4f &&
                    checkframe[1, i - q] >=stick[1, a] - 0.4f &&
                    checkframe[1, i - q] <=stick[1, a] + 0.4f)
                    {
                        break;
                        StartCoroutine("dash");
                    }
                }
            }
        }
        //Debug.Log(checkframe);
    }
    IEnumerator dash()
    {
        if (time >= Dashtime)
        {
            time = 0;
            Debug.Log("dash");
            for (int i = 0; i < 60; i++)
            {
                Vector3 movement = new Vector3(horizontal, 0, vertical);
                playermove.GetComponent<Rigidbody>().AddForce(movement * Dashspeed, ForceMode.Acceleration);
                yield return null;
            }
            Debug.Log("end");
        }
    }
}
