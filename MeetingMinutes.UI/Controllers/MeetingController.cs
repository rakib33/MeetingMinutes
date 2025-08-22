using MeetingMinutes.Application.DTOs;
using MeetingMinutes.Application.Interfaces;
using MeetingMinutes.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MeetingMinutes.UI.Controllers
{
    public class MeetingController : Controller
    {
        private readonly IMeetingMasterService _meetingMasterService;
        private readonly IMeetingDetailsService _meetingDetailsService;
        public MeetingController(IMeetingMasterService meetingService, IMeetingDetailsService meetingDetailsService)
        {
            _meetingMasterService = meetingService;
            _meetingDetailsService = meetingDetailsService;            
        }

        // Save products
        [HttpPost]
        public async Task<JsonResult> SaveMeeting([FromBody] MeetingDto meetings)
        {
            try
            {
                int result = await _meetingMasterService.SaveMeetingMasterAsync(meetings);
                // Save logic
                return Json(new { success = result>0 ? true: false, id= result, message = result > 0? "Meeting saved successfully!" :"Meeting saved failed"});
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<JsonResult> SaveMeetingDetails([FromBody]List<MeetingDetailsDto> meetings)
        {
            try
            {
                bool result = await _meetingDetailsService.SaveMeetingDetailsAsync(meetings);
                // Save logic
                return Json(new { success = result, message = result ? "Meeting details saved successfully!" : "Meeting details saved failed" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }
               
        //[HttpPost]
        //public JsonResult SaveMeeting([FromBody] MeetingViewModel model)
        //{
        //    try
        //    {
        //        // Validate model
        //        if (!ModelState.IsValid)
        //        {
        //            var errors = ModelState.Values
        //                .SelectMany(v => v.Errors)
        //                .Select(e => e.ErrorMessage);
        //            return Json(new { success = false, message = "Validation failed", errors });
        //        }

        //        // Parse the date and time (if you need them combined)
        //        DateTime meetingDateTime;
        //        if (DateTime.TryParse($"{model.MeetingDate.ToShortDateString()} {model.MeetingTime}",
        //            out meetingDateTime))
        //        {
        //            // Now you have meetingDateTime with both date and time
        //        }

        //        // Your business logic here (save to database, etc.)
        //        // For example:
        //        // _meetingService.SaveMeeting(model);

        //        return Json(new { success = true, message = "Meeting saved successfully" });
        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(new { success = false, message = "Error saving meeting", error = ex.Message });
        //    }
        //}
    }
}
