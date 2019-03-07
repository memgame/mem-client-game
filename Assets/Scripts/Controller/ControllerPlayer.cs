using UnityEngine;

namespace MemClientGame.Assets.Scripts.Controller
{
    class ControllerPlayer : MonoBehaviour
    {
        public Vector3 MoveTo;
        public float SpeedLerp;

        public void Start()
        {
            MoveTo = transform.position;
        }

        public void Update()
        {
            if(MoveTo != null)
            {
                transform.position = Vector3.Lerp(transform.position, MoveTo, SpeedLerp);
            };
        }
    }
}
