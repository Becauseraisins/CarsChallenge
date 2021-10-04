using System.Collections.Generic;
using CarsLib;
using Microsoft.AspNetCore.Mvc;
using CarsApi.Handlers;

namespace CarsAPI.Controllers {
    [ApiController]
    [Route ("[controller]")]
    public class CarsController : ControllerBase {

        static Cars Cars = new Cars();
        DbHandler dbh = new DbHandler();
        
        public CarsController(){

        }
        [HttpGet]
        public List<Car> Get(){
            return this.dbh.GetAllCars();
        }
        [HttpGet("{name}")]
        public Car GetCar(string name){
            return this.dbh.GetCar(name);
        }
        [HttpGet("{name}/age")]
        public string GetCarAge(string name){
            return this.dbh.GetAge(name);
        }
        [HttpPut("{name}/{speed}/speed")]
        public string AddCarSpeed(string name, int speed){
            return this.dbh.IncreaseSpeed(name, speed);
        }
        [HttpPut("{name}/{speed}/slow")]
        public string ReduceCarSpeed(string name, int speed){
            return this.dbh.ReduceSpeed(name, speed);
        }

    }
}
 