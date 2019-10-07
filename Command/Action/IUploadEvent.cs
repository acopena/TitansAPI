using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TitansAPI.Model;

namespace TitansAPI.Command.Action
{
    public interface IUploadEvent
    {
        Task<List<UploadDisplayModel>> GetUploadList(int? divisionId, int? seasonId);
        Task<List<UploadDisplayModel>> GetUpload(int uploadId);
        Task PostImages(UploadModel model);
        Task<List<BImageGroup>> GetImageGroupList();
        Task<List<ImageGroupModel>> GetImageGroup();
    }
}
