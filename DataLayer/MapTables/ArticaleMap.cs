using DataLayer.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataLayer.MapTables
{
    public class ArticaleMap
    {
        public ArticaleMap(EntityTypeBuilder<Article> entity)
        {
            entity.ToTable("Articale");
            entity.Property(e => e.Name)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.Description)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.Description2)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.Note)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.Note2)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.ScientificName)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.ActiveIngredients)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.Dosage)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.SideEffects)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.Interactions)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.Precautions)
                .HasDefaultValueSql("('')");

            //entity.HasOne(d => d.ArticaleSubCategory)
            //    .WithMany(p => p.Articales)
            //    .HasForeignKey(d => d.ArticaleSubCategory)
            //    .HasConstraintName("FK_Articale_ArticaleSubCategory");
        }
        public ArticaleMap(EntityTypeBuilder<ArticleCategory> entity)
        {
            entity.ToTable("ArticaleCategory");
            entity.Property(e => e.Name)
                .HasDefaultValueSql("('')");
        }
        //public ArticaleMap(EntityTypeBuilder<ArticaleSubCategory> entity)
        //{
        //    entity.ToTable("ArticaleSubCategory");
        //    entity.Property(e => e.Name)
        //        .HasDefaultValueSql("('')");

        //    //entity.HasOne(d => d.ArticaleCategory)
        //    //    .WithMany(p => p.ArticaleSubCategorys)
        //    //    .HasForeignKey(d => d.ArticaleCategoryId)
        //    //    .HasConstraintName("FK_ArticaleSubCategory_ArticaleCategory");
        //}
    }
}
