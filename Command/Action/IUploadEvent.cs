using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TitansAPI.Command.Action
{
    public interface IUploadEvent
    {
        Task<List<UploadDisplayModel>> GetUploadList(int? divisionId, int? seasonId);
        Task<List<UploadDisplayModel>> GetUpload(int uploadId);
        Task PostImages(UploadModel model);
    }
}
