using Infrastructure.AspNet;
using Microsoft.AspNetCore.Mvc;
using Read.DataCollectors;
using System;
using System.Threading.Tasks;
using doLittle.Read;
using Domain.DataCollector.Registering;
using Domain.DataCollector.Update;
using Domain.DataCollector;
using MongoDB.Driver;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web.Controllers
{
    [Route("api/datacollectors")]
    public class DataCollectorsController : BaseController
    {
        //private readonly IDataCollectors _dataCollectors;

        private readonly IMongoDatabase _database;

        private readonly IDataCollectorCommandHandler _dataCollectorCommandHandler;

        private readonly IQueryCoordinator _queryCoordinator;

        public DataCollectorsController (
            IMongoDatabase database,
            IDataCollectorCommandHandler dataCollectorCommand,
            IDataCollectors dataCollectors,
            IQueryCoordinator queryCoordinator)
        {
            _database = database;
            _dataCollectorCommandHandler = dataCollectorCommand;
            _queryCoordinator = queryCoordinator;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = _queryCoordinator.Execute(new AllDataCollectors(_database), new PagingInfo());

            if (result.Success)
            {
                return Ok(result.Items);
            }

            return new NotFoundResult();  
        }

        [HttpGet("getbyid/{id}")]
        public IActionResult GetById(Guid id)
        {
            var result = _queryCoordinator.Execute(new DataCollectorById(_database, id), new PagingInfo());

            if (result.Success)
            {
                return Ok(result.Items);
            }

            return new NotFoundResult();
        }

        [HttpPost("register")]
        public IActionResult Post([FromBody] RegisterDataCollector command)
        {
            command.DataCollectorId = Guid.NewGuid();
            _dataCollectorCommandHandler.Handle(command);
            return Ok();
        }

        [HttpPost("update")]
        public IActionResult Update([FromBody] UpdateDataCollector command)
        {
            // TODO: Changes has to be made to updating the datacollector.
            // Should use the same system as staffusers
            _dataCollectorCommandHandler.Handle(command);
            return Ok();
        }
    }
}
