using System;
using System.Diagnostics;
using AudioToolbox;
using AVFoundation;
using Foundation;
using Xamarin.Forms;
using XTravelAlarm.Features.AlarmRinging;
using XTravelAlarm.iOS.Services;

[assembly: Dependency(typeof(iOSAlarmRinger))]

namespace XTravelAlarm.iOS.Services
{
    public class iOSAlarmRinger : NSObject, IRinger, IAVAudioPlayerDelegate
    {
        private static AVAudioPlayer audioPlayer;

        public iOSAlarmRinger()
        {
            ActivateAudioSession();
        }

        private void ActivateAudioSession()
        {
            // Initialize Audio
            var session = AVAudioSession.SharedInstance();
            session.SetCategory(AVAudioSessionCategory.Ambient);
            session.SetActive(true);
        }

        public void PlaySound()
        {
            // Check if audioPlayer is currently playing
            if (audioPlayer != null)
            {
                audioPlayer.Stop();
                audioPlayer.Dispose();
            }
            else
            {
                var mp3File = "Sounds/Alarm.mp3";
                var mp3URL = new NSUrl(mp3File);
                Debug.WriteLine(mp3URL.AbsoluteUrl);
                var mp3 = AudioFile.Open(mp3URL, AudioFilePermission.Read, AudioFileType.MP3);
                if (mp3 != null)
                {
                    Debug.WriteLine(mp3.EstimatedDuration);
                    audioPlayer = AVAudioPlayer.FromUrl(mp3URL);
                    audioPlayer.Play();
                }
                else
                {
                    Debug.WriteLine("File could not be loaded: {0}", mp3URL.FilePathUrl);
                }
            }
        }

        public static void StopPlaySound()
        {
            try
            {
                //Stop of any sound effect
                audioPlayer.Stop();
                Debug.WriteLine("Alarm został wyłączony");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error when sound is stopped: {ex.Message}");
            }
        }
    }
}

