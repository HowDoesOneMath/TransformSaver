using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class SaveAndLoad : MonoBehaviour
{
    const string DLL_NAME = "TransformSaverDLL";

    [DllImport(DLL_NAME, CharSet = CharSet.Auto)]
    private static extern void SavePosition(float[] values);

    [DllImport(DLL_NAME, CharSet = CharSet.Auto)]
    private static extern System.IntPtr LoadPosition();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.C))
        {
            float[] vals = new float[9];
            for (int i = 0; i < 3; i++)
                vals[i] = transform.position[i];
            for (int i = 0; i < 3; i++)
                vals[i+3] = transform.rotation.eulerAngles[i];
            for (int i = 0; i < 3; i++)
                vals[i+6] = transform.localScale[i];

            //Debug.Log("HERE");
            SavePosition(vals);
            //Debug.Log("THERE");
        }

        if (Input.GetKey(KeyCode.P))
        {
            float[] vals = new float[9];
            Marshal.Copy(LoadPosition(), vals, 0, 9);

            Vector3 v = Vector3.zero;
            for (int i = 0; i < 3; i++)
            {
                v[i] = vals[i];
                
            }
            transform.position = v;

            v = Vector3.zero;
            for (int i = 0; i < 3; i++)
            {
                v[i] = vals[i + 3];
               
            }
            transform.rotation = Quaternion.Euler(v);

            v = Vector3.zero;
            for (int i = 0; i < 3; i++)
            {
                v[i] = vals[i + 6];
               
            }
            transform.localScale = v;
        }
    }
}
