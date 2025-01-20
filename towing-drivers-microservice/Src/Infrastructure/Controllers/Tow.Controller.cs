using Application.Core;
using Microsoft.AspNetCore.Mvc;
using Tow.Application;
using Tow.Domain;

namespace Tow.Infrastructure
{

    [ApiController]
    [Route("api/tow")]
    public class TowController(IdService<string> idService, Logger logger, IMessageBrokerService messageBrokerService,  IEventStore eventStore, ITowRepository towRepository, IPerformanceLogsRepository performanceLogsRepository) : ControllerBase
    {
        private readonly IdService<string> _idService = idService;
        private readonly Logger _logger = logger;
        private readonly IMessageBrokerService _messageBrokerService = messageBrokerService;
        private readonly IEventStore _eventStore = eventStore;
        private readonly ITowRepository _towRepository = towRepository;
        private readonly IPerformanceLogsRepository _performanceLogsRepository = performanceLogsRepository;

        [HttpPost("create")]
        public async Task<ObjectResult> CreateTow([FromBody] CreateTowDto createTowDto)
        {
            var command = new CreateTowCommand(
                createTowDto.Brand,
                createTowDto.Model,
                createTowDto.Color,
                createTowDto.LicensePlate,
                createTowDto.Location,
                createTowDto.Year,
                createTowDto.SizeType,
                createTowDto.Status
            );

            var handler =
                new ExceptionCatcher<CreateTowCommand, CreateTowResponse>(
                    new PerfomanceMonitor<CreateTowCommand, CreateTowResponse>(
                        new LoggingAspect<CreateTowCommand, CreateTowResponse>(
                            new CreateTowCommandHandler(_idService, _messageBrokerService, _eventStore, _towRepository), _logger
                        ), _logger, _performanceLogsRepository, nameof(CreateTowCommandHandler), "Write"
                    ), ExceptionParse.Parse
                );

            var res = await handler.Execute(command);

            return Ok(res.Unwrap());

        }

        [HttpPatch("update")]
        public async Task<ObjectResult> UpdateTow([FromBody] UpdateTowDto updateTowDto)
        {
            var command = new UpdateTowCommand(
                updateTowDto.Id,
                updateTowDto.Brand,
                updateTowDto.Model,
                updateTowDto.Color,
                updateTowDto.LicensePlate,
                updateTowDto.Location,
                updateTowDto.Year,
                updateTowDto.SizeType,
                updateTowDto.Status
            );

            var handler =
                 new ExceptionCatcher<UpdateTowCommand, UpdateTowResponse>(
                    new PerfomanceMonitor<UpdateTowCommand, UpdateTowResponse>(
                        new LoggingAspect<UpdateTowCommand, UpdateTowResponse>(
                            new UpdateTowCommandHandler(_messageBrokerService, _eventStore, _towRepository), _logger
                        ), _logger, _performanceLogsRepository, nameof(CreateTowCommandHandler), "Write"
                    ), ExceptionParse.Parse
                );

            var res = await handler.Execute(command);

            return Ok(res.Unwrap());  
        }

        [HttpGet("find/all/tow")]
        public async Task<ObjectResult> FindAllTow()
        {
            var handler = new FindAllTowQuery();
            var res = await handler.Execute("");
            return Ok(res.Unwrap());
        }
    }
}
