using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class TankBehaviour : MonoBehaviour
{
    private Transform myTransform;
    private GameObject selongsong;
    private GameObject titikTembak;
    private string stateRotateVertical;
    private AudioSource audioSource;

    [HideInInspector]public float rotateValueY;
    [HideInInspector]public float sudutMeriam;

    public float VoPeluru = 5;
    public float RotateSpeed = 20;
    public float gravity = 10;

    public AudioClip audioLedakan;
    public AudioClip audioTembakan;
    public GameObject objekTembakan;
    public GameObject objekLedakan;
    public GameObject peluruMeriam;
    
    
    // Start is called before the first frame update
    void Start()
    {
        myTransform = transform;
        selongsong = myTransform.Find("selongsong").gameObject;
        titikTembak = selongsong.transform.Find("TitikTembak").gameObject;
        audioSource = selongsong.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        sudutMeriam = myTransform.localEulerAngles.z;
        rotateValueY = 360 - selongsong.transform.localEulerAngles.x;
        //Rotasi Horizontal
        if (Input.GetKey(KeyCode.T))
        {
            myTransform.Rotate(Vector3.back * RotateSpeed * Time.deltaTime, Space.Self);
        }
        else if (Input.GetKey(KeyCode.U))
        {
            myTransform.Rotate(Vector3.forward * RotateSpeed * Time.deltaTime, Space.Self);
        }

        //StateRules
        if(rotateValueY == 0 || rotateValueY == 360)
        {
            stateRotateVertical = "aman";
        }
        else if(rotateValueY > 0 && rotateValueY < 15)
        {
            stateRotateVertical = "aman";
        }
        else if(rotateValueY > 15 && rotateValueY < 16)
        {
            stateRotateVertical = "atas";
        }
        else if(rotateValueY > 350)
        {
            stateRotateVertical = "bawah";
        }

        //Rotasi Vertical
        if (stateRotateVertical == "aman")
        {
            if (Input.GetKey(KeyCode.Y))
            {
                selongsong.transform.Rotate(Vector3.left * RotateSpeed * Time.deltaTime, Space.Self);
            }
            else if (Input.GetKey(KeyCode.H))
            {
                selongsong.transform.Rotate(Vector3.right * RotateSpeed * Time.deltaTime, Space.Self);
            }
        }
        else if(stateRotateVertical == "bawah")
        {
            selongsong.transform.localEulerAngles = new Vector3(
                -0.5f, selongsong.transform.localEulerAngles.y, selongsong.transform.localEulerAngles.z);
        }
        else if (stateRotateVertical == "atas")
        {
            selongsong.transform.localEulerAngles = new Vector3(
                -14.5f, selongsong.transform.localEulerAngles.y, selongsong.transform.localEulerAngles.z);
        }

        #region Penembakan
        if (Input.GetKey(KeyCode.Space))
        {
            GameObject peluru = Instantiate(peluruMeriam, titikTembak.transform.position,
                Quaternion.Euler(
                    selongsong.transform.localEulerAngles.x,
                    myTransform.localEulerAngles.z,
                    0));
            GameObject efekTembakan = Instantiate(objekTembakan, titikTembak.transform.position,
                Quaternion.Euler(
                    selongsong.transform.localEulerAngles.x,
                    myTransform.localEulerAngles.z, 0
                    ));
            Destroy(efekTembakan, 2f);
            //Destroy(peluru, 1f);

            audioSource.PlayOneShot(audioTembakan);
        }
        #endregion
    }
}
