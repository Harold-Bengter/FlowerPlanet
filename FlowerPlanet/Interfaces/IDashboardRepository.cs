﻿using FlowerPlanet.Models;

namespace FlowerPlanet.Interfaces;

public interface IDashboardRepository
{
    Task<List<Shows>> GetAllUserShows();
    Task<List<Club>> GetAllUserClubs();
}