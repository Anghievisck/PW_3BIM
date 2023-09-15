using MySql.Data.MySqlClient;
using System;

namespace AppBanco
{
    class UsuarioDAO{
        Banco db = new Banco();
        public void Insert(string strNomeUser, string strCargo, string strDataNasc) {
            string strInsert = string.Format("Insert into tbUsuario(NomeUser, Cargo, DataNasc) " + 
                "values ('{0}', '{1}', STR_TO_DATE('{2}', '%d/%m/%Y'));", strNomeUser, strCargo, strDataNasc);
            
            db.Open();
            
            db.ExecuteNowSql(strInsert);
            
            db.Close();
        }

        public void Update(string strIdUser, string strNomeUser, string strCargo, string strDataNasc){
            db.Open();
            
            string strUpdate = string.Format("Update tbUsuario set NomeUser = '{0}', Cargo = '{1}', DataNasc = STR_TO_DATE('{2}', '%d/%m/%Y') " +
                "where IdUser = {3};", strNomeUser, strCargo, strDataNasc, strIdUser);
            
            db.ExecuteNowSql(strUpdate);
            
            db.Close();
        }

        public void Delete(string strIdUser) {
            db.Open();
            
            string strDelete = string.Format("Delete from tbUsuario where IdUser = {0};", strIdUser);
            
            db.ExecuteNowSql(strDelete);
            
            db.Close();
        }

        public string SelectDado(string strIdUser) {
            string strDado = "Select NomeUser from tbUsuario where IdUser = " + strIdUser + ";";
            
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