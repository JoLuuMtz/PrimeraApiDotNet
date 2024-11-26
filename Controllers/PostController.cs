using Mi_primera_api_dotnet.DTOs;
using Mi_primera_api_dotnet.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mi_primera_api_dotnet.Controllers
{
    [Route("posteos")]
    [ApiController]
    public class PostController : ControllerBase
    {

        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }


        [HttpGet("ObtenerPost")]
        public async Task<IAsyncEnumerable<PostDTO>> Get()
        { 

            return await _postService.GetPost();
        }
    }

}

