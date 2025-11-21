using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Models
{
    public class Categoria
    {
        public static readonly string INSERTCATEGORIA = @"INSERT INTO tblCategorias(Nome, Descricao, Diaria) 
                                                        VALUES(@Nome, @Descricao, @Diaria)";

        public static readonly string SELECTCATEGORIAS = @"SELECT Nome, Descricao, Diaria 
                                                        FROM tblCategorias";

        public static readonly string UPDATECATEGORIA = @"UPDATE tblCategorias
                                                        SET Descricao = @Descricao,
                                                        Diaria = @Diaria
                                                        WHERE Nome = @Nome";

        public static readonly string SELECTCATEGORIAPORNOME = @"SELECT Nome, Descricao, Diaria 
                                                                FROM tblCategorias
                                                                WHERE Nome = @Nome";

        public static readonly string SELECTCATEGORIAPORID = @"SELECT Nome
                                                                FROM tblCategorias
                                                                WHERE CategoriaID = @CategoriaID";

        public static readonly string DELETECATEGORIA = @"DELETE FROM tblCategorias
                                                          WHERE Nome = @Nome";

        public static readonly string INSERTCATEGORIAPROCEDURE = @"EXEC sp_AdicionarCategoria @Nome, @Descricao, @Diaria;";

        public int CategoriaID { get; private set; }
        public string Nome { get; private set; }
        public string? Descricao { get; private set; }
        public decimal Diaria { get; private set; }

        public Categoria(string nome, decimal diaria)
        {
            Nome = nome;
            Diaria = diaria;
        }
        public Categoria(string nome, decimal diaria, string? descricao) : this (nome, diaria)
        {
            Descricao = descricao;
        }

        public void SetCategoriaID(int categoriaID)
        {
            CategoriaID = categoriaID;
        }

        public void SetNomeCategoria(string nome) 
        {
            Nome = nome;
        }

        public override string? ToString()
        {
            return $"Categoria: {Nome}\nDescrição: {Descricao}\nDiária: {Diaria:C}\n";
        }

    }
}
