using System;
using System.Collections.Generic;
using System.Linq;

namespace PistonChain.Models.Piston
{
    public class Box
    {
        private readonly List<string> _remainingPieces = new() { Piston.Tete, Piston.Jupe, Piston.Axe };
        private static Random _rng = new();
        public Box() { }
        public List<string> GetPieces() {
            return _remainingPieces.OrderBy(a => _rng.Next()).ToList();
        }
    }
}
