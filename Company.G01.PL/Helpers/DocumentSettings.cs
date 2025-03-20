﻿namespace Company.G01.PL.Helpers
{
    public static class DocumentSettings
    {
        //1.Upload
        //ImageName

        public static string UploadFile(IFormFile file,string folderName)
        {
            //1.Get Folder Location
            // string folderpath = "D:\\C#\\Company.G01\\Company.G01.PL\\wwwroot\\Files\\"+ folderName;
            // var folderPath =  Directory.GetCurrentDirectory()+ "\\wwwroot\\Files\\"+folderName;

            var folderPath = Path.Combine(Directory.GetCurrentDirectory() , @"wwwroot\Files" , folderName);
            //Get File Name And Make It Unique

            var fileName = $"{Guid.NewGuid()}{file.FileName}";


            //file path
            var filePath = Path.Combine(folderPath, fileName);
           using var fileStream = new FileStream(filePath,FileMode.Create);
            file.CopyTo(fileStream);

            return fileName ;
        }

        //2.Delete

        public static void DeleteFile(string fileName , string folderName)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Files", folderName,fileName);

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

        }
    }
}
