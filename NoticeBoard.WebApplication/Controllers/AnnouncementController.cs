using Microsoft.AspNetCore.Mvc;
using NoticeBoard.Service.Interfaces;
using NoticeBoard.Service.Models.ParameterDtos;
using NoticeBoard.WebApplication.Models.Parameters;
using NoticeBoard.WebApplication.Models.ViewModels;

namespace NoticeBoard.WebApplication.Controllers;

public class AnnouncementController(IAnnouncementService announcementService) : Controller
{
    public async Task<IActionResult> IndexAsync()
    {
        return View();
    }

    /// <summary>
    /// 取得公告列表
    /// </summary>
    /// <param name="parameter"></param>
    /// <returns></returns>
    public async Task<IActionResult> GetListAsync(GetAnnouncementListParameter parameter)
    {
        var parameterDto = new GetAnnouncementListParameterDto
        {
            StartDate = parameter.StartDate,
            EndDate = parameter.EndDate,
            Title = parameter.Title
        };
        var resultDtos = await announcementService.GetListAsync(parameterDto);
        var viewModels = resultDtos.Select(x =>
            new GetListViewModel
            {
                Id = x.Id,
                AnnouncementType = x.AnnouncementType,
                Title = x.Title,
                PublishDate = x.PublishDate,
                PublishStatus = x.PublishStatus
            });

        return View(viewModels);
    }

    /// <summary>
    /// 取得公告明細
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<IActionResult> EditAsync([FromRoute]int id)
    {
        var resultDto = await announcementService.GetAsync(id);
        if (resultDto is null)
        {
            return NotFound();
        }

        var viewModel = new GetDetailViewModel
        {
            Id = resultDto.Id,
            AnnouncementType = resultDto.AnnouncementType,
            Title = resultDto.Title,
            PublishStartDate = resultDto.PublishStartDate,
            PublishEndDate = resultDto.PublishEndDate,
            PublishStatus = resultDto.PublishStatus,
            Content = resultDto.Content,
            DisplayState = resultDto.DisplayState,
            IsTop = resultDto.IsTop,
            Boost = resultDto.Boost,
        };

        return View(viewModel);
    }

    /// <summary>
    /// 新增公告
    /// </summary>
    /// <returns></returns>
    public async Task<IActionResult> InsertAsync()
    {
        return View();
    }
    
    /// <summary>
    /// 新增公告
    /// </summary>
    /// <param name="parameter"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> InsertAsync(InsertAnnouncementParameter parameter)
    {
        var parameterDto = new AnnouncementInsertParameterDto
        {
            AnnouncementType = parameter.AnnouncementType,
            Title = parameter.Title,
            PublishStartDate = parameter.PublishStartDate,
            PublishEndDate = parameter.PublishEndDate,
            Content = parameter.Content,
            IsTop = parameter.IsTop,
            DisplayState = parameter.DisplayState,
            Boost = parameter.Boost
        };
        var success = await announcementService.InsertAsync(parameterDto);
        if (!success)
        {
            return BadRequest();
        }

        return Redirect("/Announcement/GetList"); ;
    }

    /// <summary>
    /// 更新公告
    /// </summary>
    /// <param name="id"></param>
    /// <param name="parameter"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> EditAsync(int id,
         UpdateAnnouncementParameter parameter)
    {
        var parameterDto = new AnnouncementUpdateParameterDto
        {
            Id = id,
            AnnouncementType = parameter.AnnouncementType,
            Title = parameter.Title,
            PublishStartDate = parameter.PublishStartDate,
            PublishEndDate = parameter.PublishEndDate,
            PublishStatus = parameter.PublishStatus,
            Content = parameter.Content,
            DisplayState = parameter.DisplayState,
            IsTop = parameter.IsTop,
            Boost = parameter.Boost
        };
        var success = await announcementService.UpdateAsync(parameterDto);
        if (!success)
        {
            return BadRequest();
        }

        return Redirect("/Announcement/GetList"); ;
    }
}