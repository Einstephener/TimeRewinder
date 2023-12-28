using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordManager : MonoBehaviour
{
    public static RecordManager instance;

    public GameObject StartRecordingImg;
    public GameObject StopRecordingImg;
    public GameObject StartRewindingImg;
    public GameObject StopRewindingImg;

    [HideInInspector] public bool isRewinding = false;
    [HideInInspector] public bool isRecording = false;
    [HideInInspector] public bool isPhoneOpen = false;
    public Animator animator;


    public float recordTime = 5f;
    private List<PointInTime> pointsInTime;

    public GameObject Player;
    Rigidbody rb;

    private void Awake()
    {
        rb = Player.GetComponent<Rigidbody>();
        instance = this;
    }
    // Use this for initialization
    void Start()
    {
        ImageSetFalse();
        animator = GetComponent<Animator>();
        pointsInTime = new List<PointInTime>();
    }

    void ImageSetFalse()
    {
        StartRecordingImg.SetActive(false);
        StopRecordingImg.SetActive(false);
        StartRewindingImg.SetActive(false);
        StopRewindingImg.SetActive(false);
    }

    void FixedUpdate()
    {
        if (isPhoneOpen)
        {
            if (isRewinding)
            {
                Rewind();
            }
            else
            {
                if (isRecording)
                {
                    Record();
                }
                else
                {
                    RecordStop();
                }
            }
        }

    }

    private void RecordStop()
    {
        ImageSetFalse();
        StopRecordingImg.SetActive(true);
    }

    void Record()
    {
        ImageSetFalse();
        StartRecordingImg.SetActive(true);
        if (pointsInTime.Count > Mathf.Round(recordTime / Time.fixedDeltaTime))
        {
            pointsInTime.RemoveAt(pointsInTime.Count - 1);
        }

        pointsInTime.Insert(0, new PointInTime(Player.transform.position, Player.transform.rotation));
    }

    void Rewind()
    {
        if (pointsInTime.Count > 0)
        {
            PointInTime pointInTime = pointsInTime[0];
            Player.transform.position = pointInTime.position;
            Player.transform.rotation = pointInTime.rotation;
            pointsInTime.RemoveAt(0);
        }
        else
        {
            StopRewind();
        }
    }

    public void StartRewind()
    {
        isRewinding = true;
        rb.isKinematic = true;
        ImageSetFalse();
        StartRewindingImg.SetActive(true);
    }

    public void StopRewind()
    {
        isRewinding = false;
        rb.isKinematic = false;
        ImageSetFalse();
        StopRewindingImg.SetActive(true);
    }       
}


public class PointInTime
{
    public Vector3 position;
    public Quaternion rotation;

    public PointInTime(Vector3 _position, Quaternion _rotation)
    {
        position = _position;
        rotation = _rotation;
    }
}