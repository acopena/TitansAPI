using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TitansAPI.Command.Models;
using TitansAPI.Model;

namespace TitansAPI.Command.Action
{
    public interface IContentEvent
    {
        Task<List<ContentModel>> GetList(IMapper _mapper, int status, int pageId);
        Task<ContentModel> GetWebContentId(int id, IMapper _mapper);
        Task<List<ContentModel>> GetWebContenListByPage(int pageId, IMapper _mapper);
        Task<List<BContentType>> GetWebContentTypeList();
        Task<List<BPageContent>> GetWebPageContentList();
        Task<int> PostWebContent(ContentParamModel value, IMapper _mapper);

    }
}
