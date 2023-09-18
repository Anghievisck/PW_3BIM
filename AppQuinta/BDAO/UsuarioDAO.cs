using BBanco;
using BModel;
using MySql.Data.MySqlClient;
using System;

namespace BDAO{
    public class UsuarioDAO{
        Banco db = new Banco();

        Usuario ObjUsuario = new Usuario();


        public void Insert(Usuario ObjUsuario) {
            string strInsert = string.Format("Insert into tbUsuario(NomeUser, Cargo, DataNasc) " + 
                "values ('{0}', '{1}', STR_TO_DATE('{2}', '%d/%m/%Y 00:00:00'));", ObjUsuario.NomeUser, ObjUsuario.Cargo, ObjUsuario.DataNasc);
            
            db.Open();
            
            db.ExecuteNowSql(strInsert);
            
            db.Close();
        }

        public void Update(Usuario ObjUsuario)
        {
            db.Open();
            
            string strUpdate = string.Format("Update tbUsuario set NomeUser = '{0}', Cargo = '{1}', DataNasc = STR_TO_DATE('{2}', '%d/%m/%Y 00:00:00') " +
                "where IdUser = {3};", ObjUsuario.NomeUser, ObjUsuario.Cargo, ObjUsuario.DataNasc, ObjUsuario.IdUser);
            
            db.ExecuteNowSql(strUpdate);
            
            db.Close();
        }

        public void Delete(int Id) {
            db.Open();
            
            string strDelete = string.Format("Delete from tbUsuario where IdUser = {0};", Id);
            
            db.ExecuteNowSql(strDelete);
            
            db.Close();
        }

        public string SelectDado(int Id) {
            string strDado = "Select NomeUser from tbUsuario where IdUser = " + Id + ";";
            
            db.Open();
            
            strDado = db.ExecuteScalarSql(strDado);
            
            db.Close();
            
            return strDado;
        }

        public MySqlDataReader Select(string strAtributos) {
            string strSelect = "Select " + strAtributos + " from tbUsuario;";
            
            db.Open();
            
            MySqlDataReader Leitor = db.ExecuteReadSql(strSelect);
            
            while(Leitor.Read()){
                Console.WriteLine("Código: {0} | Nome: {1} | Cargo: {2} | Data de Nascimento: {3}",
                    Leitor["IdUser"], Leitor["NomeUser"], Leitor["Cargo"], Leitor["DataNasc"]);
            }

            db.Close();

            return Leitor;
        }
    }
}