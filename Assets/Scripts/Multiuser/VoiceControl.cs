using System.Collections;
using Photon.Voice.Unity;
using System.Collections.Generic;
using UnityEngine;

public class VoiceControl : MonoBehaviour
{

    public Recorder VoiceRecorder;
    public GameObject MutedIcon;
    public GameObject UnmutedIcon;

    // Print state of voice recorder
    void Start()
    {
        VoiceRecorder.TransmitEnabled = true;       //Transmit state by default
        Debug.Log("Recorder state = " + VoiceRecorder.TransmitEnabled);
        MutedIcon = GameObject.Find("MutedIcon");
        UnmutedIcon = GameObject.Find("UnmutedIcon");
        muteIconUpdate(VoiceRecorder.TransmitEnabled);
    }

    void Update()
    {
        //Find GameObjects if they were lost on level change
        if (MutedIcon == null)
        {
            // MutedIcon = GameObject.Find("MutedIcon");
            muteIconUpdate(VoiceRecorder.TransmitEnabled);
            Debug.Log("Found MutedIcon");
        }
        if (UnmutedIcon == null)
        {
        // UnmutedIcon = GameObject.Find("UnmutedIcon");
        VoiceRecorder.TransmitEnabled = true;           //Unmute upon level load
        muteIconUpdate(VoiceRecorder.TransmitEnabled);
        Debug.Log("Found UnmutedIcon");
        }

        //If the M key is pressed, toggle between mute and unmute icons, and change transmit state
        if (Input.GetKeyDown(KeyCode.M))
        {
            VoiceRecorder.TransmitEnabled = !VoiceRecorder.TransmitEnabled;
            if (VoiceRecorder.TransmitEnabled)
            {
                Debug.Log("Microphone Unmuted.");
                muteIconUpdate(VoiceRecorder.TransmitEnabled);
            }
            else
            {
                Debug.Log("Microphone Muted.");
                muteIconUpdate(VoiceRecorder.TransmitEnabled);
            }
        }
    }

    void muteIconUpdate(bool transmitState)
    {
        if (transmitState)
        {
            UnmutedIcon.SetActive(true);        //toggle unmuted icon On
            MutedIcon.SetActive(false);
        }
        else
        {
            MutedIcon.SetActive(true);          //toggle muted icon on
            UnmutedIcon.SetActive(false);
        }
    }

}