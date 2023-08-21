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


            string strInsert = "Insert into tbUsuario(NomeUser, Cargo, DataNasc) values ('Enildo', 'Professor', '1978/07/21')";
            string strSelect = "Select * from tbUsuario";

            MySqlCommand InsertCommand = new MySqlCommand(strInsert, Conexao);
            InsertCommand.ExecuteNonQuery();

//          Pode inserir o comando e conexão como parametros
            MySqlCommand ObjCommand = new MySqlCommand(strSelect, Conexao);

//          ObjCommand.CommandText = "Select * from tbUsuario";
//          ObjCommand.Connection = Conexao;

//          Quando o CommandType é omitido, o padrão é Text
//          ObjCommand.CommandType = System.Data.CommandType.Text;

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
