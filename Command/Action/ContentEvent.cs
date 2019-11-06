﻿using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TitansAPI.Model;
using System.Threading.Tasks;
using TitansAPI.Command.Models;

namespace TitansAPI.Command.Action
{
    public class ContentEvent : IContentEvent
    {
        public async Task<List<ContentModel>> GetList(IMapper _mapper, int status, int pageId, titansContext context)
        {
            List<ContentModel> contentList = new List<ContentModel>();

            var content = await context.BContent
                .Include(s => s.PageContent)
                .Include(s => s.ContentType)
                .Select(s => s).ToListAsync();

            if (status == 1)
            {
                content = content.Where(s => s.PublishedEndDate >= DateTime.Now).ToList();
            }
            else if (status == 2)
            {
                content = content.Where(s => s.PublishedEndDate < DateTime.Now).ToList();
            }

            if (pageId != 0)
            {
                content = content.Where(s => s.PageContentId == pageId).ToList();
            }

            foreach (var r in content)
            {
                ContentModel model = _mapper.Map<ContentModel>(r);
                contentList.Add(model);
            }
            return contentList;
        }

        public async Task<ContentModel> GetWebContentId(int id, IMapper _mapper, titansContext context)
        {
            ContentModel model = new ContentModel();
            var content = await context.BContent
                .Include(s => s.PageContent)
                .Include(s => s.ContentType)
                .Where(s => s.ContentId == id)
                .Select(s => s).FirstOrDefaultAsync();

            if (content != null)
            {
                model = _mapper.Map<ContentModel>(content);
            }

            return model;
        }

        public async Task<List<ContentModel>> GetWebContenListByPage(int pageId, IMapper _mapper, titansContext context)
        {
            List<ContentModel> contentList = new List<ContentModel>();

            var content = await context.BContent
                .Include(s => s.PageContent)
                .Include(s => s.ContentType)
                .Where(s => s.PageContentId == pageId && s.PublishedEndDate >= DateTime.Now)
                .Select(s => s).ToListAsync();

            foreach (var r in content)
            {
                ContentModel model = _mapper.Map<ContentModel>(r);
                contentList.Add(model);
            }

            return contentList;
        }



        public async Task<List<BContentType>> GetWebContentTypeList(titansContext context)
        {
            List<BContentType> model = new List<BContentType>();

            model = await context.BContentType
                .Select(s => s).ToListAsync();
            return model;
        }

        public async Task<List<BPageContent>> GetWebPageContentList(titansContext context)
        {
            List<BPageContent> model = new List<BPageContent>();

            model = await context.BPageContent
                .Select(s => s).ToListAsync();
            return model;
        }

        public async Task<int> PostWebContent(ContentParamModel value, IMapper _mapper, titansContext context)
        {

            var dta = await context.BContent.Where(p => p.ContentId == value.ContentId).
                       Select(p => p).FirstOrDefaultAsync();

            if (dta == null)
            {
                BContent data = _mapper.Map<BContent>(value);

                value.ContentId = data.ContentId;
                data.PublishedStartDate = new DateTime(value.PublishStartYear, value.PublishStartMonth, value.PublishStartDay, 0, 0, 0);
                data.PublishedEndDate = new DateTime(value.PublishedEndYear, value.PublishedEndMonth, value.PublishedEndDay, 0, 0, 0);
                data.DateModified = DateTime.Now;
                data.IsExpired = false;
                await context.BContent.AddAsync(data);
                await context.SaveChangesAsync();
                value.ContentId = data.ContentId;

            }
            else
            {
                dta.ContentTitle = value.ContentTitle;
                dta.ContentDetails = value.ContentDetails;
                dta.PublishedStartDate = new DateTime(value.PublishStartYear, value.PublishStartMonth, value.PublishStartDay);
                dta.PublishedEndDate = new DateTime(value.PublishedEndYear, value.PublishedEndMonth, value.PublishedEndDay);
                dta.UserId = value.UserId;
                dta.DateModified = DateTime.Now;
                dta.PageContentId = value.PageContentId;
                dta.ContentTypeId = value.ContentTypeId;
                await context.SaveChangesAsync();
            }
            return value.ContentId;
        }
    }
}
