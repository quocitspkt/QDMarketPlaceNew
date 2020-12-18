using MarketPlace.Application.ViewModels.System;
using MarketPlace.Ultilities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarketPlace.Application.Interfaces
{
    public interface IAnnouncementService
    {
        PagedResult<AnnouncementViewModel> GetAllUnReadPaging(Guid userId, int pageIndex, int pageSize);

        bool MarkAsRead(Guid userId, string id);
    }
}
