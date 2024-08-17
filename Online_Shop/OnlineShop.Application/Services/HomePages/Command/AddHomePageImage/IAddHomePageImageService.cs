using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using OnlineShop.application.Intefaces.Context;
using OnlineShop.Application.Services.Products.Command.AddNewProductFolder;
using OnlineShop.Common.Common.HomePage;
using OnlineShop.Common.Dto;
using OnlineShop.Domain.Entities.HomePages;

namespace OnlineShop.Application.Services.HomePages.AddHomePageImage
{
    public interface IAddHomePageImageService
    {
        ResultDto Execute(AddHomePageImageDto request);
    }

    public class AddHomePageImageService : IAddHomePageImageService
    {

        private readonly IHostingEnvironment _environment;
        private readonly IDataBaseContext _context;

        public AddHomePageImageService(IHostingEnvironment environment, IDataBaseContext context)
        {
            _environment = environment;
            _context = context;
        }
        public ResultDto Execute(AddHomePageImageDto request)
        {
            var resultUpload = UploadFile(request.File);


            HomePageImage homePage = new HomePageImage()
            {
                Link = request.Link,
                Src = resultUpload.FileNameAddress,
                ImageLocation = request.ImageLocation,
            };
            _context.HomePageImages.Add(homePage);
            _context.SaveChanges();

            return new ResultDto()
            {
                IsSuccess = true
            };

        }
        private UploadDto UploadFile(IFormFile file)
        {
            if (file != null)
            {
                string folder = $@"images\HomePages\HomePageImages\";
                var uploadsRootFolder = Path.Combine(_environment.WebRootPath, folder);
                if (!Directory.Exists(uploadsRootFolder))
                {
                    Directory.CreateDirectory(uploadsRootFolder);
                }


                if (file == null || file.Length == 0)
                {
                    return new UploadDto()
                    {
                        Status = false,
                        FileNameAddress = "",
                    };
                }

                string fileName = DateTime.Now.Ticks.ToString() + file.FileName;
                var filePath = Path.Combine(uploadsRootFolder, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }

                return new UploadDto()
                {
                    FileNameAddress = folder + fileName,
                    Status = true,
                };
            }
            return null;
        }
    }

    public class AddHomePageImageDto
    {
        public string Link { get; set; }
        public IFormFile File { get; set; }
        public ImageLocation ImageLocation { get; set; }
    }
}
