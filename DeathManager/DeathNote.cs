using System;
using UnityEngine;

namespace DeathManager
{
    internal class DeathNote
    {
        public DeathNote()
        {
        }

        public Vector3 Position { get; set; }
        public DateTime TimeOfDeath { get; set; }
    }
}