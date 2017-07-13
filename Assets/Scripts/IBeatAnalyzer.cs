using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;

public struct BeatTiming {
    public float timing;
    public float loudness;

    public BeatTiming(float _timing, float _loudness) {
        timing = _timing;
        loudness = _loudness;
    }
}


public class IBeatAnalyzer : MonoBehaviour {
    public TextAsset beatTimingsForSong;
    JObject beatData;
    Rigidbody rb;

    List<BeatTiming> timings = new List<BeatTiming>();
    public float timer;
    public float loudness;
    int index = 0;

    public float forceMultiplier = 1.5f;

    void Awake() {
        beatData = JObject.Parse(beatTimingsForSong.text);

        //Loop over all the timings and store the beat data!
        float bpm = float.Parse(beatData["rhythm"]["bpm"].ToString());
        Debug.Log("BPM: " + bpm);

        //Debug.Log(((JArray)beatData["lowlevel"]["barkbands_kurtosis"]).Count);
        //Debug.Log(((JArray)beatData["rhythm"]["beats_loudness"]).Count);

        JArray bpmLoudness = (JArray)beatData["rhythm"]["beats_loudness"];
        JArray bpmTimings = (JArray)beatData["rhythm"]["beats_position"];
        for(int i = 0; i < bpmLoudness.Count; i++) {
            timings.Add(new BeatTiming(
                float.Parse(bpmTimings.ElementAt(i).ToString()),
                float.Parse(bpmLoudness.ElementAt(i).ToString())));
        }

        //Get the first time and set it as the first amount!
        timer = timings.First().timing;
        loudness = timings.First().loudness;


        //Debug.Log(beatData["lowlevel"]["average_loudness"]);
        //JToken acme = o.SelectToken("$.Manufacturers[?(@.Name == 'Acme Co')]");
        //Debug.Log(acme.ToString());
    }

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        if(Time.time >= timer) {
            //Make the rigidbody go fly fly!
            rb.AddForce(Vector3.up * forceMultiplier * loudness, ForceMode.Impulse);

            index++;
            timer = timings[index].timing;
            loudness = timings[index].loudness;
        }
    }
}
