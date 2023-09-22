using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookAPI;

[ApiController]
[Route("[controller]")]
public class TestController : ControllerBase
{
    // private readonly ITestService testService;
    // public TestController(ITestService testService)
    // {
    //     this.testService = testService;

    // }

    // [HttpGet("test")]
    // public string TestGet()
    // {
    //     var test = testService.GetTest();
    //     return test;
    // }
}
