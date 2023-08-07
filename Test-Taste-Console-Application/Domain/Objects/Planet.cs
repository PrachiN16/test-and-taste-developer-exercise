using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Test_Taste_Console_Application.Domain.DataTransferObjects;

namespace Test_Taste_Console_Application.Domain.Objects
{
    public class Planet
    {
        public string Id { get; set; }
        public float SemiMajorAxis { get; set; }
        public ICollection<Moon> Moons { get; set; }
        public float AverageMoonGravity
        {
            get; set;
        }

        // Average gravity calculation logic is included in the constructor itself
        // Benefit of this solution is that no explicit logic has to be added or called over and over, it will calculate for all planet models
        // Disadvantage :
        // If there a large dataset of planets and moons and the average calculation is not needed for all planets, then it will be wastage of memory and time 

        public Planet(PlanetDto planetDto)
        {
            Id = planetDto.Id;
            SemiMajorAxis = planetDto.SemiMajorAxis;
            Moons = new Collection<Moon>();
            if (planetDto.Moons != null)
            {
                float sum = 0.0f;
                foreach (MoonDto moonDto in planetDto.Moons)
                {
                    Moons.Add(new Moon(moonDto));
                    sum += moonDto.Gravity;
                }
                AverageMoonGravity = sum / planetDto.Moons.Count;
            }
        }

        public Boolean HasMoons()
        {
            return (Moons != null && Moons.Count > 0);
        }
    }
}
