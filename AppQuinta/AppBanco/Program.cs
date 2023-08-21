using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBanco{
    internal class Program{
        static void Main(string[] args){
            MySqlConnection Conexao = new MySqlConnection(@"Server = Localhost; database = dbAppBanco; user = root; password = 12345678");
            Conexao.Open();

            Console.WriteLine("Digite o Nome:");
            string strNomeUser = Console.ReadLine();

            Console.WriteLine("Digite o Cargo:");
            string strCargo = Console.ReadLine();

            Console.WriteLine("Informe a data de Nascimento");
            string strDataNasc = Console.ReadLine();

            string strInsert = string.Format("Insert into tbUsuario(NomeUSer, Cargo,DataNasc)" +
                " values ('{0}', '{1}', STR_TO_DATE('{2}', '%d/%m/%Y'));", strNomeUser, strCargo, strDataNasc);
            MySqlCommand InsertCommand = new MySqlCommand(strInsert, Conexao);
            InsertCommand.ExecuteNonQuery();


            string strDelete = "Delete from tbUsuario where IdUser = 3";
            MySqlCommand CommandD = new MySqlCommand(strDelete, Conexao);
            CommandD.ExecuteNonQuery();


            string strSelect = "Select * from tbUsuario";
            //          Pode inserir o comando e conexão como parametros
            MySqlCommand ObjCommand = new MySqlCommand(strSelect, Conexao);

            //          ObjCommand.CommandText = "Select * from tbUsuario";
            //          ObjCommand.Connection = Conexao;

            //          Quando o CommandType é omitido, o padrão é Text
            //          ObjCommand.CommandType = System.Data.CommandType.Text;


            string strUpdate = "Update tbUsuario set NomeUser = 'João' where IdUser = 4;";
            MySqlCommand CommandU = new MySqlCommand(strUpdate, Conexao);
            CommandU.ExecuteNonQuery();

            
            MySqlDataReader Leitor = ObjCommand.ExecuteReader();

            while(Leitor.Read()){
                Console.WriteLine("Código: {0} | Nome: {1} | Cargo: {2} | Data de Nascimento: {3}",
                    Leitor["IdUser"], Leitor["NomeUser"], Leitor["Cargo"], Leitor["DataNasc"]);
            }

            Leitor.Close();

            Console.ReadLine();
        }
    }
}
