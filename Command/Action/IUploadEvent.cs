using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TitansAPI.Model;

namespace TitansAPI.Command.Action
{
    public interface IUploadEvent
    {
        Task<List<UploadDisplayModel>> GetUploadList(int? divisionId, int? seasonId, titansContext context);
        Task<List<UploadDisplayModel>> GetUpload(int uploadId, titansContext context);
        Task PostImages(UploadModel model, titansContext context);
        Task<List<BImageGroup>> GetImageGroupList(titansContext context);
        Task<List<ImageGroupModel>> GetImageGroup(titansContext context);
    }
}
