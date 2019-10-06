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
}
