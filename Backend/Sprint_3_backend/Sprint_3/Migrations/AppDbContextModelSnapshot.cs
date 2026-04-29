
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Sprint_3.Data;

#nullable disable

namespace Sprint_3.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("Sprint_3.Models.Aluno", b =>
                {
                    b.Property<long>("idealuno")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<long>("idealuno"));

                    b.Property<string>("cpf")
                        .HasMaxLength(11)
                        .HasColumnType("varchar(11)");

                    b.Property<DateTime?>("dataNascimento")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("email")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("matricula")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("nomaluno")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("telefone")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.HasKey("idealuno");

                    b.ToTable("alunos");
                });
#pragma warning restore 612, 618
        }
    }
}
