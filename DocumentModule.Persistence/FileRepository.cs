using DocumentModule.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualBasic.FileIO;
using Minio;
using Minio.DataModel.Args;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DocumentModule.Persistence
{
    public class FileRepository
    {
        private readonly FileStorageContext _context;

        public FileRepository(FileStorageContext context)
        {
            _context = context;
        }
    }
}
