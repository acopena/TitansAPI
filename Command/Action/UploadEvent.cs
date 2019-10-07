using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using TitansAPI.Model;
using Microsoft.EntityFrameworkCore;
using System;

namespace TitansAPI.Command.Action
{
    public class UploadEvent : IUploadEvent
    {
        public async Task<List<UploadDisplayModel>> GetUploadList(int? divisionId, int? seasonId)
        {
            List<UploadDisplayModel> uploadList = new List<UploadDisplayModel>();
            using (var ctx = new titansContext())
            {
                uploadList = await (from p in ctx.BUpload
                                    where p.EndDate == null
                                    select new UploadDisplayModel()
                                    {
                                        Name = p.Name,
                                        Description = p.Description,
                                        Type = p.Type,
                                        ImagePath = p.ImagePath,
                                        divisonId = p.DivisionId,
                                        SeasonId = p.SeasonId
                                    }).ToListAsync();
                if (divisionId > 0)
                {
                    uploadList = uploadList.Where(s => s.divisonId == divisionId.Value).ToList();
                }
                if (seasonId > 0)
                {
                    uploadList = uploadList.Where(s => s.SeasonId == seasonId).ToList();
                }
            }
            return uploadList;

        }

        public async Task<List<UploadDisplayModel>> GetUpload(int uploadId)
        {
            List<UploadDisplayModel> uploadList = new List<UploadDisplayModel>();
            using (var ctx = new titansContext())
            {
                uploadList = await (from p in ctx.BUpload
                                    where p.UploadId == uploadId && p.EndDate == null
                                    select new UploadDisplayModel()
                                    {
                                        Name = p.Name,
                                        Description = p.Description,
                                        Type = p.Type,
                                        ImagePath = p.ImagePath
                                    }).ToListAsync();

            }
            return uploadList;

        }

        public async Task<List<BImageGroup>> GetImageGroupList()
        {
            List<BImageGroup> imgGroupList = new List<BImageGroup>();
            using (var ctx = new titansContext())
            {
                imgGroupList = await ctx.BImageGroup.OrderBy(s => s.ImageGroupName).ToListAsync();
            }
            return imgGroupList;
        }

        public async Task<List<ImageGroupModel>> GetImageGroup()
        {
            List<ImageGroupModel> model= new List<ImageGroupModel>();
            using (var ctx = new titansContext())
            {
                //Get all the images
                var ImageList = await ctx.BUpload.ToListAsync();
                var imgGroup = ImageList.GroupBy(s => s.DivisionId).Select(x => x.First()).ToList();
                foreach(var i in imgGroup)
                {

                    var group = await ctx.BImageGroup.Where(s => s.ImageGroupId == i.DivisionId.Value).FirstOrDefaultAsync();

                    var image = new  ImageGroupModel();

                    image.ImageGroupId = i.DivisionId.Value;
                    image.ImageGroupName = group.ImageGroupName;
                    image.SeasonList = GetImageSeasonList(ImageList, i.DivisionId.Value);
                    model.Add(image);
                }


            }
            return model;
        }

        List<ImageModel> GetImageNameList(List<BUpload> imgList, int divisionId, int seasonId)
        {
            return (from p in imgList
                    where p.DivisionId == divisionId && p.SeasonId == seasonId
                    select new ImageModel()
                    {
                        ImageName = p.Name
                    }).ToList();
        }


        List<SeasonGroupModel> GetImageSeasonList(List<BUpload> imgList, int divisionId)
        {
            List<SeasonGroupModel> model = new List<SeasonGroupModel>();
            var data = imgList.Where(s => s.DivisionId == divisionId).Select(s => s.SeasonId).Distinct().ToList();
            foreach(var i in data)
            {
                SeasonGroupModel im = new SeasonGroupModel();
                im.SeasonId = i;
                im.ImageList = GetImageNameList(imgList, divisionId, i);
                model.Add(im);
            }

            return model;


        }

        public async Task PostImages(UploadModel model)
        {

            try
            {
                using (var ctx = new titansContext())
                {
                    foreach (var cImg in model.ImageList)
                    {
                        var image = await (from p in ctx.BUpload
                                           where p.Name == cImg.Name && p.SeasonId == model.SeasonId && p.DivisionId == model.DivisionId && p.EndDate == null
                                           select p).FirstOrDefaultAsync();

                        if (image == null)
                        {
                            BUpload img = new BUpload();
                            img.Name = cImg.Name;
                            img.Type = cImg.Type;
                            img.ImagePath = cImg.ImagePath;
                            img.SeasonId = model.SeasonId.Value;
                            img.FromDate = DateTime.Now;
                            img.DivisionId = model.DivisionId;
                            ctx.BUpload.Add(img);
                        }
                    }
                    ctx.SaveChanges();
                }
            }
            catch (Exception err)
            {
                string emsg = err.Message;
            }

        }

    }

    public class ImageDisplayModel
    {
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
    }

    public class UploadModel
    {
        public int? DivisionId { get; set; }
        public int? SeasonId { get; set; }
        public List<ImageDisplayModel> ImageList { get; set; }
    }

    public class UploadDisplayModel
    {
        public int UploadId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public int SeasonId { get; set; }
        public string ImagePath { get; set; }
        public int? divisonId { get; set; }
    }

    public class ImageGroupModel
    {
        public int ImageGroupId { get; set; }
        public string ImageGroupName { get; set; }
        public List<SeasonGroupModel> SeasonList { get; set; }

    }
    public class SeasonGroupModel
    {
        public int SeasonId { get; set; }
        public List<ImageModel> ImageList{ get; set; }
    }
    public class ImageModel
    {
        public string ImageName{ get; set; }
    }

}
