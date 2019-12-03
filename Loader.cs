using UnityEngine;

namespace Hired_Ops_Aimbot
{
    public class Loader
    {
        public static GameObject load_object;

        public static void Load()
        {
            load_object = new GameObject();
            load_object.AddComponent<Hacks>();
            UnityEngine.Object.DontDestroyOnLoad(load_object);
        }
        public static void Unload()
        {
            GameObject.Destroy(load_object);
        }
    }
}
