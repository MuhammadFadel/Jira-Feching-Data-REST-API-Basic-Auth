using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QRG.Models;
using QRG.Services.IServices;
using System.Diagnostics;
using System.Text;

namespace QRG.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;        
        private readonly IConfiguration _config;
        private readonly IProjectService _projectService;
        private readonly IGitlabProjectService _gitlabProjectService;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration, 
            IProjectService projectService, IGitlabProjectService gitlabProjectService)
        {
            _logger = logger;
            _config = configuration;
            _projectService = projectService;
            _gitlabProjectService = gitlabProjectService;
        }

        public async Task<IActionResult> Index()
        {
            List<ProjectDto> projects = new();
            var accessToken = _config.GetSection("JiraService:ApiToken").Value;
            var accessTokenEncoded = Encoding.UTF8.GetBytes(accessToken.ToString());
            var at64 = Convert.ToBase64String(accessTokenEncoded);
            var jiraResponse = await _projectService.GetProjectsAsync<ResponseDto>(at64);
            if (jiraResponse != null && jiraResponse.IsSuccess)
            {
                projects = JsonConvert.DeserializeObject<List<ProjectDto>>(Convert.ToString(jiraResponse.Result));
                return View(projects);
            }
            return View();
        }

        public async Task<IActionResult> GitlabProjects()
        {
            List<GitlabProjectDto> projects = new();
            var accessToken = _config.GetSection("GitlabService:ApiToken").Value;            
            var response = await _gitlabProjectService.GetProjectsAsync<ResponseDto>(accessToken);
            if (response != null && response.IsSuccess)
            {
                projects = JsonConvert.DeserializeObject<List<GitlabProjectDto>>(Convert.ToString(response.Result));
                return View(projects);
            }
            return View();
        }        

        
        public async Task<IActionResult> ProjectDetails(int id)
        {            
            var accessToken = _config.GetSection("JiraService:ApiToken").Value;
            var accessTokenEncoded = Encoding.UTF8.GetBytes(accessToken.ToString());
            var at64 = Convert.ToBase64String(accessTokenEncoded);
            var response = await _projectService.GetProjectByIdAsync<ResponseDto>(id, at64);
            if (response != null && response.IsSuccess)
            {
                var project = JsonConvert.DeserializeObject<ProjectDto>(Convert.ToString(response.Result));
                return View(project);
            }
            return View();            
        }

        public async Task<IActionResult> GitlabProjectDetails(int id)
        {
            var accessToken = _config.GetSection("GitlabService:ApiToken").Value;            
            var response = await _gitlabProjectService.GetProjectByIdAsync<ResponseDto>(id, accessToken);
            if (response != null && response.IsSuccess)
            {
                var project = JsonConvert.DeserializeObject<GitlabProjectDto>(Convert.ToString(response.Result));
                return View(project);
            }
            return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}