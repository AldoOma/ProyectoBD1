using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Sol_AllMarket.Presentacion
{
    public class CryptographyMD5
    {
        //va a retornar el mensaje ya encriptado
        public string Encrypt(string Mensaje)
        {
            //este hash va a funcionar como una llave que debe ser la misma para encriptar y desencriptar

            string hash = "bdMarket";

            //obtenemos los bytes del mensaje que estamos recibiendo

            byte[] data = UTF8Encoding.UTF8.GetBytes(Mensaje);

            //Creamos el protocolo MD5 y TripleDES

            MD5 md5 = MD5.Create();

            TripleDES tripleDES = TripleDES.Create();

            //Agregamos a tripleDES la llave en un formato utf8 y obtenemos los bytes del hash, tambien el modo

            tripleDES.Key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));

            tripleDES.Mode = CipherMode.ECB; //Es para que el mismo texto devuelva siempre el mismo texto y asi poder comparar

            ICryptoTransform transform = tripleDES.CreateEncryptor();//tripleDES tiene todas las configuracion que agregamos a tripleDES
            
            byte[] resultado = transform.TransformFinalBlock(data,0,data.Length);
            //data es el input buffer que es lo que vamos a transformar, 0 es el input offset y el input camp que es el conteo total de toda la data

            //convertimos los bytes en cadena
            return Convert.ToBase64String(resultado);



        }


        //para decifrar debe ser el mismo hash
        /*
         * el has debe ser el mismo para encriptar y para desencriptar 
         * Este metodo es seguro porque el hash que definamos va a ser unico
         * y para que pudan saber mi informacion tendrian que adivinar el codigo
         */

        public String Decrypt(String Mensaje)
        {
            //este hash va a funcionar como una llave que debe ser la misma para encriptar y desencriptar

            string hash = "bdMarket";

            //como ya esta codificado en utf8 ahora vamos a traer el mensaje que estamos recibiendo

            byte[] data = Convert.FromBase64String(Mensaje);

            //Creamos el protocolo MD5 y TripleDES

            MD5 md5 = MD5.Create();

            TripleDES tripleDES = TripleDES.Create();

            //Agregamos a tripleDES la llave en un formato utf8 y obtenemos los bytes del hash, tambien el modo

            tripleDES.Key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));

            tripleDES.Mode = CipherMode.ECB; //Es para que el mismo texto devuelva siempre el mismo texto y asi poder comparar

            //creamos el descifrador
            ICryptoTransform transform = tripleDES.CreateDecryptor();//tripleDES tiene todas las configuracion que agregamos a tripleDES

            byte[] resultado = transform.TransformFinalBlock(data, 0, data.Length);
            //data es el input buffer que es lo que vamos a transformar, 0 es el input offset y el input camp que es el conteo total de toda la data

            //convertimos los bytes en cadena
            return UTF8Encoding.UTF8.GetString(resultado);
        }
    }

}
