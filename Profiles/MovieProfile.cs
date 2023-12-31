﻿using AutoMapper;
using MovieWebAPI.Data.Dtos;
using MovieWebAPI.Models;

namespace MovieWebAPI.Profiles;

public class MovieProfile : Profile
{
    public MovieProfile()
    {
        CreateMap<CreateMovieDto, Movie>();
        CreateMap<Movie, ReadMovieDto>();
        CreateMap<UpdateMovieDto, Movie>();
        CreateMap<Movie, UpdateMovieDto>();
    }
}
