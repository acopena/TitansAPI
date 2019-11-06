using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using TitansAPI.Command.Models;
using TitansAPI.Model;

namespace TitansAPI.Command.Action
{
    public interface IContentEvent
    {
        Task<List<ContentModel>> GetList(IMapper _mapper, int status, int pageId, titansContext context);
        Task<ContentModel> GetWebContentId(int id, IMapper _mapper, titansContext context);
        Task<List<ContentModel>> GetWebContenListByPage(int pageId, IMapper _mapper, titansContext context);
        Task<List<BContentType>> GetWebContentTypeList(titansContext context);
        Task<List<BPageContent>> GetWebPageContentList(titansContext context);
        Task<int> PostWebContent(ContentParamModel value, IMapper _mapper, titansContext context);

    }
}
