﻿// <auto-generated />
using System;
using Cepedi.BancoCentral.Cadastro.Dados;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Cepedi.BancoCentral.Cadastro.Dados.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.17")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Cepedi.BancoCentral.Cadastro.Dominio.Entidades.BancoEntity", b =>
                {
                    b.Property<int>("IdBanco")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdBanco"));

                    b.Property<string>("Cnpj")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime2");

                    b.Property<string>("NomeFantasia")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomeReal")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdBanco");

                    b.ToTable("Banco", (string)null);
                });

            modelBuilder.Entity("Cepedi.BancoCentral.Cadastro.Dominio.Entidades.EmailEntity", b =>
                {
                    b.Property<int>("IdEmail")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdEmail"));

                    b.Property<string>("EnderecoEmail")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("IdPessoa")
                        .HasColumnType("int");

                    b.HasKey("IdEmail");

                    b.HasIndex("IdPessoa");

                    b.ToTable("Email", (string)null);
                });

            modelBuilder.Entity("Cepedi.BancoCentral.Cadastro.Dominio.Entidades.EnderecoEntity", b =>
                {
                    b.Property<int>("IdEndereco")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdEndereco"));

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

                    b.Property<int>("IdPessoa")
                        .HasColumnType("int");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Pais")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("IdEndereco");

                    b.HasIndex("IdPessoa");

                    b.ToTable("Endereco", (string)null);
                });

            modelBuilder.Entity("Cepedi.BancoCentral.Cadastro.Dominio.Entidades.EstadoCivilEntity", b =>
                {
                    b.Property<int>("IdEstadoCivil")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdEstadoCivil"));

                    b.Property<string>("NomeEstadoCivil")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("IdEstadoCivil");

                    b.ToTable("EstadoCivil", (string)null);
                });

            modelBuilder.Entity("Cepedi.BancoCentral.Cadastro.Dominio.Entidades.GeneroEntity", b =>
                {
                    b.Property<int>("IdGenero")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdGenero"));

                    b.Property<string>("NomeGenero")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("IdGenero");

                    b.ToTable("Genero", (string)null);
                });

            modelBuilder.Entity("Cepedi.BancoCentral.Cadastro.Dominio.Entidades.NacionalidadeEntity", b =>
                {
                    b.Property<int>("IdNacionalidade")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdNacionalidade"));

                    b.Property<string>("NomeNacionalidade")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("IdNacionalidade");

                    b.ToTable("Nacionalidade", (string)null);
                });

            modelBuilder.Entity("Cepedi.BancoCentral.Cadastro.Dominio.Entidades.PessoaEntity", b =>
                {
                    b.Property<int>("IdPessoa")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPessoa"));

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<int>("EstadoCivil")
                        .HasColumnType("int");

                    b.Property<int>("Genero")
                        .HasColumnType("int");

                    b.Property<int>("Nacionalidade")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("IdPessoa");

                    b.ToTable("Pessoa", (string)null);
                });

            modelBuilder.Entity("Cepedi.BancoCentral.Cadastro.Dominio.Entidades.PixEntity", b =>
                {
                    b.Property<int>("IdPix")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPix"));

                    b.Property<string>("ChavePix")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("IdPessoa")
                        .HasColumnType("int");

                    b.Property<string>("TipoPix")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int?>("TipoPixEntityIdTipoPix")
                        .HasColumnType("int");

                    b.HasKey("IdPix");

                    b.HasIndex("IdPessoa");

                    b.HasIndex("TipoPixEntityIdTipoPix");

                    b.ToTable("Pix", (string)null);
                });

            modelBuilder.Entity("Cepedi.BancoCentral.Cadastro.Dominio.Entidades.RegistroTransacaoBancoEntity", b =>
                {
                    b.Property<int>("IdRegistro")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdRegistro"));

                    b.Property<DateTime>("DataRegistro")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdBanco")
                        .HasColumnType("int");

                    b.Property<int>("IdPessoa")
                        .HasColumnType("int");

                    b.Property<int>("IdTipoRegistro")
                        .HasColumnType("int");

                    b.Property<double>("Valor")
                        .HasColumnType("float");

                    b.HasKey("IdRegistro");

                    b.HasIndex("IdBanco");

                    b.HasIndex("IdPessoa");

                    b.HasIndex("IdTipoRegistro");

                    b.ToTable("RegistroTransacaoBanco", (string)null);
                });

            modelBuilder.Entity("Cepedi.BancoCentral.Cadastro.Dominio.Entidades.TelefoneEntity", b =>
                {
                    b.Property<int>("IdTelefone")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdTelefone"));

                    b.Property<int>("IdPessoa")
                        .HasColumnType("int");

                    b.Property<string>("NumeroTelefone")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("IdTelefone");

                    b.HasIndex("IdPessoa");

                    b.ToTable("Telefone", (string)null);
                });

            modelBuilder.Entity("Cepedi.BancoCentral.Cadastro.Dominio.Entidades.TipoPixEntity", b =>
                {
                    b.Property<int>("IdTipoPix")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdTipoPix"));

                    b.Property<string>("TipoPix")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("IdTipoPix");

                    b.ToTable("TipoPix", (string)null);
                });

            modelBuilder.Entity("Cepedi.BancoCentral.Cadastro.Dominio.Entidades.TipoRegistroEntity", b =>
                {
                    b.Property<int>("IdTipoRegistro")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdTipoRegistro"));

                    b.Property<string>("NomeTipo")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("IdTipoRegistro");

                    b.ToTable("TipoRegistro", (string)null);
                });

            modelBuilder.Entity("Cepedi.BancoCentral.Cadastro.Dominio.Entidades.UsuarioEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Celular")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<bool>("CelularValidado")
                        .HasColumnType("bit");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.ToTable("Usuario", (string)null);
                });

            modelBuilder.Entity("Cepedi.BancoCentral.Cadastro.Dominio.Entidades.EmailEntity", b =>
                {
                    b.HasOne("Cepedi.BancoCentral.Cadastro.Dominio.Entidades.PessoaEntity", null)
                        .WithMany("Emails")
                        .HasForeignKey("IdPessoa")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Cepedi.BancoCentral.Cadastro.Dominio.Entidades.EnderecoEntity", b =>
                {
                    b.HasOne("Cepedi.BancoCentral.Cadastro.Dominio.Entidades.PessoaEntity", null)
                        .WithMany("Enderecos")
                        .HasForeignKey("IdPessoa")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Cepedi.BancoCentral.Cadastro.Dominio.Entidades.PixEntity", b =>
                {
                    b.HasOne("Cepedi.BancoCentral.Cadastro.Dominio.Entidades.PessoaEntity", null)
                        .WithMany("Pix")
                        .HasForeignKey("IdPessoa")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cepedi.BancoCentral.Cadastro.Dominio.Entidades.TipoPixEntity", null)
                        .WithMany("Pixs")
                        .HasForeignKey("TipoPixEntityIdTipoPix");
                });

            modelBuilder.Entity("Cepedi.BancoCentral.Cadastro.Dominio.Entidades.RegistroTransacaoBancoEntity", b =>
                {
                    b.HasOne("Cepedi.BancoCentral.Cadastro.Dominio.Entidades.BancoEntity", "Banco")
                        .WithMany()
                        .HasForeignKey("IdBanco")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cepedi.BancoCentral.Cadastro.Dominio.Entidades.PessoaEntity", "Pessoa")
                        .WithMany()
                        .HasForeignKey("IdPessoa")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cepedi.BancoCentral.Cadastro.Dominio.Entidades.TipoRegistroEntity", "TipoRegistro")
                        .WithMany()
                        .HasForeignKey("IdTipoRegistro")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Banco");

                    b.Navigation("Pessoa");

                    b.Navigation("TipoRegistro");
                });

            modelBuilder.Entity("Cepedi.BancoCentral.Cadastro.Dominio.Entidades.TelefoneEntity", b =>
                {
                    b.HasOne("Cepedi.BancoCentral.Cadastro.Dominio.Entidades.PessoaEntity", null)
                        .WithMany("Telefones")
                        .HasForeignKey("IdPessoa")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Cepedi.BancoCentral.Cadastro.Dominio.Entidades.PessoaEntity", b =>
                {
                    b.Navigation("Emails");

                    b.Navigation("Enderecos");

                    b.Navigation("Pix");

                    b.Navigation("Telefones");
                });

            modelBuilder.Entity("Cepedi.BancoCentral.Cadastro.Dominio.Entidades.TipoPixEntity", b =>
                {
                    b.Navigation("Pixs");
                });
#pragma warning restore 612, 618
        }
    }
}
