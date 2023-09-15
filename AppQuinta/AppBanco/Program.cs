using System;

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
            
            Console.Write("Informe Id para identificação: ");
            strIdUser = Console.ReadLine();
            Console.WriteLine("Olá senhor(a): " + ObjDao.SelectDado(strIdUser));
            Console.WriteLine();

            /*
            MySqlConnection Conexao = new MySqlConnection(@"Server = Localhost; database = dbAppBanco; user = root; password = 12345678");
            Conexao.Open();
            */

            Console.Write("Digite o Nome: ");
            strNomeUser = Console.ReadLine();

            Console.Write("Digite o Cargo: ");
            strCargo = Console.ReadLine();

            Console.Write("Informe a data de Nascimento: ");
            strDataNasc = Console.ReadLine();

            ObjDao.Insert(strNomeUser, strCargo, strDataNasc);
            Console.WriteLine();
            
            ObjDao.Delete("3");

            ObjDao.Select("*");
            Console.WriteLine();

            Console.Write("Informe Id para ser deletado: ");
            strIdUser = Console.ReadLine();
            ObjDao.Delete(strIdUser);
            Console.WriteLine();

            /*
            string strSelectId = "Select NomeUser from tbUsuario where IdUser = " + strIdUser + ";";
            string strDado = db.ExecuteScalarSql(strSelectId);
            Console.WriteLine("Olá senhor(a) " + strDado);
            */

            Console.Write("Digite o Id do usuário a ser atualizado: ");
            strIdUser = Console.ReadLine();

            Console.Write("Digite o novo Nome: ");
            strNomeUser = Console.ReadLine();

            Console.Write("Digite o novo Cargo: ");
            strCargo = Console.ReadLine();

            Console.Write("Informe a nova data de Nascimento: ");
            strDataNasc = Console.ReadLine();

            ObjDao.Update(strIdUser, strNomeUser, strCargo, strDataNasc);
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