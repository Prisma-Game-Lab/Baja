using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    [System.Serializable]
    public class GeneratedInfo{
        public float probability = 1;
        public GameObject obj;

        public static GameObject GetRandom(List<GeneratedInfo> list){
            float[] weightedProb = new float[list.Count];
            float sumProb = 0;
            for(int i = 0; i < list.Count; i++) sumProb += list[i].probability;
            for(int i = 0; i < weightedProb.Length; i++){
                weightedProb[i] = list[i].probability/sumProb;
            }

            float randomVar = Random.value;

            for(int i = 0; i < weightedProb.Length; i++){
                if(randomVar > weightedProb[i]){
                    randomVar -= weightedProb[i];
                }
                else{
                    return list[i].obj;
                }
            }

            Debug.LogWarning("GetRandom percorreu toda a lista sem escolher ninguém, retornando o primeiro elemento");
            return list[0].obj;
        }
    }
    public List<GeneratedInfo> pistas;
    public int maxToGenerate = 5;
    public GameObject player;
    public float minDistanceToPlayerBeforeDestroyingGeneratedTrack = 1f;
    Vector3 nextPos;
    float generatedPrefabsExtent = -1;

    // Start is called before the first frame update
    void Start()
    {  
        nextPos = transform.position;
        for(int i = 0; i < maxToGenerate; i++) Generate();
    }

    public void Update(){
        if(transform.GetChild(1).position.z + generatedPrefabsExtent + minDistanceToPlayerBeforeDestroyingGeneratedTrack < player.transform.position.z){
            Destroy(transform.GetChild(0).gameObject);
        }
        if(transform.childCount < maxToGenerate) Generate();
    }

    public GameObject Generate() {
        var obj = Instantiate(GeneratedInfo.GetRandom(pistas), nextPos, Quaternion.identity, transform);
        if(generatedPrefabsExtent == -1) generatedPrefabsExtent = obj.GetComponent<Collider>().bounds.extents.z;
        nextPos += new Vector3(0, 0, 2*generatedPrefabsExtent);
        return obj;
    }
}
