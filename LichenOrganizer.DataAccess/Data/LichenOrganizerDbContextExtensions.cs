using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.IO;
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using LichenOrganizer.Model;

namespace LichenOrganizer.DataAccess.Data
{
    public static class LichenOrganizerDbContextExtensions
    {
        public static void SeedMockData(LichenOrganizerDbContext context)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {

                    var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        HeaderValidated = null,
                        MissingFieldFound = null
                    };

                    string seedFolderPath = @"C:\Users\15417\Desktop\LichenApplication\Seed\";
                    //MOCK DATA
                    //equipmentModel.ManufacturerID = mfr.Id;
                    //equipmentModel.Manufacturer = mfr;
 
                    //Mock Files
                    using (var reader = new StreamReader(Path.Combine(seedFolderPath, "lichens.csv")))
                    {
                        List<Lichen> importedLichens = new List<Lichen>();
                        var csv = new CsvReader(reader, config);
                        while (csv.Read())
                        {
                            var file = csv.GetRecord<Lichen>();
                            importedLichens.Add(file);
                        }

                        Lichen[] fileArray = importedLichens.ToArray();
                        context.Lichens.AddRange(fileArray);
                    }
                    var result = context.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

    }
}