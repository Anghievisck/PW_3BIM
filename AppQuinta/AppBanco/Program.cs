using System;
using BDAO;
using BModel;

namespace AppBanco
{
    internal class Program{
        static void Main(string[] args){
            string strIdUser;
            string strNomeUser;
            string strCargo;
            string strDataNasc;
            string strSelect;

            // Banco db = new Banco();
            
            UsuarioDAO ObjDao = new UsuarioDAO();
            Usuario ObjUsuario = new Usuario();

            Console.Write("Informe Id para identificação: ");
            ObjUsuario.IdUser = int.Parse(Console.ReadLine());

            Console.Clear();
            Console.Write("Olá senhor(a): " + ObjDao.SelectDado(ObjUsuario.IdUser));

            /*
            MySqlConnection Conexao = new MySqlConnection(@"Server = Localhost; database = dbAppBanco; user = root; password = 12345678");
            Conexao.Open();
            */
            Console.WriteLine("\n Vamos inserir um novo registro");
            Console.Write("Digite o Nome: ");
            ObjUsuario.NomeUser = Console.ReadLine();

            Console.Write("Digite o Cargo: ");
            ObjUsuario.Cargo = Console.ReadLine();

            Console.Write("Informe a data de Nascimento: ");
            ObjUsuario.DataNasc = DateTime.Parse(Console.ReadLine());

            ObjDao.Insert(ObjUsuario);
            
            Console.WriteLine("\n");
            ObjDao.Select("*");

            Console.Write("\n Informe Id para ser deletado: ");
            ObjUsuario.IdUser = int.Parse(Console.ReadLine());
            ObjDao.Delete(ObjUsuario.IdUser);
            Console.Clear();
            ObjDao.Select("*");


            /*
            string strSelectId = "Select NomeUser from tbUsuario where IdUser = " + strIdUser + ";";
            string strDado = db.ExecuteScalarSql(strSelectId);
            Console.WriteLine("Olá senhor(a) " + strDado);
            */

            Console.WriteLine("\n Vamos atualizar um registro");
            Console.Write("Digite o Id do usuário a ser atualizado: ");
            ObjUsuario.IdUser = int.Parse(Console.ReadLine());

            Console.Write("Digite o novo Nome: ");
            ObjUsuario.NomeUser = Console.ReadLine();

            Console.Write("Digite o novo Cargo: ");
            ObjUsuario.Cargo = Console.ReadLine();

            Console.Write("Informe a nova data de Nascimento: ");
            ObjUsuario.DataNasc = DateTime.Parse(Console.ReadLine());

            ObjDao.Update(ObjUsuario);
            Console.WriteLine();


            ObjDao.Select("*");
            Console.ReadLine();
        }
    }
}
//          Pode inserir o comando e conexão como parametros
//          MySqlCommand ObjCommand = new MySqlCommand(strSelect, Conexao);

//          ObjCommand.CommandText = "Select * from tbUsuario";
//          ObjCommand.Connection = Conexao;

//          Quando o CommandType é omitido, o padrão é Text
//          ObjCommand.CommandType = System.Data.CommandType.Text;