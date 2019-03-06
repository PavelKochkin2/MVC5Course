using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using VidlyReborn.DTOs;
using VidlyReborn.Models;
using System.Data.Entity;

namespace VidlyReborn.Controllers.Api
{
    public class MoviesController : ApiController
    {
        public ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/movies
        [HttpGet]
        public IHttpActionResult GetMovies()
        {
            var movieDtos = _context.Movies
                .Include(m => m.Genre)
                .Select(Mapper.Map<Movie, MovieDto>).ToList();

            return Ok(movieDtos);
        }

        //GET /api/movies/id
        [HttpGet]
        public IHttpActionResult GetMovie(int id)
        {
            var movieInDb = _context.Movies.First(m => m.Id == id);

            if (movieInDb == null)
                return NotFound();

            var movieDto = Mapper.Map<Movie, MovieDto>(movieInDb);

            return Ok(movieDto);
        }

        //POST /api/movies/
        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movie = Mapper.Map<MovieDto, Movie>(movieDto);


            _context.Movies.Add(movie);
            _context.SaveChanges();

            movieDto.Id = movie.Id;

            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);

        }

        //PUT /api/movies/id
        [HttpPut]
        public  void UpdateMovie(int id ,MovieDto movieDto)
        {

            if(!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var movieInDn = _context.Movies.First(m => m.Id == id);

            if(movieInDn == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);


            Mapper.Map(movieDto, movieInDn);

            _context.SaveChanges();
        }

        //DELETE /api/movies/id
        [HttpDelete]
        public void DeleteMovie(int id)
        {
            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);

            if(movieInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Movies.Remove(movieInDb);
            _context.SaveChanges();
        }

    }
}
