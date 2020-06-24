using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerakPeluru : MonoBehaviour
{
    private Transform myTransfrom;
    public float tPeluru;
    private float _vAwal;
    private float _sudutTembak;
    private float _gravity;
    private Vector3 _posisiAwal;
    private float _sudutMeriam;
    private TankBehaviour tankBehaviour;
    private AudioSource audioSource;
    private bool isLanded = true;

    public GameObject ledakan;
    public AudioClip audioLedakan;
    public GameManajer gamemanajer;

    // Start is called before the first frame update
    void Start()
    {
        myTransfrom = transform;
        tankBehaviour = GameObject.FindObjectOfType<TankBehaviour>();
        _vAwal = tankBehaviour.VoPeluru;
        _sudutTembak = tankBehaviour.rotateValueY;
        _sudutMeriam = tankBehaviour.sudutMeriam;
        _posisiAwal = myTransfrom.position;
        audioSource = GetComponent<AudioSource>();
        _gravity = GameObject.FindObjectOfType<TankBehaviour>().gravity;
        gamemanajer = GameObject.FindObjectOfType<GameManajer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isLanded)
            tPeluru += Time.deltaTime;
        
        myTransfrom.position = PosisiTerbangPeluru(_posisiAwal, _vAwal, tPeluru, _sudutTembak, _sudutMeriam);
        gamemanajer._lamaWaktuTerbang = tPeluru;
    }

    private Vector3 PosisiTerbangPeluru(Vector3 _posisiAwal, float _vAwal, float _waktu, float _sudutTembak, float _sudutMeriam)
    {
        float _x = _posisiAwal.x + (_vAwal * _waktu * Mathf.Sin(_sudutMeriam * Mathf.PI / 180));
        float _y = _posisiAwal.y + ((_vAwal * _waktu * Mathf.Sin(_sudutTembak * Mathf.PI / 180)) - (0.5f * 10 * Mathf.Pow(_waktu,2)));
        float _z = _posisiAwal.z + (_vAwal * _waktu * Mathf.Cos(_sudutMeriam * Mathf.PI / 180));

        return new Vector3(_x, _y, _z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Land")
        {
            Destroy(this.gameObject, 2f);
            GameObject go = Instantiate(ledakan, myTransfrom.position, Quaternion.identity);
            Destroy(go, 3f);
            audioSource.PlayOneShot(audioLedakan);
            gamemanajer._jarakTembak = Vector3.Distance(_posisiAwal, myTransfrom.position);
            isLanded = false;
        }
    }
}
 