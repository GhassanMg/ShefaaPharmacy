using DataLayer.Tables;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.MapTables
{
    public class CompanyMap
    {
        public CompanyMap()
        {

        }
        public void SeedData(EntityTypeBuilder<Company> entity)
        {
            #region Companies
            entity.HasData(new Company { Id = 1, Name = "ابن الهيثم", Location = "Damascus", CreationDate = DateTime.Now, CreationBy = 2 });
            entity.HasData(new Company { Id = 2, Name = "ابن حيان", Location = "Damascus", CreationDate = DateTime.Now, CreationBy = 2 });
            entity.HasData(new Company { Id = 3, Name = "ابن رشد", Location = "Damascus", CreationDate = DateTime.Now, CreationBy = 2 });
            entity.HasData(new Company { Id = 4, Name = "ابن زهر", Location = "Damascus", CreationDate = DateTime.Now, CreationBy = 2 });
            entity.HasData(new Company { Id = 5, Name = "ابن سينا", Location = "Damascus", CreationDate = DateTime.Now, CreationBy = 2 });
            entity.HasData(new Company { Id = 6, Name = "افاميا", Location = "Damascus", CreationDate = DateTime.Now, CreationBy = 2 });
            entity.HasData(new Company { Id = 7, Name = "الأفق", Location = "Damascus", CreationDate = DateTime.Now, CreationBy = 2 });
            entity.HasData(new Company { Id = 8, Name = "البلسم", Location = "Damascus", CreationDate = DateTime.Now, CreationBy = 2 });
            entity.HasData(new Company { Id = 9, Name = "التراميديكا", Location = "Damascus", CreationDate = DateTime.Now, CreationBy = 2 });
            entity.HasData(new Company { Id = 10, Name = "الدولية", Location = "Damascus", CreationDate = DateTime.Now, CreationBy = 2 });
            entity.HasData(new Company { Id = 11, Name = "الرازي", Location = "Damascus", CreationDate = DateTime.Now, CreationBy = 2 });
            entity.HasData(new Company { Id = 12, Name = "الرائد", Location = "Damascus", CreationDate = DateTime.Now, CreationBy = 2 });
            entity.HasData(new Company { Id = 13, Name = "السعد", Location = "Damascus", CreationDate = DateTime.Now, CreationBy = 2 });
            entity.HasData(new Company { Id = 14, Name = "السلام", Location = "Damascus", CreationDate = DateTime.Now, CreationBy = 2 });
            entity.HasData(new Company { Id = 15, Name = "الشهباء", Location = "Damascus", CreationDate = DateTime.Now, CreationBy = 2 });
            entity.HasData(new Company { Id = 16, Name = "الفا", Location = "Damascus", CreationDate = DateTime.Now, CreationBy = 2 });
            entity.HasData(new Company { Id = 17, Name = "الفارس", Location = "Damascus", CreationDate = DateTime.Now, CreationBy = 2 });
            entity.HasData(new Company { Id = 18, Name = "القنواتي", Location = "Damascus", CreationDate = DateTime.Now, CreationBy = 2 });
            entity.HasData(new Company { Id = 19, Name = "القنواتي ", Location = "Damascus", CreationDate = DateTime.Now, CreationBy = 2 });
            entity.HasData(new Company { Id = 20, Name = "الما", Location = "Damascus", CreationDate = DateTime.Now, CreationBy = 2 });
            entity.HasData(new Company { Id = 21, Name = "الما ", Location = "Damascus", CreationDate = DateTime.Now, CreationBy = 2 });
            entity.HasData(new Company { Id = 22, Name = "المتحدة ", Location = "Damascus", CreationDate = DateTime.Now, CreationBy = 2 });
            entity.HasData(new Company { Id = 23, Name = "المتوسط", Location = "Damascus", CreationDate = DateTime.Now, CreationBy = 2 });
            entity.HasData(new Company { Id = 24, Name = "النورس", Location = "Damascus", CreationDate = DateTime.Now, CreationBy = 2 });
            entity.HasData(new Company { Id = 25, Name = "الهلال", Location = "Damascus", CreationDate = DateTime.Now, CreationBy = 2 });
            entity.HasData(new Company { Id = 26, Name = "الوطنية", Location = "Damascus", CreationDate = DateTime.Now, CreationBy = 2 });
            entity.HasData(new Company { Id = 27, Name = "اليوسف", Location = "Damascus", CreationDate = DateTime.Now, CreationBy = 2 });
            entity.HasData(new Company { Id = 28, Name = "إميسا", Location = "Damascus", CreationDate = DateTime.Now, CreationBy = 2 });
            entity.HasData(new Company { Id = 29, Name = "أدامكو", Location = "Damascus", CreationDate = DateTime.Now, CreationBy = 2 });
            entity.HasData(new Company { Id = 30, Name = "أسيا", Location = "Damascus", CreationDate = DateTime.Now, CreationBy = 2 });
            entity.HasData(new Company { Id = 31, Name = "أوبري", Location = "Damascus", CreationDate = DateTime.Now, CreationBy = 2 });
            entity.HasData(new Company { Id = 32, Name = "أوشر", Location = "Damascus", CreationDate = DateTime.Now, CreationBy = 2 });
            entity.HasData(new Company { Id = 33, Name = "أوغاريت", Location = "Damascus", CreationDate = DateTime.Now, CreationBy = 2 });
            entity.HasData(new Company { Id = 34, Name = "آسكو فارما", Location = "Damascus", CreationDate = DateTime.Now, CreationBy = 2 });
            entity.HasData(new Company { Id = 35, Name = "بحري", Location = "Damascus", CreationDate = DateTime.Now, CreationBy = 2 });
            entity.HasData(new Company { Id = 36, Name = "بركات", Location = "Damascus", CreationDate = DateTime.Now, CreationBy = 2 });
            entity.HasData(new Company { Id = 37, Name = "بركات ", Location = "Damascus", CreationDate = DateTime.Now, CreationBy = 2 });
            entity.HasData(new Company { Id = 38, Name = "برولاين", Location = "Damascus", CreationDate = DateTime.Now, CreationBy = 2 });
            entity.HasData(new Company { Id = 39, Name = "بيوميد", Location = "Damascus", CreationDate = DateTime.Now, CreationBy = 2 });
            entity.HasData(new Company { Id = 40, Name = "ترياق", Location = "Damascus", CreationDate = DateTime.Now, CreationBy = 2 });
            entity.HasData(new Company { Id = 41, Name = "حماة فارما", Location = "Damascus", CreationDate = DateTime.Now, CreationBy = 2 });
            entity.HasData(new Company { Id = 42, Name = "حياة فارما", Location = "Damascus", CreationDate = DateTime.Now, CreationBy = 2 });
            entity.HasData(new Company { Id = 43, Name = "دلتا", Location = "Damascus", CreationDate = DateTime.Now, CreationBy = 2 });
            entity.HasData(new Company { Id = 44, Name = "دومنا", Location = "Damascus", CreationDate = DateTime.Now, CreationBy = 2 });
            entity.HasData(new Company { Id = 45, Name = "دياموند", Location = "Damascus", CreationDate = DateTime.Now, CreationBy = 2 });
            entity.HasData(new Company { Id = 46, Name = "راما فارما", Location = "Damascus", CreationDate = DateTime.Now, CreationBy = 2 });
            entity.HasData(new Company { Id = 47, Name = "راما فارما ", Location = "Damascus", CreationDate = DateTime.Now, CreationBy = 2 });
            entity.HasData(new Company { Id = 48, Name = "رشا", Location = "Damascus", CreationDate = DateTime.Now, CreationBy = 2 });
            entity.HasData(new Company { Id = 49, Name = "زين فارما", Location = "Damascus", CreationDate = DateTime.Now, CreationBy = 2 });
            entity.HasData(new Company { Id = 50, Name = "سرّاج", Location = "Damascus", CreationDate = DateTime.Now, CreationBy = 2 });
            entity.HasData(new Company { Id = 51, Name = "سلامة كير", Location = "Damascus", CreationDate = DateTime.Now, CreationBy = 2 });
            entity.HasData(new Company { Id = 52, Name = "سيتي فارما", Location = "Damascus", CreationDate = DateTime.Now, CreationBy = 2 });
            entity.HasData(new Company { Id = 53, Name = "سيردا فارما", Location = "Damascus", CreationDate = DateTime.Now, CreationBy = 2 });
            entity.HasData(new Company { Id = 54, Name = "سيفارما", Location = "Damascus", CreationDate = DateTime.Now, CreationBy = 2 });
            entity.HasData(new Company { Id = 55, Name = "شرق المتوسط(ليم)", Location = "Damascus", CreationDate = DateTime.Now, CreationBy = 2 });
            entity.HasData(new Company { Id = 56, Name = "شرق المتوسط(ليم) ", Location = "Damascus", CreationDate = DateTime.Now, CreationBy = 2 });
            entity.HasData(new Company { Id = 57, Name = "شفا", Location = "Damascus", CreationDate = DateTime.Now, CreationBy = 2 });
            entity.HasData(new Company { Id = 58, Name = "عبد الوهّاب القنواتي", Location = "Damascus", CreationDate = DateTime.Now, CreationBy = 2 });
            entity.HasData(new Company { Id = 59, Name = "غولدن ميد فارما ( الذهبية ) ", Location = "Damascus", CreationDate = DateTime.Now, CreationBy = 2 });
            entity.HasData(new Company { Id = 60, Name = "فارماسير", Location = "Damascus", CreationDate = DateTime.Now, CreationBy = 2 });
            entity.HasData(new Company { Id = 61, Name = "فكتوريا", Location = "Damascus", CreationDate = DateTime.Now, CreationBy = 2 });
            entity.HasData(new Company { Id = 62, Name = "فيتا", Location = "Damascus", CreationDate = DateTime.Now, CreationBy = 2 });
            entity.HasData(new Company { Id = 63, Name = "كسبار و شعباني", Location = "Damascus", CreationDate = DateTime.Now, CreationBy = 2 });
            entity.HasData(new Company { Id = 64, Name = "كندة فارما", Location = "Damascus", CreationDate = DateTime.Now, CreationBy = 2 });
            entity.HasData(new Company { Id = 65, Name = "كيمي", Location = "Damascus", CreationDate = DateTime.Now, CreationBy = 2 });
            entity.HasData(new Company { Id = 66, Name = "لاما فارما", Location = "Damascus", CreationDate = DateTime.Now, CreationBy = 2 });
            entity.HasData(new Company { Id = 67, Name = "ماجيكو", Location = "Damascus", CreationDate = DateTime.Now, CreationBy = 2 });
            entity.HasData(new Company { Id = 68, Name = "مسعود فارما", Location = "Damascus", CreationDate = DateTime.Now, CreationBy = 2 });
            entity.HasData(new Company { Id = 69, Name = "مسعود للمحاليل الطبية", Location = "Damascus", CreationDate = DateTime.Now, CreationBy = 2 });
            entity.HasData(new Company { Id = 70, Name = "معتوق فارما", Location = "Damascus", CreationDate = DateTime.Now, CreationBy = 2 });
            entity.HasData(new Company { Id = 71, Name = "مياميد", Location = "Damascus", CreationDate = DateTime.Now, CreationBy = 2 });
            entity.HasData(new Company { Id = 72, Name = "ميديفارم", Location = "Damascus", CreationDate = DateTime.Now, CreationBy = 2 });
            entity.HasData(new Company { Id = 73, Name = "ميديكو", Location = "Damascus", CreationDate = DateTime.Now, CreationBy = 2 });
            entity.HasData(new Company { Id = 74, Name = "ميديوتيك", Location = "Damascus", CreationDate = DateTime.Now, CreationBy = 2 });
            entity.HasData(new Company { Id = 75, Name = "ميرسي فارما", Location = "Damascus", CreationDate = DateTime.Now, CreationBy = 2 });
            entity.HasData(new Company { Id = 76, Name = "ميغا فارما", Location = "Damascus", CreationDate = DateTime.Now, CreationBy = 2 });
            entity.HasData(new Company { Id = 77, Name = "هيومن", Location = "Damascus", CreationDate = DateTime.Now, CreationBy = 2 });
            entity.HasData(new Company { Id = 78, Name = "يونايتد", Location = "Damascus", CreationDate = DateTime.Now, CreationBy = 2 });
            entity.HasData(new Company { Id = 79, Name = "يونيشيما", Location = "Damascus", CreationDate = DateTime.Now, CreationBy = 2 });
            entity.HasData(new Company { Id = 80, Name = "يونيفارما", Location = "Damascus", CreationDate = DateTime.Now, CreationBy = 2 });
            #endregion
        }
    }
}
