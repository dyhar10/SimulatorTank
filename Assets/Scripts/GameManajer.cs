using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManajer : MonoBehaviour
{
    public GameObject go_sudutMeriam;
    public GameObject go_sudutTembak;
    public GameObject go_gravitasi;
    public GameObject go_jarak;
    public GameObject go_vAwal;
    public GameObject go_tTerbang;

    public GameObject _torque;
    public GameObject _selongsong;

    public float _lamaWaktuTerbang;
    public float _jarakTembak;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        go_sudutMeriam.GetComponent<Text>().text = _torque.GetComponent<TankBehaviour>().sudutMeriam.ToString();
        go_sudutTembak.GetComponent<Text>().text = _torque.GetComponent<TankBehaviour>().rotateValueY.ToString();
        go_gravitasi.GetComponent<Text>().text = _torque.GetComponent<TankBehaviour>().gravity.ToString();
        go_jarak.GetComponent<Text>().text = _jarakTembak.ToString();
        go_vAwal.GetComponent<Text>().text = _torque.GetComponent<TankBehaviour>().VoPeluru.ToString();
        go_tTerbang.GetComponent<Text>().text = _lamaWaktuTerbang.ToString();
    }
}
